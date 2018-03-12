using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

using Smartpos.Api.Communication;
using Smartpos.Api.Security;
using SmartPos.DomainModel;
using SmartPos.DomainModel.Business;
using SmartPos.DomainModel.Communication;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Model;
using SmartPos.GeneralLibrary;

namespace Smartpos.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly DbContext _dbContext;

        public OrderController()
            : this(new DbContext())
        {
        }

        private OrderController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IHttpActionResult Get()
        {
            return Ok(true);
        }
        
        public IHttpActionResult Post([FromUri] int tableId)
        {
            var connectionId = Request.Headers.Authorization.Scheme;

            if (string.IsNullOrEmpty(connectionId))
                return Unauthorized(Request.Headers.Authorization);

            if (!AuthenticationCache.Map.ContainsKey(connectionId))
                return Unauthorized(AuthenticationHeaderValue.Parse(connectionId));

            var user = AuthenticationCache.Map[connectionId];
            
            var hub = GlobalHost.ConnectionManager.GetHubContext<PosTransferHub>();
            IClientProxy proxy = hub.Clients.AllExcept(connectionId);
            proxy.Invoke(SignalRHub.Events.Order.RegisterTable,
                         new OrderOpenMessage(connectionId)
                         {
                             TableId = tableId,
                             State = new TableState
                             {
                                OcupiedByUserId = user.Id,
                                OcupiedByUser = user.FullName,
                                State = TableOcupation.Opened
                             }
                         });

            var order = new Order
            {
                State = OrderState.Opened,
                Created = DateTime.Now,
                Number = NumberGenerationFactory.GenerateNumber(_dbContext),
                TableId = tableId,
                UserId = user.Id
            };

            return Ok(order);
        }
    }
}
