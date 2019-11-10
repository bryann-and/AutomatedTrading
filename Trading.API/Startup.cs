using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DatabaseVersioning;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trading.API.Controllers;
using Trading.Operations.ExchangeEndpoints;

namespace Trading.API
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
            services.AddOptions();

            #region Carregando os EndPoints
            services.Configure<CoinBaseProEndpoints>(Configuration.GetSection("CoinBaseProEndpoints"));
            #endregion

            #region Criando os HTTPClients
            services.AddHttpClient("coinbase", c =>
            {
                c.BaseAddress = new Uri("https://api-public.sandbox.pro.coinbase.com");
                c.DefaultRequestHeaders.UserAgent.ParseAdd("C# Implementation");
            }); 
            #endregion

            services.AddControllers();
            services.AddApplicationInsightsTelemetry(options =>
            {
                options.EnableDebugLogger = false;
            });

            // Rodando o DbUp para aplicar as alterações de banco de dados
            if (!DbVersioning.VerificarVersaoBd(Configuration.GetConnectionString("DEV")))
            {
                throw new Exception("Erro ao executar versionamento do banco");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                TelemetryDebugWriter.IsTracingDisabled = true;
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
