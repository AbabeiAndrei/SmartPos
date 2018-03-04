using SmartPos.DomainModel.Entities;
using SmartPos.Ui;

namespace SmartPos.Desktop.Controls.Workspace
{
    public partial class CtrlTable : BaseControl
    {
        public Table Table { get; }

        public CtrlTable(Table table)
        {
            Table = table;
            InitializeComponent();
        }
    }
}
