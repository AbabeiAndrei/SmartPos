using System;
using System.Web.Http;
using System.Net.Http.Headers;

using SmartPos.DomainModel;
using Smartpos.Api.Security;
using Smartpos.Api.Extensions;
using SmartPos.DomainModel.Model;
using Smartpos.Api.Communication;

using SmartPos.DomainModel.Business;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Interfaces;

namespace Smartpos.Api.Controllers
{
    public class OrderController : ApiController
    {
        #region Fields

        private readonly IDbContext _dbContext;
        private readonly ICrudRepositotry<Order> _orderRepository;
        private readonly CommunicationHub _hub;
        
        #endregion

        #region Constructors

        public OrderController()
                : this(new DbContext())
        {
        }

        private OrderController(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _orderRepository = new OrderRepository(dbContext);
            _hub = new CommunicationHub();
        }

        #endregion

        #region Public methods

        public IHttpActionResult Get()
        {
            return Ok(true);
        }
        
        [HttpPut]
        public IHttpActionResult OpenTable([FromUri] int tableId)
        {
            var connectionId = Request.GetConnectionId();

            if (string.IsNullOrEmpty(connectionId))
                return Unauthorized(Request.Headers.Authorization);
            
            var user = AuthenticationCache.GetUser(connectionId);

            if (user == null)
                return Unauthorized(AuthenticationHeaderValue.Parse(connectionId));

            var message = new OrderOpenMessage(connectionId)
            {
                    TableId = tableId,
                    State = new TableState
                    {
                        OcupiedByUserId = user.Id,
                        OcupiedByUser = user.FullName,
                        State = TableOcupation.Opened
                    }
            };

            _hub.SendAll(message);

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

        [HttpPost]
        public IHttpActionResult SaveOrder([FromBody] Order order)
        {
            var connectionId = Request.GetConnectionId();

            if (string.IsNullOrEmpty(connectionId))
                return Unauthorized(Request.Headers.Authorization);
            
            var user = AuthenticationCache.GetUser(connectionId);

            if (user == null || order.UserId != user.Id)
                return Unauthorized(AuthenticationHeaderValue.Parse(connectionId));

            if (order.Id == 0)
                _orderRepository.Add(order);
            else
                _orderRepository.Save(order);

            var message = new OrderCreatedMessage(connectionId)
            {
                Order = order
            };
            
            _hub.SendAll(message);

            return Ok(order);
        }

        #endregion
    }
}
