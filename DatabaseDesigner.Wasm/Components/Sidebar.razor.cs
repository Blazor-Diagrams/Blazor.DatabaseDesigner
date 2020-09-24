using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models.Base;
using DatabaseDesigner.Core.Models;
using Microsoft.AspNetCore.Components;
using System;

namespace DatabaseDesigner.Wasm.Components
{
    public partial class Sidebar : IDisposable
    {
        private TableModel _selectedTable;

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
            if (model is TableModel tm)
            {
                _selectedTable = selected ? tm : null;
                StateHasChanged();
            }
        }
    }
}
