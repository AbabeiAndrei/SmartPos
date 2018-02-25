using System.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using SmartPos.DomainModel.Interfaces;

namespace SmartPos.DomainModel
{
    public class DbContext : IDbContext
    {
        public static string DefaultConnectionString { get; set; }

        public IDbConnection Connection { get; }

        public DbContext()
            : this(DefaultConnectionString)
        {
        }
        
        public DbContext(string connectionString)
        {
            var factory = new OrmLiteConnectionFactory(connectionString, new MySqlDialectProvider());
            Connection = factory.Open();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
