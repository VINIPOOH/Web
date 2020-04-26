using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.mapers;
using AutoMapper;
using BLL.dto;
using BLL.Intarfaces;
using BLL.mapers;
using BLL.Servise;
using ComputerNet.DAL.Interfaces;
using ComputerNet.DAL.Repositories;
using DAL.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApplication1.Dal;

namespace API
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
            services.AddControllers();
            services.AddScoped<IGenericService<CityDto>, GenericService<City, CityDto>>();
            services.AddScoped<IGenericService<StreetDto>, GenericService<Street, StreetDto>>();
            services.AddScoped<IGenericService<HouseDto>, GenericService<House, HouseDto>>();
            services.AddScoped<IGenericService<ApartmentDto>, GenericService<Apartment, ApartmentDto>>();
            services.AddScoped<IGenericService<UserDto>, GenericService < User, UserDto >> ();

            services.AddDbContext<MyDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            var mapperAPIConfig = new MapperConfiguration(opt => opt.AddProfile<ModelDtoMaper>());
            IMapper mapperAPI = new Mapper(mapperAPIConfig);
            services.AddSingleton(mapperAPI);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = " API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameStore API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
