using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFtpSftp
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteSystemSetting setting = new RemoteSystemSetting()
            {
                Type = "Ftp",           /*for sftp use "Sftp" and for ftp use "Ftp"*/
                Host = "xx.xx.xx.xx",   /*host ip*/
                Port = 21,              /*ftp:21, sftp:22*/
                UserName = "xyz",
                Password = "abc"
            };

            IRemoteFileSystemContext remote = new FtpSftpFileContext(setting);

            remote.Connect();                                       /*establish connection*/
            remote.DownloadFile("C:\\1.txt", "/test/1.txt");        /*download file*/
            remote.UploadFile("C:\\2.txt", "/test/2.txt");          /*upload upload file*/
            List<string> files = remote.FileNames("/test/");        /*file names*/
            files = remote.FileNames("/test/",  "1", ".txt");       /*search file with prefix, suffix*/

            /*others*/
            bool value;
            value = remote.IsConnected();                           /*check connection done or not*/
            value = remote.DirectoryExists("/test/");               /*check if directory exists or not*/
            remote.CreateDirectoryIfNotExists("/test/lol/");        /*create directory*/
            value = remote.FileExists("/files/test/1.txt");         /*check if file exists or not*/
            remote.DeleteFileIfExists("/test/2.txt");               /*delete file*/
            remote.Disconnect();                                    /*stop connection*/
            remote.Dispose();                                       /*dispose*/

            /*we don't have, but going to add some*/
            /*get all directory name*/
            /*download all files*/
            /*upload all files*/


            Console.WriteLine("Hello World!");
        }
    }
}
