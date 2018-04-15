using ServiceStack.DataAnnotations;

using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Metadata;

namespace SmartPos.DomainModel.Entities
{
    public class Product : MetadataEntity<ProductMetadata>, ISoftDeletable
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [CustomField("DECIMAL(10,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [References(typeof(MenuCategory))]
        public int CategoryId { get; set; }

        #region Overrides of MetadataEntity<ProductMetadata>

        /// <inheritdoc />
        public override string Metadata { get; set; }

        #endregion

        #region Implementation of ISoftDeletable

        /// <inheritdoc />
        [Default(typeof(bool), "0")]
        public bool Deleted { get; set; }

        #endregion
    }
}