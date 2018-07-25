using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapptaApi.Models;
using CapptaApi.Repositories;
using CapptaApi.Repository;
using CapptaApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CapptaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            
            var lista = new LeitorCsvRepository().LerCSVParaListaTransacaoModel(Constantes.Const.DadosCsv);
                        
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.TryAddSingleton<List<Transacao>>(lista);



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
            app.UseStatusCodePagesWithRedirects("/error/{0}");
        }
    }
}
