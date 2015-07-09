using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvSerializer
{
	internal static class Extensions
	{
		internal static object GetObjectAtIndex(this IEnumerable value, int index)
		{
			int i = 0;
			var it = value.GetEnumerator();
			while (it.MoveNext())
				if (++i == index)
					return it.Current;

			return null;
		}
	}
}
