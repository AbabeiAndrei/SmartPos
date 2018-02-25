using System;
using System.Data;

namespace SmartPos.DomainModel.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}