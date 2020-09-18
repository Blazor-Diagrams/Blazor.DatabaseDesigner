using Blazor.Diagrams.Core;
using DatabaseDesigner.Core.Models;
using DatabaseDesigner.Wasm.Components.Diagram;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabaseDesigner.Wasm.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public DiagramManager Diagram { get; } = new DiagramManager(new DiagramOptions
        {
            GridSize = 40
        });

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Diagram.RegisterModelComponent<TableModel, TableNode>();
            Diagram.AddNode(new TableModel());
        }

        private async Task ShowJson()
        {
            var json = JsonSerializer.Serialize(new
            {
                Nodes = Diagram.Nodes.Cast<object>(),
                Links = Diagram.AllLinks.Cast<object>()
            });

            await JSRuntime.InvokeVoidAsync("alert", json);
        }
    }
}
