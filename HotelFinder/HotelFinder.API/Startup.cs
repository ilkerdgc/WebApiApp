using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HotelFinder.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services) // buras� servis'lerin(k�t�phaneler/s�n�flar) dahil edildi�i yer.
        {
            services.AddControllers();

            services.AddSingleton<IHotelService, HotelMenager>(); // dependency injection prinsibi Singleton kullan�m�. burada AddSingleton metoduna IHotelService veriyoruz ve bize HotelMenager veriyor. bu sayede ilgili controller'�n constructor'�nda new ile, ilgili classtan nesne olu�turmam�za gerek kalm�yor bu i�lemi burada y�netilebilir k�l�yoruz.
            services.AddSingleton<IHotelRepository, HotelRepository>(); // dependency injection prinsibi Singleton kullan�m�. burada AddSingleton metoduna IHotelRepository veriyoruz ve bize HotelRepository veriyor. bu sayede ilgili controller'�n constructor'�nda new ile, ilgili classtan nesne olu�turmam�za gerek kalm�yor bu i�lemi burada y�netilebilir k�l�yoruz.
            services.AddSingleton<HotelDbContext>(); // HotelDbContext nesnesini yine burada dependency injection prinsibi Singleton ile tan�ml�yoruz


            services.AddSwaggerDocument(config => {

                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "All Hotels API";
                    doc.Info.Version = "1.0.1";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "�lker Da�c�",
                        Email = "ilker.dagcii@gmail.com"
                    };
                });         
            }); // Swagger kullan�m� i�in AddSwaggerDocument gereklidir ve �zelle�tirilebilir.

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //buras� middleware(ara katman)'lar�n dahil edildi�i yer.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseOpenApi(); // Swagger kullan�m� i�in
            app.UseSwaggerUi3(); // Swagger kullan�m� i�in

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                endpoints.MapControllers();
            });
        }
    }
}
