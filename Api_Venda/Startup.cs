using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Api_Venda.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Api_Venda
{
    public class Startup
    {
        private static IConfigurationRoot Configuration;

        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VendaContext>(opt => opt.UseInMemoryDatabase("VendaList"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
