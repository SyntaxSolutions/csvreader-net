using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxSolutions.CsvReader
{
    /// <summary>
    /// A single cell and the value within it.
    /// </summary>
    public class CsvCell
    {
        private string _value; 

        /// <summary>
        /// Gets the cell value
        /// </summary>
        public string Value { 
            get { return this._value; }
        }

        /// <summary>
        /// Create a new CsvCell
        /// </summary>
        /// <param name="value">String value of the cell.</param>
        internal CsvCell(string value)
        {
            this._value = value;
        }
    }
}
