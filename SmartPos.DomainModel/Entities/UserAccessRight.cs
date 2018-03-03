using ServiceStack.DataAnnotations;

using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Entities
{
    public enum Access : short
    {
        No = 0,
        Yes = 1,
        OnlyHis = 2
    }
    
    public class UserAccessRight : Entity
    {
        [References(typeof(AccessRight))]
        public int AccessRightId { get; set; }
        
        [References(typeof(User))]
        public int UserId { get; set; }
        
        [Required]
        [Default(0)]
        public Access Read { get; set; } 
        
        [Required]
        [Default(0)]
        public Access Create { get; set; }
        
        [Required]
        [Default(0)]
        public Access Update { get; set; }
        
        [Required]
        [Default(0)]
        public Access Delete { get; set; }
        
        [Reference]
        public AccessRight Right { get; set; }

        [Reference]
        public User User { get; set; }
    }
}
