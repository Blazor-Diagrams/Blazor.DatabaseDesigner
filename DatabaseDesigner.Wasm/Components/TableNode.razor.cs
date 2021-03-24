using DatabaseDesigner.Core.Models;
using Microsoft.AspNetCore.Components;

namespace DatabaseDesigner.Wasm.Components
{
    public partial class TableNode
    {
        [Parameter]
        public Table Node { get; set; }
    }
}
