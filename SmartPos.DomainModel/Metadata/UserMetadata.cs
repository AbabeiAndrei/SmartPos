using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Metadata
{
    public class UserMetadata : IMetadata
    {
        public bool IsTemporaryPassword { get; set; }
    }
}
