using System.Web.Http;
using System.Threading;

using SmartPos.DomainModel;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Interfaces;

namespace Smartpos.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IDbContext _context;

        public AccountController()
            : this(new DbContext()) 
        {
        }

        public AccountController(IDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IHttpActionResult Login([FromUri] string pin)
        {
            if (string.IsNullOrWhiteSpace(pin))
                return BadRequest("No pin provided");
            
            var user = _context.FirstOrDefault<User>(u => u.Pin == pin);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
    }
}
