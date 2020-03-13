using Shipment.Data.Contract;
using Shipment.Data.Contract.Base;
using Shipment.Data.Contract.Repositories;
using Shipment.Models;
using Shipment.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Shipment.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnityContainer _container;

        public HomeController(IUnityContainer container)
        {
            _container = container;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var orderService = _container.Resolve<IOrderService>();
            return View(await orderService.LoadOrders());
        }
    }
}