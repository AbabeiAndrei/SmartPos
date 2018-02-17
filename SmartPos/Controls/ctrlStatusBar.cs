using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartPos.Ui;
using SmartPos.Desktop.Security;

namespace SmartPos.Desktop.Controls
{
    [PosAuthorisation]
    public partial class ctrlStatusBar : BaseControl
    {
        public ctrlStatusBar()
        {
            InitializeComponent();
        }
    }
}
