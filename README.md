# CSV Reader for .Net
A simple .Net library used to read comma-separated values (CSV) from a file or data stream.

## Features

1. RFC 4180 standard compliant 
1. UTF-8 encoding compatible. 

## Installation

```sh
PM> Install-Package SyntaxSolutions.CsvReader
```

## Example

```c#
using SyntaxSolutions.CsvReader;

var reader = new CsvReader(
    filePath: "data.csv",
    hasHeaders: true,
    trimWhiteSpace: true
);

foreach (var cell in reader.Headers.Cells)
{
    Console.WriteLine(string.Format("{0}", cell.Value));
}

foreach (var row in reader.Rows)
{
    foreach (var cell in row.Cells)
    {
        Console.WriteLine(string.Format("{0}", cell.Value));
    }
}
```