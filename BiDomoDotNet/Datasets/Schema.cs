using System;
using System.Collections.Generic;
using System.Text;

namespace BuildIntelligence.Domo.Sdk.Datasets
{
	public class Schema
	{
        public Schema() { }

        /// <summary>
        /// Construct Schema from Dictionary of column names and types
        /// </summary>
        /// <param name="columns">string key for column name, and column type for value</param>
        public Schema(IDictionary<string,DomoDataType> columns)
        {
            foreach(var col in columns)
            {
                Columns.Add(new Column(col.Key, col.Value));
            }
        }
		public List<Column> Columns { get; set; }
	}

	public class Column
	{
        public Column() { }
        public Column(string columnName, DomoDataType type)
        {
            this.Name = columnName;
            this.Type = type.ToString();
        }
		public string Type { get; set; }
		public string Name { get; set; }
	}

    public enum DomoDataType
    {
        STRING,
        LONG,
        DECIMAL,
        DOUBLE,
        DATETIME,
        DATE
    }
}
