using BouquetShop.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BouquetShop.GraphQL;

namespace BouquetShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public static string DbPath = "Shop.db";

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(options => options.UseSqlite(@"Data Source=./Shop.db"));
            services.AddMvc();

            services.
                AddGraphQLServer().
                AddQueryType<Query>().
                AddMutationType<Mutation>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRouting();
            app.UseGraphQLAltair("/");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}