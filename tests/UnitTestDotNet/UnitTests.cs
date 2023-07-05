using Xunit.Abstractions;

using SyntaxSolutions.CsvReader;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace UnitTestDotNet
{
    public class UnitTests
    {
        private readonly ITestOutputHelper output;

        public UnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestBasicHeadersAndRows()
        {
            var reader = new CsvReader(
                filePath: Directory.GetCurrentDirectory() + @"..\..\..\..\..\Shared\TestBasicHeadersAndRows_Expected.csv",
                hasHeaders: true,
                trimWhiteSpace: false
            );

            output.WriteLine("HEADERS");
            foreach (var cell in reader.Headers.Cells)
            {
                output.WriteLine(string.Format("-{0}-", cell.Value));
            }

            int index = 0;
            foreach (var row in reader.Rows)
            {
                index++;
                output.WriteLine("ROW" + index.ToString());
                foreach (var cell in row.Cells)
                {
                    output.WriteLine(string.Format("-{0}-", cell.Value));
                }

            }
        }
    }
}