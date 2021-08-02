using System;
using System.Collections.Generic;
using System.Linq;
using WinSCP;

namespace DotNetFtpSftp
{

    /*winscp example
     * https://winscp.net/eng/docs/library_examples
     * Local Directory:         C:\DumpFiles\file.csv (C:\\DumpFiles\\file.csv)
     * Ftp Directory(WinScp):   /ArchiveFiles/file.csv
     */
    public class RemoteFileSystemRepository : IRemoteFileSystemRepository
    {
        public SessionOptions SessionOptions { get; }

        private Session _session;

        public RemoteFileSystemRepository(RemoteSystemSetting setting)
        {
            string protocolType = setting.Type;
            SessionOptions = new SessionOptions
            {
                HostName = setting.Host,
                UserName = setting.UserName,
                Password = setting.Password,
                PortNumber = setting.Port,
                Protocol = (Protocol) Enum.Parse(typeof(Protocol), protocolType),
            };
            if (new List<Protocol>(){ Protocol.Sftp }.Contains(SessionOptions.Protocol))
            {
                SessionOptions.GiveUpSecurityAndAcceptAnySshHostKey = true;
            }
        }

        public void Connect()
        {
            _session = new Session();
            _session.Open(SessionOptions);
        }

        public List<string> FileNames(string directory)
        {
            var files = _session.EnumerateRemoteFiles(directory, "", EnumerationOptions.None).ToList();
            return files.Select(x => x.Name).ToList();
        }

        public List<string> FileNames(string directory, string filePrefix, string fileSuffixOrExtension = "")
        {
            /*https://winscp.net/eng/docs/file_mask*/
            string mask = filePrefix + "*" + fileSuffixOrExtension;
            var files = _session.EnumerateRemoteFiles(directory, mask, EnumerationOptions.None).ToList();
            return files.Select(x => x.Name).ToList();
        }

        public bool IsConnected()
        {
            var value = _session == null ? false : _session.Opened;
            return value;
        }

        public void Disconnect()
        {
            _session.Close();
        }


        public void UploadFile(string localFilePath, string remoteFilePath)
        {
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;
            TransferOperationResult transferResult = _session.PutFiles(localFilePath, remoteFilePath, false, transferOptions);
            transferResult.Check();
        }

        public void DownloadFile(string localFilePath, string remoteFilePath)
        {
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;
            TransferOperationResult transferResult = _session.GetFiles(remoteFilePath, localFilePath, false, transferOptions);
            transferResult.Check();
        }

        public bool FileExists(string filePath)
        {
            bool has = _session.FileExists(filePath);
            return has;
        }

        public bool DirectoryExists(string directoryPath)
        {
            bool has = _session.FileExists(directoryPath);
            return has;
        }

        public void CreateDirectoryIfNotExists(string directoryPath)
        {
            if (!DirectoryExists(directoryPath))
            {
                _session.CreateDirectory(directoryPath);
            }
        }

        public void DeleteFileIfExists(string filePath)
        {
            if (DirectoryExists(filePath))
            {
                _session.RemoveFile(filePath);
            }
        }

        public void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
            }
        }
    }
}
