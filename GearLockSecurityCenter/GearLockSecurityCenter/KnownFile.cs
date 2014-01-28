using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GearLockSecurityCenter
{
    [SerializableAttribute]
    public class KnownFile
    {
        public string[] i = new string[2];
        public KnownFile() { }
        public KnownFile(FileInfo file, string rootpath, string currentUser)
        {
            i[0] = TrimPath(file.FullName, rootpath, currentUser);
            i[1] = file.Name;
        }

        private string TrimPath(string path, string rootpath, string currentUser) {

            int last = path.LastIndexOf('\\');
            path = path.Substring(0, last);
            path = path.Replace(rootpath + "\\" + currentUser, "");
            path = path.Replace(rootpath, "");
            return path;
        }
    }
}
