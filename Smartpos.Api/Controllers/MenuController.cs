using System.Linq;
using System.Web.Http;
using System.Collections.Generic;

using SmartPos.DomainModel;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Interfaces;
using SmartPos.GeneralLibrary.Extensions;

namespace Smartpos.Api.Controllers
{
    public class MenuController : ApiController
    {
        #region Fields

        private readonly IDbContext _context;

        #endregion

        #region Constructors

        public MenuController()
                : this(new DbContext()) 
        {
        }
        

        public MenuController(IDbContext context)
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

        public IEnumerable<MenuCategory> Get()
        {
            var categories = _context.Select<MenuCategory>().ToList();

            foreach (var category in categories)
                category.Products = _context.Where<Product>(p => p.CategoryId == category.Id).ToList();

            return categories;
        }

        #endregion
    }
}