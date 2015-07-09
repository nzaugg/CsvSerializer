using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvSerializer.Csv
{
	public class CsvBuilder : IDisposable
	{
		protected TextWriter Writer;
		protected int RowCount;

		protected IList<Column> ColumnsList;
		protected IList<Row> RowsList;

		public CsvSettings Settings { get; set; }
		public Stream Output { get; set; }

		public IEnumerable<Column> Columns { get { return ColumnsList; } }
		public IEnumerable<Row> Rows { get { return RowsList; } }


		public string this[int row, int column]
		{
			get { return RowsList[row][column]; }
			set { RowsList[row][column] = value; }
		}

		public CsvBuilder()
		{
			ColumnsList = new List<Column>();
			RowsList = new List<Row>();
		}

		public CsvBuilder(CsvSettings settings, Stream output) : this()
		{
			Settings = settings;
			Output = output;
		}

		public void AddColumn(Column value)
		{
			if (value == null)
				throw new ArgumentNullException("value");

			if (RowCount > 0)
				throw new InvalidOperationException("Unable to add new columns once rows have been created.");

			ColumnsList.Add(value);
		}

		public void AddColumns(IEnumerable<Column> values)
		{
			foreach (var value in values)
				AddColumn(value);
		}

		public Row AddRow()
		{
			var row = new Row(Columns);
			RowsList.Add(row);
			row.RowNumber = ++RowCount;
			WriteExtraRows();
			return row;
		}

		public void DuplicateLastRow()
		{
			if (RowsList.Count == 0)
				throw new InvalidOperationException("There are no rows available to duplicate.");

			var dup = RowsList[RowsList.Count - 1].Clone();
			RowsList.Add(dup);
			dup.RowNumber = RowsList.Count;
		}

		/// <summary>Closes the rows and flushes the stream</summary>
		public void Close()
		{
			// Write all remaining rows
			foreach (var row in RowsList)
				WriteRow(row);

			Writer.Dispose();
		}

		public void Dispose()
		{
			Close();
			GC.SuppressFinalize(this);
		}

		~CsvBuilder()
		{
			Dispose();
		}

		private void WriteExtraRows()
		{
			if (RowCount < 1)
				return;
			
			// Write the oldest rows and remove them from the collection. Leave at least 1 row.
			var removeList = new List<Row>();
			for(int index = 0; index < RowsList.Count - 2; index++ )
			{
				var row = RowsList[index];
				WriteRow(row);
				removeList.Add(row);
			}

			foreach (var row in removeList)
				RowsList.Remove(row);
		}

		private void WriteRow(Row row)
		{
			if (Writer == null)
			{
				Writer = new StreamWriter(Output, Settings.TextEncoding);
				if (Settings.WriteHeaders)
					WriteHeader();
			}

			bool firstCol = true;
			foreach (var cell in row.Values)
			{
				// Write the Delimeter (if needed)
				Writer.Write(firstCol ? string.Empty : Settings.FieldDelimeter);
				firstCol = false;

				Writer.Write(GetWritableFieldValue(cell));
			}
			Writer.Write(Settings.NewLineDelimeter);
		}

		private void WriteHeader()
		{
			bool firstCol = true;
			foreach (var col in Columns)
			{
				if (!firstCol)
					Writer.Write(Settings.FieldDelimeter);
				else
					firstCol = false;

				Writer.Write(FormatValueString(col.Name));
			}

			Writer.Write(Settings.NewLineDelimeter);
		}

		private string GetWritableFieldValue(Cell cell)
		{
			// TODO: Don't forget about the formatters
			string value = cell.Value.ToString();
			return FormatValueString(value);
		}

		private string FormatValueString(string value)
		{
			if (Settings.RemoveLineBreaksInFields)
				value = value.Replace("\r", "").Replace("\n", " ");

			bool quote = (Settings.QuoteAllValues || NeedsQuoting(value));

			if (quote)
				value = Settings.QuoteDelimeter + value.Replace(Settings.QuoteDelimeter, Settings.QuoteDelimeter + Settings.QuoteDelimeter) + Settings.QuoteDelimeter;

			return value;
		}

		private bool NeedsQuoting(string value)
		{
			return (value.Contains(",") || value.Contains("\r") || value.Contains("\n") || value.Contains("\""));
		}

	}
}
