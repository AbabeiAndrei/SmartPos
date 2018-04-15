using System.Linq;
using System.Web.Http;

using SmartPos.DomainModel;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Interfaces;

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
                zone.Tables = _context.Where<Table>(t => t.ZoneId == zone.Id);

            return Ok(zones);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
    }
}
