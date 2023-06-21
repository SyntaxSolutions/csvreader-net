using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyntaxSolutions.CsvReader;

namespace csvreader_net_tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestBasicHeadersAndRows()
        {
            var reader = new CsvReader(
                filePath: "TestBasicHeadersAndRows_Expected.csv",
                hasHeaders: true,
                trimWhiteSpace: true
            );

            Console.WriteLine("HEADERS");
            foreach (var cell in reader.Headers.Cells)
            {
                Console.WriteLine(string.Format("-{0}-", cell.Value));
            }

            Console.WriteLine("ROWS");
            foreach (var row in reader.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    Console.WriteLine(string.Format("-{0}-", cell.Value));
                }

            }
        }
    }
}
