using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseDesigner.Core.Models
{
    public class Table : NodeModel
    {
        public Table(Point position = null) : base(position, RenderLayer.HTML)
        {
            Columns = new List<Column>
            {
                new Column
                {
                    Name = "Id",
                    Type = ColumnType.Integer,
                    Primary = true
                },
                new Column
                {
                    Name = "Sefihubqsd",
                    Type = ColumnType.Boolean
                }
            };

            AddPort(new ColumnPort(this, Columns[0], PortAlignment.Right));
        }

        public string Name { get; set; } = "Table";
        public List<Column> Columns { get; }
        public bool HasPrimaryColumn => Columns.Any(c => c.Primary);
    }
}
