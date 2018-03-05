using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Smartpos.Api.Communication;

namespace Smartpos.Api.Controllers
{
    public class OrderController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(true);
        }
        
        public IHttpActionResult Post([FromUri] string tableId)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<PosTransferHub>();
            hub.Clients.All.test(tableId);

            return Ok();
        }
    }
}
