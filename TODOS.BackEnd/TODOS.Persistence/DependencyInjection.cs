﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TODOS.Application.Interfaces;

namespace TODOS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TodosDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<ITodosDbContext>(provider =>
                provider.GetService<TodosDbContext>());
            return services;
        }
    }
}