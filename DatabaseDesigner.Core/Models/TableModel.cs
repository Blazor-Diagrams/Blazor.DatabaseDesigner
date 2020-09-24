using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;

namespace DatabaseDesigner.Core.Models
{
    public class TableModel : NodeModel
    {
        private readonly List<Column> _columns;

        public TableModel(Point position = null) : base(position, RenderLayer.HTML)
        {
            _columns = new List<Column>
            {
                new Column
                {
                    Name = "Id",
                    Type = ColumnType.String,
                    Primary = true
                }
            };
        }

        public string Name { get; set; } = "Table";
        public IReadOnlyCollection<Column> Columns => _columns;

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
