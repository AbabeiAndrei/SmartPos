using System;

using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;

using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Business.Invoicing;

namespace SmartPos.DomainModel.Entities
{
    public class Customer : Entity, ISoftDeletable, IInvoiceCustomer
    {
        [Required]
        [References(typeof(User))]
        public int CreatedById { get; set; }
        
        [Required]
        [Default(OrmLiteVariables.SystemUtc)]
        public DateTime CreatedAt { get; set; }

        #region Implementation of IInvoiceCustomer

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        public string Address { get; set; }

        #endregion

        #region Implementation of ISoftDeletable

        /// <inheritdoc />
        public bool Deleted { get; set; }

        #endregion
    }
}
