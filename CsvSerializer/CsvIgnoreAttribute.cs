using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvSerializer
{
	/// <summary>Ignore a property for serialization. 
	///		Note: The following serialization attributes also work:
	///			[NonSerialized], [XmlIgnore], [JsonIgnore]
	/// </summary>
	public class CsvIgnoreAttribute : Attribute
	{
	}
}
