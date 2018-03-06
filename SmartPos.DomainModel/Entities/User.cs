using System;
using System.Collections.Generic;

using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

using SmartPos.GeneralLibrary;
using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Metadata;

namespace SmartPos.DomainModel.Entities
{
    public enum UserRank : short
    {
        Regular = 0,
        Manager = 1,
        Administrator = 2
    }

    public class User : MetadataEntity<UserMetadata>, IIdentity, ISoftDeletable
    {
        [Required]
        [StringLength(128)]
        public string FullName { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Pin { get; set; }
        
        [Default(0)]
        public UserRank Access { get; set; }

        [Default(OrmLiteVariables.SystemUtc)]
        public DateTime CreatedAt { get; set; }
        
        [Default(typeof(bool), "0")]
        public bool Suspended { get; set; }

        [Default("")]
        public override string Metadata { get; set; }

        [Default(typeof(bool), "0")]
        public bool Deleted { get; set; }
        
        [Reference]
        public IEnumerable<UserAccessRight> Rights { get; set; }

        [Ignore]
        public string ConnectionId { get; set; }


    }
}
