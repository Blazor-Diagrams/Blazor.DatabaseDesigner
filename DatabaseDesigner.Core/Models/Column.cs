namespace DatabaseDesigner.Core.Models
{
    public class Column
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public bool Primary { get; set; }
    }

    public enum ColumnType
    {
        Boolean,
        Char,
        String,
        SByte,
        Short,
        Long
    }
}
