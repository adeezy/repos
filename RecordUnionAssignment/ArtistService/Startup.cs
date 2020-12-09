using Artist.Api;
using Artist.Data.Database;
using Artist.Data.Repository;
using Artist.Domain;
using Artist.Service.Command;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Artist.Service.Services;
using Artist.Service.Query;

namespace Artist
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddTransient<IRequestHandler<CreateArtistCommand, Domain.Artist>, CreateArtistCommandHandler>();
            services.AddTransient<IRequestHandler<GetArtistQuery, Domain.Artist>, GetArtistQueryHandler>();
            services.AddDbContext<ArtistContext>();
            services.AddTransient<ICreateArtistService, CreateArtistService>();
            services.AddSingleton(Configuration.GetSection("Client").Get<Client>());
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
