using Microsoft.AspNetCore.Components;
using DatabaseDesigner.Core.Models;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace DatabaseDesigner.Wasm.Components.Diagram
{
    public partial class TableColumn
    {
        [Inject]
        public ILogger Logger { get; set; }

        [Parameter]
        public Column Data { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            Logger.LogDebug("OnAfterRenderAsync");
        }
    }
}
