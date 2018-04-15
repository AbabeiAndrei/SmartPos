using System;

using ServiceStack.DataAnnotations;

namespace SmartPos.DomainModel.Base
{
    public abstract class Entity
    {
        #region Properties

        [AutoIncrement]
        public int Id { get; set; }

        [Ignore]
        public Guid ObiectId { get; }

        #endregion

        #region Constructors

        protected Entity()
        {
            ObiectId = Guid.NewGuid();
        }

        #endregion
    }
}
