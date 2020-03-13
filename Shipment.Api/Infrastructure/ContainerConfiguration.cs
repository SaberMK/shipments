using Shipment.Api.Controllers;
using Shipment.Api.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace Shipment.Api.Infrastructure
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes<TLifetime>(IUnityContainer container)
             where TLifetime : LifetimeManager, ITypeLifetimeManager, new()
        {
            Services.Infrastructure.ContainerConfiguration.RegisterTypes<TLifetime>(container);

            container.RegisterType<HomeController>();
            container.RegisterType<OrderController>();
        }
    }
}