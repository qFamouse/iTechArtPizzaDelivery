﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Mapping;
using iTechArtPizzaDelivery.Core.Services;
using iTechArtPizzaDelivery.Infrastructure.Data;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Account;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Components;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Construction;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping;
using iTechArtPizzaDelivery.WebUI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace iTechArtPizzaDelivery.WebUI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile))); // Get Assembly by some class from this assembly
            // services.AddAutoMapper(Assembly.GetAssembly(typeof(PizzaSizeProfile))); // Get Assembly by some class from this assembly

            // Other method using hard brute force
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Single(x => x.FullName.StartsWith("iTechArtPizzaDelivery.Infrastructure")));
        }
        public static void AddCoreDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPizzasService, PizzasService>();
            services.AddScoped<ISizesService, SizesService>();
            services.AddScoped<IIngredientsService, IngredientsService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPromocodeService, PromocodesService>();
            services.AddScoped<IOrderItemService, OrdersItemsService>();
            services.AddScoped<IPizzaConstructionService, PizzaConstructionService>();
            services.AddScoped<IDeliveriesService, DeliveryService>();
            services.AddScoped<IPaymentsService, PaymentService>();
            services.AddScoped<IUsersService, UsersService>();
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPromocodeRepository, PromocodeRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IPizzaSizeRepository, PizzaSizeRepository>();
            services.AddScoped<IPizzaIngredientRepository, PizzaIngredientRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddWebUiDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IIdentityService, IdentityService>();
        }

        public static void AddDbContext(this IServiceCollection services, string sqlServer)
        {
            services.AddDbContext<PizzaDeliveryContext>(options =>
                options.UseSqlServer(sqlServer));
        }


    }
}