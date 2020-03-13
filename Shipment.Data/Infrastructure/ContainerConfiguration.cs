using Shipment.Data.Contract;
using Shipment.Data.Contract.Repositories;
using Shipment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Shipment.Data.Infrastructure
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes<TLifetime>(IUnityContainer container)
              where TLifetime : LifetimeManager, ITypeLifetimeManager, new()
        {
            container.RegisterType<ShipmentDbContext>(new TransientLifetimeManager(), new InjectionConstructor(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            container.RegisterType<IShipmentDbUnitOfWork, ShipmentDbUnitOfWork>(new TLifetime());

            // repositories
            container.RegisterType<IOrderRepository, OrderRepository>(new TLifetime());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new TLifetime());
            container.RegisterType<IProductRepository, ProductRepository>(new TLifetime());
        }
    }
}
