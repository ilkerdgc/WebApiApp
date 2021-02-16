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


        public void ConfigureServices(IServiceCollection services) // burasý servis'lerin(kütüphaneler/sýnýflar) dahil edildiði yer.
        {
            services.AddControllers();

            services.AddSingleton<IHotelService, HotelMenager>(); // dependency injection prinsibi Singleton kullanýmý. burada AddSingleton metoduna IHotelService veriyoruz ve bize HotelMenager veriyor. bu sayede ilgili controller'ýn constructor'ýnda new ile, ilgili classtan nesne oluþturmamýza gerek kalmýyor bu iþlemi burada yönetilebilir kýlýyoruz.
            services.AddSingleton<IHotelRepository, HotelRepository>(); // dependency injection prinsibi Singleton kullanýmý. burada AddSingleton metoduna IHotelRepository veriyoruz ve bize HotelRepository veriyor. bu sayede ilgili controller'ýn constructor'ýnda new ile, ilgili classtan nesne oluþturmamýza gerek kalmýyor bu iþlemi burada yönetilebilir kýlýyoruz.
            services.AddSingleton<HotelDbContext>(); // HotelDbContext nesnesini yine burada dependency injection prinsibi Singleton ile tanýmlýyoruz


            services.AddSwaggerDocument(config => {

                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "All Hotels API";
                    doc.Info.Version = "1.0.1";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Ýlker Daðcý",
                        Email = "ilker.dagcii@gmail.com"
                    };
                });         
            }); // Swagger kullanýmý için AddSwaggerDocument gereklidir ve özelleþtirilebilir.

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //burasý middleware(ara katman)'larýn dahil edildiði yer.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseOpenApi(); // Swagger kullanýmý için
            app.UseSwaggerUi3(); // Swagger kullanýmý için

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
