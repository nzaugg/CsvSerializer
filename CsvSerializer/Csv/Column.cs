using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CsvSerializer.Csv
{
	public class Column
	{
		public string Name { get; set; }
		public string ObjectPath { get; set; }
		public int? ObjectIndex { get; set; }
		public PropertyInfo Info { get; set; }
		public IOutputFormatter Formatter { get; set; }
		public ICsvCustomSerializer Serializer { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
