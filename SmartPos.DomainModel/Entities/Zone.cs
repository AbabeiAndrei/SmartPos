using System.Collections.Generic;

using ServiceStack.DataAnnotations;

using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Interfaces;
using SmartPos.DomainModel.Metadata;

namespace SmartPos.DomainModel.Entities
{
    public class Zone : MetadataEntity<ZoneMetadata>, ISoftDeletable, IEmbededCacheProperties
    {
        #region Properties

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Default(0)]
        public int Order { get; set; }

        [Default("")]
        public override string Metadata { get; set; }
        
        [Default(typeof(bool), "0")]
        public bool Deleted { get; set; }
        
        [Reference]
        public IEnumerable<Table> Tables { get; set; }

        #endregion

        #region Implementation of IEmbededCacheProperties

        /// <inheritdoc />
        public IEnumerable<TEntity> GetValues<TEntity>()
                where TEntity : Entity
        {
            return (IEnumerable<TEntity>) Tables;
        }

        #endregion
    }
}
