using DatabaseDesigner.Core.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace DatabaseDesigner.Wasm.Components.Diagram
{
    public partial class TableColumn : IDisposable
    {
        private bool _shouldRender = true;

        [Parameter]
        public Table Table { get; set; }

        [Parameter]
        public Column Column { get; set; }

        public bool HasLinks => Table.GetPort(Column)?.Links.Count > 0;

        public void Dispose()
        {
            Column.Changed -= ReRender;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Column.Changed += ReRender;
        }

        protected override bool ShouldRender() => _shouldRender;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            _shouldRender = false;
            await base.OnAfterRenderAsync(firstRender);
        }

        private void ReRender()
        {
            _shouldRender = true;
            StateHasChanged();
        }
    }
}
