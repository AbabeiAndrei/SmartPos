using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using SmartPos.DomainModel;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Security;

namespace Smartpos.Api
{
    public static class DbConfig
    {
        public static void Config()
        {
            DbContext.DefaultConnectionString = WebConfigurationManager.AppSettings["Connection"];
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