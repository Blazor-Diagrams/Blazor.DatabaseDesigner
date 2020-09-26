using System;

namespace DatabaseDesigner.Core.Models
{
    public class Column
    {
        public event Action Changed;

        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public bool Primary { get; set; }

        public void Refresh() => Changed?.Invoke();
    }

    public enum ColumnType
    {
        Boolean,
        Char,
        String,
        SByte,
        Short,
        Integer,
        Long
    }
}
