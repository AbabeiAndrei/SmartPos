﻿using System;
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
using SmartPos.DomainModel.Model;
using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.Desktop.Controls.Workspace
{
    [PosAuthorisation]
    public partial class CtrlWorkspace : BaseControl
    {
        #region Fields

        private ITheme _theme;
        private readonly IDictionary<int, IList<CtrlTable>> _zones;
        
        #endregion

        #region Constructors

        public CtrlWorkspace()
        {
            InitializeComponent();
            _zones = new Dictionary<int, IList<CtrlTable>>();
        }
        
        #endregion

        #region Overriedes of BaseControl

        public override void ApplyTheme(ITheme theme)
        {
            base.ApplyTheme(theme);
            _theme = theme;
        }

        #endregion

        #region Public methods

        public async Task Initialize(ApiClient client)
        {
            try
            {
                SuspendLayout();
                foreach (Control ctrl in pnlZones.Controls)
                    ctrl.Dispose();

                pnlZones.Controls.Clear();

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
                var czones = lzones.Select(CreateZoneControl).Cast<Control>().ToArray();

                pnlZones.Controls.AddRange(czones);

                foreach (var zone in lzones)
                {
                    if(!_zones.ContainsKey(zone.Id))
                        _zones.Add(zone.Id, new List<CtrlTable>());

                    _zones[zone.Id].AddRange(zone.Tables?.Select(CreateTableControl) ?? new CtrlTable[0]);
                }

                if(czones.Length >= 1)
                    SelectZone((CtrlWorkspaceZone) czones[0]);
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

        public async Task UpdateTables(ApiClient client)
        {
            var orders = (await client.Order.GetAllActiveOrders()).ToList();

            foreach (var table in _zones.Values.SelectMany(tbls => tbls).Where(t => t.Table != null))
            {
                var order = orders.FirstOrDefault(o => o.TableId == table.Table.Id);
                table.Table.State = order?.Table?.State ?? TableState.Free;
                table.Order = order;
            }
        }

        public CtrlTable GetTable(int tableId)
        {
            return _zones.SelectMany(z => z.Value).FirstOrDefault(t => t.Table.Id == tableId);
        }

        #endregion

        #region Private methods

        private CtrlWorkspaceZone CreateZoneControl(Zone zone)
        {
            var ws = new CtrlWorkspaceZone(zone);
            ws.ApplyTheme(_theme);
            ws.Click += WorkspaceZone_Click;
            return ws;
        }

        private CtrlTable CreateTableControl(Table table)
        {
            var tbl = new CtrlTable(table)
                      {
                              Left = table.Left,
                              Top = table.Top,
                              Width = table.Width,
                              Height = table.Height
                      };
            tbl.ApplyTheme(_theme);
            tbl.Click += WorkspaceZone_Click;
            return tbl;
        }

        private void WorkspaceZone_Click(object sender, EventArgs eventArgs)
        {
            if(!(sender is CtrlWorkspaceZone ctrl))
                return;

            SelectZone(ctrl);
        }

        private void SelectZone(CtrlWorkspaceZone zone)
        {
            try
            {
                pnlZones.SuspendLayout();

                pnlZones.Controls.OfType<CtrlWorkspaceZone>().ForEach(z => z.Selected = false);
                zone.Selected = true;
                ShowTablesForZone(zone.Zone.Id);
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

        #endregion
    }
}
