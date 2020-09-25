using DatabaseDesigner.Core.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace DatabaseDesigner.Wasm.Components.Diagram
{
    public partial class TableColumn : IDisposable
    {
        [Parameter]
        public Table Table { get; set; }

        [Parameter]
        public Column Column { get; set; }

        public void Dispose()
        {
            Column.Changed -= Column_Changed;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Column.Changed += Column_Changed;
        }

        private void Column_Changed() => StateHasChanged();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
