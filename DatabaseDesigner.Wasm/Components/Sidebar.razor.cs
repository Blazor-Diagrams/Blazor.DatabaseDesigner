using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using DatabaseDesigner.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace DatabaseDesigner.Wasm.Components
{
    public partial class Sidebar : IDisposable
    {
        private Table _selectedTable;
        private Column _selectedColumn;

        [CascadingParameter(Name = "DiagramManager")]
        public DiagramManager Diagram { get; set; }

        public void Dispose()
        {
            Diagram.SelectionChanged -= Diagram_SelectionChanged;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Diagram.SelectionChanged += Diagram_SelectionChanged;
        }

        private void Diagram_SelectionChanged(SelectableModel model, bool selected)
        {
            if (model is Table tm)
            {
                _selectedTable = selected ? tm : null;
                _selectedColumn = null;
                StateHasChanged();
            }
        }

        private void OnTableNameChanged(ChangeEventArgs e)
        {
            if (_selectedTable == null)
                return;

            _selectedTable.Name = e.Value.ToString();
            _selectedTable.Refresh();
        }

        private void OnAddBtnClicked(MouseEventArgs e)
        {
            var column = new Column
            {
                Name = "Column",
                Type = ColumnType.String
            };

            _selectedTable.Columns.Add(column);
            _selectedTable.AddPort(column, PortAlignment.Left);
            _selectedTable.Refresh();
        }

        private void OnDeleteBtnClicked(MouseEventArgs e)
        {
            if (_selectedColumn == null || _selectedColumn.Primary)
                return;

            _selectedTable.RemovePort(_selectedTable.GetPort(_selectedColumn));
            _selectedTable.Columns.Remove(_selectedColumn);
            _selectedTable.Refresh();
        }

        private static void OnColumnNameChanged(ChangeEventArgs e, Column column)
        {
            column.Name = e.Value.ToString();
            column.Refresh();
        }

        private static void OnColumnTypeChanged(ChangeEventArgs e, Column column)
        {
            column.Type = Enum.Parse<ColumnType>(e.Value.ToString());
            column.Refresh();
        }

        private void SelectColumn(Column column) => _selectedColumn = column;
    }
}
