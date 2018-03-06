using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartPos.GeneralLibrary;

namespace Smartpos.Api.Security
{
    public static class AuthenticationCache
    {
        public static IDictionary<string, IIdentity> Map { get; }

        static AuthenticationCache()
        {
            Map = new ConcurrentDictionary<string, IIdentity>();
        }
    }
}