using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

using SmartPos.Ui;
using SmartPos.Ui.Theming;
using SmartPos.Desktop.Data;
using SmartPos.Desktop.Security;
using SmartPos.DomainModel.Entities;
using SmartPos.Desktop.Communication;
using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.Desktop.Controls.Workspace
{
    [PosAuthorisation]
    public partial class CtrlWorkspace : BaseControl
    {
        private ITheme _theme;
        private IDictionary<int, IList<CtrlTable>> _zones;

        public CtrlWorkspace()
        {
            InitializeComponent();
            _zones = new Dictionary<int, IList<CtrlTable>>();
        }

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            _theme = theme;
        }

        public async Task Initialize(ApiClient client)
        {
            try
            {
                SuspendLayout();

                if(_zones != null)
                {
                    foreach (var tables in _zones.Values)
                    {
                        foreach (var table in tables)
                            table.Dispose();
                        tables.Clear();
                    }
                    _zones.Clear();
                }

                var zones = await client.Layout.GetAllZones();
                var lzones = zones.OrderBy(z => z.Order).ThenBy(z => z.Name).ThenBy(z => z.Id).ToList();

                pnlZones.Controls.AddRange(lzones.Select(CreateZoneControl).Cast<Control>().ToArray());

                foreach (var zone in lzones)
                {
                    if(!_zones.ContainsKey(zone.Id))
                        _zones.Add(zone.Id, new List<CtrlTable>());

                    _zones[zone.Id].AddRange(zone.Tables.Select(CreateTableControl));
                }
            }
            catch (Exception ex)
            {
                GlobalHandler.Catch(ex, ParentForm);
            }
            finally
            {
                ResumeLayout();
            }
        }

        private CtrlWorkspaceZone CreateZoneControl(Zone zone)
        {
            var ws = new CtrlWorkspaceZone(zone);
            ws.ApplyTheme(_theme);
            ws.Click += WorkspaceZone_Click;
            return ws;
        }

        private CtrlTable CreateTableControl(Table table)
        {
            var tbl = new CtrlTable(table);
            tbl.ApplyTheme(_theme);
            tbl.Click += WorkspaceZone_Click;
            return tbl;
        }

        private void WorkspaceZone_Click(object sender, EventArgs eventArgs)
        {
            if(!(sender is CtrlWorkspaceZone ctrl))
                return;
            
            try
            {
                pnlZones.SuspendLayout();

                pnlZones.Controls.OfType<CtrlWorkspaceZone>().Foreach(z => z.Selected = false);
                ctrl.Selected = true;
                ShowTablesForZone(ctrl.Zone.Id);
            }
            finally
            {
                pnlZones.ResumeLayout();
            }

        }

        private void ShowTablesForZone(int zoneId)
        {
            try
            {
                pnlTables.SuspendLayout();

                pnlTables.Controls.Clear();

                if(_zones.ContainsKey(zoneId))
                    pnlTables.Controls.AddRange(_zones[zoneId].Cast<Control>().ToArray());
            }
            finally 
            {
                pnlTables.ResumeLayout();
            }
        }
    }
}
