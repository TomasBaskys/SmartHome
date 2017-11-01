using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHome;
using SmartHome.Types;
using YoutubeClient;

namespace SmartHomeWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SmartHomeData>();
            services.AddSingleton<SmartHomeQuery>();
            services.AddSingleton<SmartHomeMutation>();

            services.AddSingleton<LaptopType>();
            services.AddSingleton<LaptopInputType>();
            services.AddSingleton<LaptopStateEnum>();
            services.AddSingleton<LightsType>();
            services.AddSingleton<LightsInputType>();
            services.AddSingleton<LightsStateEnum>();
            services.AddSingleton<LightsModeEnum>();

            services.AddSingleton<YoutubeClient.YoutubeClient>();
            services.AddSingleton<ChromeHandler>();

            services.AddSingleton(s => new SmartHomeSchema(new FuncDependencyResolver(s.GetService)));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
