using ServiceStack.DataAnnotations;

namespace SmartPos.DomainModel.Base
{
    public abstract class Entity
    {
        [AutoIncrement]
        public int Id { get; set; }
    }
}
