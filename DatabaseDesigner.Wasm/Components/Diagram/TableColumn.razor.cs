using DatabaseDesigner.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace DatabaseDesigner.Wasm.Components.Diagram
{
    public partial class TableColumn
    {
        [Parameter]
        public Column Data { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
