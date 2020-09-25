using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models.Base;
using DatabaseDesigner.Core.Models;
using Microsoft.AspNetCore.Components;
using System;

namespace DatabaseDesigner.Wasm.Components
{
    public partial class Sidebar : IDisposable
    {
        private Table _selectedTable;

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

        private void OnColumnNameChanged(ChangeEventArgs e, Column column)
        {
            column.Name = e.Value.ToString();
            column.Refresh();
        }
    }
}
