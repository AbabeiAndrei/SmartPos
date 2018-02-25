using ServiceStack.DataAnnotations;
using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Entities
{
    public class AccessRight : Entity
    {
        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ControlName { get; set; }
    }
}