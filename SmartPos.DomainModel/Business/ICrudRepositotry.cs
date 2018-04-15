using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Business
{
    public interface ICrudRepositotry<TEntity>
        where TEntity : Entity
    {
        void Add(TEntity entity);
        void Save(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
    }
}
