using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPos.Ui.Components
{
    public partial class AnimationDrawer : Component
    {
        public bool Enabled { get; set; }

        public AnimationDrawer()
        {
            InitializeComponent();
        }

        public AnimationDrawer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void tmrGfx_Tick(object sender, EventArgs e)
        {

        }

        public void Register(Control ctrl, Action<Graphics> drawer)
        {
            
        }
    }
}
