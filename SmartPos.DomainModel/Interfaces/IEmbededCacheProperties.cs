using System.Collections.Generic;

using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Interfaces
{
    public interface IEmbededCacheProperties
    {
        IEnumerable<TEntity> GetValues<TEntity>()
                where TEntity : Entity;
    }
}
