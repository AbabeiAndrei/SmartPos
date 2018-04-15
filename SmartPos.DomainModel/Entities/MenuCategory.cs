using System.Collections.Generic;

using ServiceStack.DataAnnotations;

using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Entities
{
    public class MenuCategory : Entity, ISoftDeletable
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [References(typeof(MenuCategory))]
        public int? ParentId { get; set; }

        #region Implementation of ISoftDeletable

        /// <inheritdoc />
        [Default(typeof(bool), "0")]
        public bool Deleted { get; set; }

        #endregion
        
        [Ignore]
        public IEnumerable<MenuCategory> Items { get; set; }

        [Ignore]
        public IEnumerable<Product> Products { get; set; }
    }
}