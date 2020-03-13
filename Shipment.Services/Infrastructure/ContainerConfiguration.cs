using Shipment.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Shipment.Services.Infrastructure
{
    public static class ContainerConfiguration
    {
        public static void RegisterTypes<TLifetime>(IUnityContainer container)
               where TLifetime : LifetimeManager, ITypeLifetimeManager, new()
        {
            Shipment.Data.Infrastructure.ContainerConfiguration.RegisterTypes<TLifetime>(container);

            // services
            container.RegisterType<IShipmentService, ShipmentService>(new TLifetime());
            container.RegisterType<IOrderService, OrderService>(new TLifetime());
        }
    }
}
