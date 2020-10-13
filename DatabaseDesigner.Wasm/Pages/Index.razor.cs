using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models;
using DatabaseDesigner.Core.Models;
using DatabaseDesigner.Wasm.Components.Diagram;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatabaseDesigner.Wasm.Pages
{
    public partial class Index : IDisposable
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public DiagramManager Diagram { get; } = new DiagramManager(new DiagramOptions
        {
            GridSize = 40,
            AllowMultiSelection = false
        });

        public void Dispose()
        {
            Diagram.LinkAttached -= Diagram_LinkAttached;
            Diagram.LinkRemoved -= Diagram_LinkRemoved;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Diagram.RegisterModelComponent<Table, TableNode>();
            Diagram.AddNode(new Table());

            Diagram.LinkAttached += Diagram_LinkAttached;
            Diagram.LinkRemoved += Diagram_LinkRemoved;
        }

        private void Diagram_LinkAttached(LinkModel link)
        {
            var sourceCol = (link.SourcePort as ColumnPort).Column;
            var targetCol = (link.TargetPort as ColumnPort).Column;
            (sourceCol.Primary ? targetCol : sourceCol).Refresh();
        }

        private void Diagram_LinkRemoved(LinkModel link)
        {
            if (!link.IsAttached)
                return;

            var sourceCol = (link.SourcePort as ColumnPort).Column;
            var targetCol = (link.TargetPort as ColumnPort).Column;
            (sourceCol.Primary ? targetCol : sourceCol).Refresh();
        }

        private void NewTable()
        {
            Diagram.AddNode(new Table());
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

        private void Debug()
        {
            Console.WriteLine(Diagram.Container);
            foreach (var port in Diagram.Nodes.ToList()[0].Ports)
                Console.WriteLine(port.Position);
        }
    }
}
