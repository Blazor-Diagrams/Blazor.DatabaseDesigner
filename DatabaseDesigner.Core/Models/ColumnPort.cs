using Blazor.Diagrams.Core.Models;

namespace DatabaseDesigner.Core.Models
{
    public class ColumnPort : PortModel
    {
        public ColumnPort(NodeModel parent, Column column, PortAlignment alignment = PortAlignment.Bottom)
            : base(parent, alignment, null, null)
        {
            Column = column;
        }

        public Column Column { get; }
    }
}
