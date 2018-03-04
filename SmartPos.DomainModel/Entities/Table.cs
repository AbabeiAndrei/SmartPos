using ServiceStack.DataAnnotations;

using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Metadata;

namespace SmartPos.DomainModel.Entities
{
    public class Table : MetadataEntity<TableMetadata>, ISoftDeletable 
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        
        [Required]
        public int ZoneId { get; set; }
        
        [Required]
        public int Left { get; set; }
        
        [Required]
        public int Top { get; set; }
        
        [Required]
        public int Width { get; set; }
        
        [Required]
        public int Height { get; set; }

        [Default("")]
        public override string Metadata { get; set; }
        
        [Default(typeof(bool), "0")]
        public bool Deleted { get; set; }
    }
}
