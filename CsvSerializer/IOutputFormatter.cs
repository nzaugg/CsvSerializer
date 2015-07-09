using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvSerializer
{
	public interface IOutputFormatter
	{
		string Convert(object value);
	}
}
