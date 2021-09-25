using System;
using System.IO;

namespace BlazorInputFile
{
    public interface IFileListEntry
    {
        DateTime LastModified { get; }

        string Name { get; }

        long Size { get; }

        string Type { get; }

        string Url { get; }

        bool InData { get; set; }

        string PathInData { get; set; }

        bool IsImporting { get; set; }

        bool IsImported { get; set; }

        bool CanImport { get; set; }

        Stream Data { get; }

        event EventHandler OnDataRead;
    }
}
