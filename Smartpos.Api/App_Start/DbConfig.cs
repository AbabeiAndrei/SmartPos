using System;

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
            DbContext.DefaultConnectionString = "Server=smartpos-api-qa-mysqldbserver.mysql.database.azure.com;Database=smartpos;Uid=mysqldbuser@smartpos-api-qa-mysqldbserver;Pwd=Mcncc.comh112?;";
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