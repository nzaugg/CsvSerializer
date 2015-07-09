using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvSerializer
{
	public interface ICsvCustomSerializer
	{
		/// <summary>
		/// Indicates if this serializer is able to serialize for the given type.
		/// </summary>
		/// <param name="type">The type of object needing to be serialized</param>
		/// <returns>true if serialization is provided for the given type</returns>
		bool WillSerializeForType(Type type);

		/// <summary>
		/// Gets the column names for all of the columns. Names should not yet be joined. E.g. "new[]{"Person", "Address", "Street"}" for Person.Address.Street. 
		/// </summary>
		/// <returns>Enumerable of Name Parts</returns>
		IEnumerable<string[]> GetColumnNames();

		/// <summary>
		/// Custom Serialize a row (no newline)
		/// </summary>
		/// <param name="output">Output stream</param>
		/// <param name="value">Vaue to serialize</param>
		void SerializeRow(Stream output, CsvSettings settings, object value);
	}
}
