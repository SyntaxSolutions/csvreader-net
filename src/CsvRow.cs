using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SyntaxSolutions.CsvReader
{
    /// <summary>
    /// A row of cells
    /// </summary>
    public class CsvRow
    {
        private List<CsvCell> _cells;

        /// <summary>
        /// Get a list of CsvCells
        /// </summary>
        public ReadOnlyCollection<CsvCell> Cells
        { 
            get { return this._cells.AsReadOnly(); } 
        }

        /// <summary>
        /// Create a new CsvRow
        /// </summary>
        /// <param name="cells">String array containing the cell values.</param>
        internal CsvRow(string[] cells)
        {
            this._cells = new List<CsvCell>();

            foreach (string cell in cells)
            {
                this._cells.Add(new CsvCell(cell));
            }
        }
    }
}
