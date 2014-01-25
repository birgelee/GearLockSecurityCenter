using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GearLockSecurityCenter;
namespace GearLockSecurityCenter
{
    class FileSearcher
    {
        List<string> filesFound = new List<string>();
        public void SearchFiles(string rootPath, string dumpPath, string excludeUser)
        {
            this.rootPath = rootPath;
            this.dumpPath = dumpPath;
            this.execludeUser = excludeUser;
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            
            dir.GetFiles().ForEach((f) => ProcessFile(f));
            foreach (DirectoryInfo user in dir.GetDirectories())
            {
                IEnumerable<string> files = GetFiles(user.FullName);
                files.ForEach((f) => { ProcessFile(new FileInfo(f)); });


            }

            Console.WriteLine(filesFound);
        }
        string rootPath, dumpPath, execludeUser;
        public void ProcessFile(FileInfo file)
        {
            if (!checkFile(file))
            {
                filesFound.Add(file.Name);
                //file.CopyTo(dumpPath +"\\"+ file.Name);
            }
        }


        List<string> knownFiles = new List<string>();
        public bool checkFile(FileInfo file)
        {
            if (knownFiles.Contains(file.Name))
            {
                return true;
            }
            return false;
        }


        private IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                     
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }
    }
}
