using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.dto;
using BLL.Intarfaces;
using BLL.Servise;
using ComputerNet.DAL.Interfaces;
using ComputerNet.DAL.Repositories;
using DAL.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WEB.mapers;
using WebApplication1.Dal;

namespace WEB
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
            services.AddControllersWithViews();
            services.AddDbContext<MyDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();

            services.AddScoped<IGenericService<CityDto, City>, GenericService<City, CityDto>>();
            services.AddScoped<IGenericService<StreetDto, Street>, GenericService<Street, StreetDto>>();
            services.AddScoped<IGenericService<HouseDto, House>, GenericService<House, HouseDto>>();
            services.AddScoped<IGenericService<ApartmentDto, Apartment>, GenericService<Apartment, ApartmentDto>>();
            services.AddScoped<IGenericService<UserDto, User>, GenericService<User, UserDto>>();
            services.AddScoped<IGenericService<UserAppartmenDto, UserApartment>, GenericService<UserApartment, UserAppartmenDto >>();

            services.AddDbContext<MyDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var mapperAPIConfig = new MapperConfiguration(opt => opt.AddProfile<ModelDtoMaper>());
            IMapper mapperAPI = new Mapper(mapperAPIConfig);
            services.AddSingleton(mapperAPI);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
