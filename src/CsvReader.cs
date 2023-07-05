using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace SyntaxSolutions.CsvReader
{
    /// <summary>
    /// Read the CSV data with options.
    /// </summary>
    public class CsvReader
    {
        private CsvRow _headers;

        /// <summary>
        /// Get a CsvRow containing the headers
        /// </summary>
        public CsvRow Headers 
        { 
            get { return this._headers; }
        }

        private List<CsvRow> _rows;
        /// <summary>
        /// Get a list of CsvRow
        /// </summary>
        public ReadOnlyCollection<CsvRow> Rows
        {
            get { return this._rows.AsReadOnly(); }
        }

        /// <summary>
        /// Creates a new CsvReader
        /// </summary>
        /// <param name="filePath">Path to the CSV file.</param>
        /// <param name="hasHeaders">Indicates whether the first row of the CSV file is a header row.</param>
        /// <param name="trimWhiteSpace">Indicates whether leading and trailing white space should be trimmed from each cell value.</param>
        public CsvReader(string filePath = null, bool hasHeaders = true, bool trimWhiteSpace = false)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                this._rows = new List<CsvRow>();

                using (var stream = new StreamReader(filePath))
                {
                    this.loadStream(stream.BaseStream, hasHeaders, trimWhiteSpace);
                }
            }
        }

        /// <summary>
        /// Creates a new CsvReader
        /// </summary>
        /// <param name="stream">Stream containing the CSV data.</param>
        /// <param name="hasHeaders">Indicates whether the first row of the CSV file is a header row.</param>
        /// <param name="trimWhiteSpace">Indicates whether leading and trailing white space should be trimmed from each cell value.</param>
        public CsvReader(Stream stream = null, bool hasHeaders = true, bool trimWhiteSpace = true)
        {
            if (stream != null)
            {
                this._rows = new List<CsvRow>();
                this.loadStream(stream, hasHeaders, trimWhiteSpace);
            }
        }

        /// <summary>
        /// Instaniate the CsvReader object 
        /// </summary>
        /// <param name="stream">Stream containing CSV data.</param>
        /// <param name="hasHeaders">Indicates whether the first row of the CSV file is a header row.</param>
        /// <param name="trimWhiteSpace">Indicates whether leading and trailing white space should be trimmed from each cell value.</param>
        private void loadStream(Stream stream, bool hasHeaders = true, bool trimWhiteSpace = true)
        {
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.TrimWhiteSpace = trimWhiteSpace;
                parser.HasFieldsEnclosedInQuotes = true;
                Int64 index = 0;
                while (!parser.EndOfData)
                {
                    index++;
                    string[] cells = parser.ReadFields();
                    if (index == 1 && hasHeaders)
                    {
                        this._headers = new CsvRow(cells);
                    }
                    else
                    {
                        this._rows.Add(new CsvRow(cells));
                    }
                }
            }
        }
    }
}
