using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GearLockSecurityCenter
{
    class KnownFile
    {
        private string RelativePath { get; set; }

        public KnownFile(FileInfo file, string rootpath)
        {
            Console.WriteLine(file.FullName);
            RelativePath = TrimPath(file.FullName, rootpath);
            //var reader = file.OpenRead().BeginRead(Data, 0, 20, new System.AsyncCallback(callback), null);
            Console.WriteLine(RelativePath);
        }

        public void callback(IAsyncResult result)
        {
            Console.WriteLine(result);

        }

        private string TrimPath(string path, string rootpath) {

            int last = path.LastIndexOf('\\');
            path = path.Substring(0, last);
            path = path.Replace(rootpath, "");
            return path;
        }
    }
}
