using System;
using System.Drawing;

namespace SmartPos.Ui
{
    public static class UiConfigure
    {
        public static Action<Graphics> GraphicsSettingResolver { get; set; }
    }
}
