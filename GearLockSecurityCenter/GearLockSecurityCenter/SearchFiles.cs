using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using GearLockSecurityCenter;
namespace GearLockSecurityCenter
{
    class FileSearcher
    {
        private List<KnownFile> knownFiles = new List<KnownFile>();
        public delegate void LineWriter(string line);

        public void SearchFiles(string rootPath, string dumpPath, string excludeUser, LineWriter output, bool include)
        {
            knownFiles = new List<KnownFile>();
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            this.rootPath = rootPath;
            dir.GetFiles().ForEach((f) => ProcessFile(f));
            if (include)
            {
                output("Searching the User: " + excludeUser);
                SearchDir(dir.GetDirectories().Where((d) => d.Name.Equals(excludeUser)).ElementAt(0));
            }
            else
            {
                dir.GetDirectories().ForEach((d) =>
                {
                    if (!d.Name.Equals(excludeUser))
                    {
                        output("Searching User: " + d.Name);
                        SearchDir(d);
                    }
                    else
                    {
                        output("Skiping User: " + d.Name);
                    }
                });

                output("File Search Complete");

            }
        }

        public void SearchDir(DirectoryInfo dir)
        {
            try
            {
                dir.GetFiles().ForEach((f) => ProcessFile(f));
                dir.GetDirectories().ForEach((d) => SearchDir(d));
            }
            catch (Exception ex)
            {
            }
        }
        string rootPath, dumpPath, execludeUser;
        private void ProcessFile(FileInfo file)
        {
            try
            {
                CheckFiles(file);
                knownFiles.Add(new KnownFile(file, rootPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private bool CheckFiles(FileInfo file)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
            }
            return true;
        }
    }
}
