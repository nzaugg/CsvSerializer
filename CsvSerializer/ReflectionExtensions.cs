using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CsvSerializer
{
	internal static class ReflectionExtensions
	{
		internal static IEnumerable<PropertyInfo> Properties(this object target)
		{
			// Public, NonStatic properties
			return target.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
		}

		internal static string TypeName(this object target)
		{
			return target.GetType().Name;
		}
	}
}
