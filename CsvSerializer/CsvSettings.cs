using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvSerializer
{
	public class CsvSettings
	{
		/// <summary>The delimeter between each field in a row. Default: ','</summary>
		public string FieldDelimeter { get; set; }
		
		/// <summary>The delimeter used to quote fields in a row. Default: '"'</summary>
		public string QuoteDelimeter { get; set; }
		
		/// <summary>The new line string used at the end of a row. Default: 'CR+LF'</summary>
		public string NewLineDelimeter { get; set; }
		
		/// <summary>Specifies if a header should be generated. Default: 'True'</summary>
		public bool WriteHeaders { get; set; }
		
		/// <summary>Specifies if all fields should be quoted, if it's required or not. Default: 'False'</summary>
		public bool QuoteAllValues { get; set; }
		
		/// <summary>Specifies if CR or LF values should be stripped from field output and replaced with whitespace. Default: 'True'</summary>
		public bool RemoveLineBreaksInFields { get; set; }
		
		/// <summary>Specifies the text encoder that should be used to write values. Default: 'System.Text.UTF8'</summary>
		public Encoding TextEncoding { get; set; }
		
		/// <summary>Specifies if sub-classes should show their parents type as part of their name. E.g. "Person.Address.Line1". Default: 'True'</summary>
		public bool ShowFullNamePath { get; set; }
		
		/// <summary>The delimeter between each part of a path. E.g. "Person.Address.Line1". Default: '.'</summary>
		public string NamePathDelimeter { get; set; }
		
		/// <summary>Specifies if attribute tags like [XmlIgnore] or [XmlElement(Name="value")] should be observed. Default: 'True' </summary>
		public bool UseXmlAttributes { get; set; }
		
		/// <summary>Specifies if attribute tags like [JsonIgnore] or [JsonProperty("value")] should be observed. Default: 'True'</summary>
		public bool UseJsonAttributes { get; set; }
		
		/// <summary>Specifies if attribute tags like [NonSerialized] or [DataMember(Name="value")]</summary>
		public bool UseSerializerAttributes { get; set; }

		/// <summary>
		///		Indicates if a collection is detected as a property on the object to be serialized, the collection will be converted to rows. 
		///		E.g. If there is a Person with 3 addresses, there will be columns for Person.Address1.City, Person.Address2.City, and Person.Address3.City.
		///		Alternativly, the rows in a child collection will cause the parent column values to be repeated or omitted based on the value of the
		///		FlattenHeirarchicalStructuresWithEmptyRows property. Default: 'True'
		/// </summary>
		public bool ConvertChildCollectionsToRows { get; set; }


		/// <summary>
		///		Indicates if a heirarchy of objects should use the parental row values for each of the child rows or if the child rows are surrounded by 
		///		empty values. Default: 'True'
		/// </summary>
		/// <remarks>Note: This property is only active if ConvertChildCollectionsToRows is set to 'True'</remarks>
		public bool FlattenHeirarchicalStructuresWithEmptyRows { get; set; }
		
		public CsvSettings()
		{
			FieldDelimeter = ",";
			QuoteDelimeter = "\"";
			NewLineDelimeter = "\r\n";
			WriteHeaders = true;
			QuoteAllValues = false;
			RemoveLineBreaksInFields = true;
			TextEncoding = Encoding.UTF8;
			ShowFullNamePath = true;
			NamePathDelimeter = ".";
			UseXmlAttributes = true;
			UseJsonAttributes = true;
			UseSerializerAttributes = true;
			ConvertChildCollectionsToRows = true;
			FlattenHeirarchicalStructuresWithEmptyRows = true;
		}
	}
}
