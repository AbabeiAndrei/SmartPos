using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            return Ok(_context.Select<Zone>());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
    }
}
