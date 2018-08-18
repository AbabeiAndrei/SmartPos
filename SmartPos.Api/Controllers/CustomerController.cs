using System;
using System.Linq;
using System.Web.Http;

using SmartPos.DomainModel;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Interfaces;
using SmartPos.DomainModel.Model;

namespace Smartpos.Api.Controllers
{
    public class CustomerController : ApiController
    {
        #region Fields

        private readonly IDbContext _context;

        #endregion

        #region Constructors

        public CustomerController()
                : this(new DbContext()) 
        {
        }
        

        public CustomerController(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Overrides of ApiController

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if(disposing)
                _context.Dispose();
        }

        #endregion

        #region Public methods

        public IHttpActionResult Get([FromUri] string name)
        {
            var customers = _context.Select<Customer>().ToList();

            foreach (var customer in customers)
                if (customer.Name == name)
                    return Ok(customer);

            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Save([FromBody] CustomerSaveModel model)
        {
            var customers = _context.Select<Customer>().ToList();

            foreach (var customer in customers)
                if (customer.Name == model.Name)
                {
                    customer.Address = model.Address;
                    _context.Update(customer);
                    return Ok(customer);
                }

            var newCustomer = new Customer
            {
                Name = model.Name,
                Address = model.Address,
                CreatedAt = DateTime.Now,
                CreatedById = model.CreatedBy
            };

            _context.Insert(newCustomer);

            return Ok(newCustomer);
        }

        #endregion
    }
}
