using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace YoutubeClient
{
    public class ChromeHandler
    {
        private readonly YoutubeClient _client;
        private static HttpListener _listener;

        public ChromeHandler(YoutubeClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:60024/");
            _listener.Start();
        }

        public async Task MakeRequest(string search)
        {
            string videoUrl = await _client.GetVideoLink(search).ConfigureAwait(false);

            _listener.BeginGetContext(asyncRequest => ProcessRequest(asyncRequest, videoUrl), null);
        }

        public static void ProcessRequest(IAsyncResult asyncResult, string url)
        {
            HttpListenerContext context = _listener.EndGetContext(asyncResult);

            HttpListenerResponse response = context.Response;
            response.ContentType = "text/html";

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(url);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;

            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
