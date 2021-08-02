using System;
using System.Collections.Generic;

namespace DotNetFtpSftp
{
    public interface IFileSystem
    {
        bool FileExists(string filePath);
        bool DirectoryExists(string directoryPath);
        void CreateDirectoryIfNotExists(string directoryPath);
        void DeleteFileIfExists(string filePath);
    }

    public interface IRemoteFileSystemContext : IFileSystem, IDisposable 
    {
        bool IsConnected();
        void Connect();
        void Disconnect();


        List<string> FileNames(string directory);
        List<string> FileNames(string directory, string filePrefix, string fileSuffixOrExtension = "");

        void UploadFile(string localFilePath, string remoteFilePath);
        void DownloadFile(string localFilePath, string remoteFilePath);
    }
}