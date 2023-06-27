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
                trimWhiteSpace: false
            );

            Console.WriteLine("HEADERS");
            foreach (var cell in reader.Headers.Cells)
            {
                Console.WriteLine(string.Format("-{0}-", cell.Value));
            }

            int index = 0;
            foreach (var row in reader.Rows)
            {
                index++;
                Console.WriteLine("ROW" + index.ToString());
                foreach (var cell in row.Cells)
                {
                    Console.WriteLine(string.Format("-{0}-", cell.Value));
                }

            }
        }
    }
}
