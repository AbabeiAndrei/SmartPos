using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.Desktop.Communication.Handlers
{
    public delegate void SignalRSubscriptionHandler<in TModel>(TModel model);
    public delegate Task SignalRSubscriptionAsyncHandler<in TModel>(TModel model);
}
