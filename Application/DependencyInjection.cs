using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TechTime.Inventory.Application.Common.Behaviours;
using FluentValidation;
using Application.Common.Interfaces;
using Application.Operations;
using Application.Dtos;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddScoped<IClientsDAO, ClientsDAO>();
            services.AddScoped<ICreditDAO, CreditDAO>();
            services.AddScoped<IApplicationsDAO, ApplicationsDAO>();

            return services;
        }
    }
}
