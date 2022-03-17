﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;
#endregion

namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //within this method, we will register all the services that will be
            //  used by the system (context setup)
            //      and will be provided by the system

            //setup the context service
            services.AddDbContext<WestWindContext>(options);

            //register the service classes

            //add any business logic layer class to the service collection so our
            //  web app has access to the methods (services) within the BLL class

            //the argument for the AddTransient is called a factory
            //basically what you are adding is a localized method
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                //get the dbcontext class that has been registered
                var context = serviceProvider.GetService<WestWindContext>();

                //create an instance of the service class (BuildVersionServices) supplying
                //  the context reference to the service class
                //return the service class instance
                return new BuildVersionServices(context);
            });

            services.AddTransient<RegionServices>((serviceProvider) =>
            {                
                var context = serviceProvider.GetService<WestWindContext>();                               
                return new RegionServices(context);
            });

            services.AddTransient<TerritoryServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();
                return new TerritoryServices(context);
            });
        }
    }
}