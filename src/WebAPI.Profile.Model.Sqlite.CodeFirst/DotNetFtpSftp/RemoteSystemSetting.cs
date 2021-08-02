using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DotNetFtpSftp
{
    public class RemoteSystemSetting
    {
        public string Type { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AbsoluteRootDirectory { get; set; }
    }  
}
