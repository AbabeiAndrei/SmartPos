using Newtonsoft.Json;

namespace SmartPos.DomainModel.Base
{
    public abstract class MetadataEntity<T> : Entity
        where T : IMetadata
    {
        private T _metadata;

        public abstract string Metadata { get; set; }

        public T GetMetdata(bool force)
        {
            if (string.IsNullOrWhiteSpace(Metadata))
                return default;

            if (_metadata == null || force)
                _metadata = JsonConvert.DeserializeObject<T>(Metadata);

            return _metadata;
        }
    }
}
