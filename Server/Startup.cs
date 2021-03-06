using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Server.GraphQL;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ArticleService>();
            services.AddScoped<BlogSchema>();

            services.AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<BlogSchema>();
            app.UseGraphiQLServer(new GraphiQLOptions());
        }
    }
}
