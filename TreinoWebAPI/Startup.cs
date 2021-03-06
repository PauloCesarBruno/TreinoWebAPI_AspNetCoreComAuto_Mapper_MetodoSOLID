using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TreinoWebAPI.models;
using TreinoWebAPI.models.Data;

namespace TreinoWebAPI
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
            
            // Abaixo Ignora o Looping infinito do Json Quando Há muitos Join´s.
            //Baixar no Nughet -> Microsoft.ApNetCore.Mvc.NewtonsoftJson + a VERSSÃO.
               services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling = 
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            // ABAIXO CONFIGURAÇÃO PARA USO DO (AUTO-MAPPER).
            services.AddAutoMapper(System.AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddScoped<IRepositoryLeitura, RepositoryLeitura>(); 
            services.AddScoped<IRepositoryManipulacao, RepositoryManipulacao>();  
            services.AddDbContext<ProdutoContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConexaoDB")));
            services.AddCors();
            services.AddMvcCore();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TreinoWebAPI", Version = "v1" });
            });           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TreinoWebAPI v1"));
            }

           // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x=> x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}