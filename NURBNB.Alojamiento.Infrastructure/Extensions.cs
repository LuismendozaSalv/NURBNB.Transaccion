﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NURBNB.Alojamiento.Application;
using NURBNB.Alojamiento.Application.Dto;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using NURBNB.Alojamiento.Infrastructure.EF;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.Repositories;
using Restaurant.SharedKernel.Core;
using System.IO;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;

namespace NURBNB.Alojamiento.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplicaction();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            AddDatabase(services, configuration, isDevelopment);
            InitDatabase(services);
            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplicaction();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            var connectionString =
                    configuration.GetConnectionString("AlojamientoDbConnectionString");
            services.AddDbContext<ReadDbContext>(context =>
                    context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<ICiudadRepository, CiudadRepository>();
            services.AddScoped<IPropiedadRepository, PropiedadRepository>();
            services.AddScoped<IDireccionRepository, DireccionRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
                context.Database.Migrate();
            }
        }

        public static void InitDatabase(IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
            if (!context.Pais.Any())
            {
                var jsonData = File.ReadAllText("../NURBNB.Alojamiento.Infrastructure/EF/Json/PaisesCiudades.json");
                var paisesCiudades = JsonConvert.DeserializeObject<PaisCiudadesDto>(jsonData);
                List<Pais> paises = new List<Pais>();
                foreach (var paisDto in paisesCiudades.data)
                {
                    Pais pais = new Pais(paisDto.country, paisDto.iso2);
                    foreach (var ciudadNombre in paisDto.cities)
                    {
                        pais.AgregarCiudad(ciudadNombre);
                    }
                    paises.Add(pais);
                    context.Ciudad.AddRange(pais.Ciudades);
                }
                context.Pais.AddRange(paises);
                context.SaveChanges();
            }
        }
    }
}
