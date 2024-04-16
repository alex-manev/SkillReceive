﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Contracts.OnlineCourse;
using SkillReceive.Core.Services.Creator;
using SkillReceive.Core.Services.OnlineCourse;
using SkillReceive.Core.Services.Skill;
using SkillReceive.Infrastructure.Data;
using SkillReceive.Infrastructure.Data.Common;
using SkillReceive.Core.Contracts.OnHandExperience;
using SkillReceive.Core.Services.OnHandExperience;
using SkillReceive.Core.Contracts;
using SkillReceive.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICreatorService, CreatorService>();
            services.AddScoped<IOnlineCourseService, OnlineCourseService>();
            services.AddScoped<IOnHandService, OnHandService>();
            services.AddScoped<IStatisticService, StatisticService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContex(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<SkillReceiveDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(
                options => 
                {

                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                }
                )
    .AddEntityFrameworkStores<SkillReceiveDbContext>();

            return services;
        }
    }
}
