using System.Linq;
using System.Web.Http;

using SmartPos.DomainModel;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Interfaces;
using SmartPos.DomainModel.Model;

namespace Smartpos.Api.Controllers
{
    public class LayoutController : ApiController
    {
        private readonly IDbContext _context;

        public LayoutController()
            : this(new DbContext()) 
        {
        }

        public LayoutController(IDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var zones = _context.Select<Zone>().ToList();

            foreach (var zone in zones)
            {
                zone.Tables = _context.Where<Table>(t => t.ZoneId == zone.Id);
                foreach(var table in zone.Tables)
                    table.State = GetTableState(table.Id);
            }

            return Ok(zones);
        }

        private TableState GetTableState(int tableId)
        {
            var order = _context.FirstOrDefault<Order>(o => o.TableId == tableId && o.State == OrderState.Active);
            if (order != null)
                return new TableState
                {
                    State = TableOcupation.Ocupied,
                    OcupiedByUser = _context.FirstOrDefault<User>(u => u.Id == order.UserId)?.FullName,
                    OcupiedByUserId = order.UserId
                };

            return new TableState();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
    }
}
