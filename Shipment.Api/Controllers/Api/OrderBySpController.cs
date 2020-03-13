using Newtonsoft.Json;
using Shipment.Services.Contract;
using Shipment.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Unity;


namespace Shipment.Api.Controllers.Api
{
    [Route("orders-sp")]
    public class OrderBySpController : ApiController
    {
        private readonly IUnityContainer _container;

        public OrderBySpController(IUnityContainer container)
        {
            _container = container;
        }

        [HttpPost]
        public async Task<string> Group(IEnumerable<int> model)
        {
            var shipmentService = _container.Resolve<IShipmentService>();

            var result = await shipmentService.GetShipmentsBySP(model);

            return result.Replace("\\\"", "\"");
        }

    }
}