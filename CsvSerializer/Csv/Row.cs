using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvSerializer.Csv
{
	public class Row
	{
		public int RowNumber { get; internal set; }
		public IList<Cell> Values { get; protected set; }
		
		public string this[int columnIndex]
		{
			get { return Values[columnIndex].Value; }
			set { Values[columnIndex].Value = value; }
		} 

		public string this[Column column]
		{
			get { return Values.Single(n => n.Column == column).Value; }
			set { Values.Single(n => n.Column == column).Value = value; }
		}

		public Row(IEnumerable<Column> columns)
		{
			Values = columns.Select(n => new Cell { Column = n }).ToList();
		}

		public Row Clone()
		{
			var result = new Row(Values.Select(n => n.Column));
			foreach (var values in Values)
				result[values.Column] = values.Value;

			return result;
		}
	}
}
