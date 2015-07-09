using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvSerializer
{
	public class CsvAttribute : Attribute
	{
		public string Name { get; set; }
		public string NamePrefix { get; set; }
		public IOutputFormatter Formatter { get; set; }
	}
}
