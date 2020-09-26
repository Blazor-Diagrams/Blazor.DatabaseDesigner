using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseDesigner.Core.Models
{
    public class Table : NodeModel
    {
        private readonly List<Column> _columns;

        public Table(Point position = null) : base(position, RenderLayer.HTML)
        {
            _columns = new List<Column>
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

            AddPort(new ColumnPort(this, _columns[0], PortAlignment.Right));
        }

        public string Name { get; set; } = "Table";
        public IReadOnlyCollection<Column> Columns => _columns;
        public bool HasPrimaryColumn => _columns.Any(c => c.Primary);

        public void AddColumn()
        {
            _columns.Add(new Column
            {
                Name = "Column",
                Type = ColumnType.String,
                Primary = false
            });
            Refresh();
        }
    }
}
