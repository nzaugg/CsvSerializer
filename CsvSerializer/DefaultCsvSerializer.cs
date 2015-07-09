using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvSerializer
{
	public class DefaultCsvSerializer : ICsvCustomSerializer
	{
		public bool WillSerializeForType(Type type)
		{
			return true; // We're the default
		}

		public IEnumerable<string[]> GetColumnNames()
		{
			throw new NotImplementedException();
		}

		public void SerializeRow(Stream output, CsvSettings settings, object value)
		{
			throw new NotImplementedException();
		}

	}
}
