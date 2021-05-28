using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using FluentValidation;

using Business.Entidades;
using Business.Excecoes;
using Business.Excecoes.Validator;
using Repository.Data;
using Repository.Repositorios;
using Repository.Interfaces;

namespace Api
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
            services.AddDbContext<Context>(c => c.UseInMemoryDatabase(databaseName: "challengeDb"));
            services.AddScoped<Context, Context>();

            services.AddControllers();
            //services.AddControllers().AddFluentValidation();

            services.AddTransient<IValidator<ProdutoInputModel>, ValidarCadastroProdutoValidator>();             
            services.AddTransient<IValidator<CategoriaInputModel>, ValidarCadastroCategoriaValidator>();

            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();


            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
            }

            app
                .Use(async (context, next) =>
                {
                    try
                    {
                        await next();
                    }
                    catch (BusinessException ex)
                    {
                        context.Response.ContentType = "text/plain";
                        context.Response.StatusCode =
                            (int)HttpStatusCode.InternalServerError;
                        await context
                            .Response
                            .WriteAsync(ex.Message);
                    }
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            //CORS
            app.UseCors(
                builder =>
                {
                    builder
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        // .SetIsOriginAllowed((host) => true);
                        .SetIsOriginAllowed(isOriginAllowed: _ => true);
                });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
