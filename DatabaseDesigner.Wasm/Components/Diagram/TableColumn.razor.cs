using Microsoft.AspNetCore.Components;
using DatabaseDesigner.Core.Models;

namespace DatabaseDesigner.Wasm.Components.Diagram
{
    public partial class TableColumn
    {
        [Parameter]
        public Column Data { get; set; }
    }
}
