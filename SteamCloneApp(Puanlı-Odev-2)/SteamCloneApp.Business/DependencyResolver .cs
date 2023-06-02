﻿using Microsoft.Extensions.DependencyInjection;
using SteamCloneApp.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business
{
    public static class DependencyResolver
    {
        public static void LoadBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthService,AuthService>();
        }
    }
}
