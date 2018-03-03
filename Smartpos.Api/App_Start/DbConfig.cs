using SmartPos.DomainModel;
using System.Web.Configuration;
using SmartPos.DomainModel.Security;

namespace Smartpos.Api
{
    public static class DbConfig
    {
        public static void Config()
        {
#if DEBUG
            DbContext.DefaultConnectionString = WebConfigurationManager.AppSettings["Connection"];
#else
            DbContext.DefaultConnectionString = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb");

            if(string.IsNullOrWhiteSpace(DbContext.DefaultConnectionString))
                throw new Exception("MYSQLCONNSTR_localdb variable is null or empty");
#endif

            //DbContext.DefaultConnectionString = "Server=127.0.0.1:56441;Database=localdb;Uid=azure;Pwd=6#vWHD_$;";
                                            
            using (var ctx = new DbContext())
            {
                var hasher = new UserPasswordHasher();
                var seeder = new DbSeeder(ctx, hasher);

                seeder.Build();
                if(seeder.NeedSeed)
                    seeder.Seed();
            }
        }
    }
}