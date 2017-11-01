using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace YoutubeClient
{
    public class YoutubeClient
    {
        private static readonly string YoutubeVideoBaseUri = "https://www.youtube.com/watch?v=";

        private readonly HttpClient _client;

        public YoutubeClient()
        {
            _client = new HttpClient
            {
                BaseAddress =
                    new Uri(
                        "https://www.googleapis.com/youtube/v3/search")
            };
        }

        public async Task<string> GetVideoLink(string search)
        {
            var response = await _client.GetAsync(
                "?part=snippet&" +
                "maxResults=1&" +
                $"q={HttpUtility.UrlEncode(search)}&" +
                "key=AIzaSyDn3MfJVjQJiNUeQ_L5v2hJ1sm59EDqh2s").ConfigureAwait(false);

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            SearchItem item = JsonConvert.DeserializeObject<SearchItem>(responseBody);

            return String.Concat(YoutubeVideoBaseUri, item.Items.FirstOrDefault()?.Id.VideoId);
        }
    }
}