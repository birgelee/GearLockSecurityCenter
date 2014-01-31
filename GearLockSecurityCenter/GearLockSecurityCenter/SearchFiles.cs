using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using GearLockSecurityCenter;
using System.Web.Script.Serialization;
namespace GearLockSecurityCenter
{
    public class FileSearcher
    {
        private List<KnownFile> knownFiles = new List<KnownFile>(), foundFiles = new List<KnownFile>();
        public delegate void LineWriter(string line);
        private string currentUser;
        public void SearchFiles(string rootPath, string dumpPath, string excludeUser, LineWriter output, bool include)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            knownFiles = jss.Deserialize<List<KnownFile>>(Properties.Resources.IgnoreFileJSON);
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            this.rootPath = rootPath;
            dir.GetFiles().ForEach((f) => ProcessFile(f));
            if (include)
            {
                output("Searching the User: " + excludeUser);
                currentUser = excludeUser;
                SearchDir(dir.GetDirectories().Where((d) => d.Name.Equals(excludeUser)).ElementAt(0));
            }
            else
            {
                dir.GetDirectories().ForEach((d) =>
                {
                    if (!d.Name.Equals(excludeUser))
                    {
                        output("Searching User: " + d.Name);
                        currentUser = d.Name;
                        SearchDir(d);
                    }
                    else
                    {
                        output("Skiping User: " + d.Name);
                    }
                });

                

            }
            output("File Search Complete");

            
            File.WriteAllText("C:\\usersoutput.txt", jss.Serialize(foundFiles));
            //WriteXML();
            output("File Search Complete and Output Written");
        }


        public void WriteXML()
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<KnownFile>));

            System.IO.StreamWriter file = new System.IO.StreamWriter(
                @"c:\SerializationOverview.xml");
            writer.Serialize(file,knownFiles);
            file.Close();
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
                if (!CheckFiles(file))
                foundFiles.Add(new KnownFile(file, rootPath, currentUser));
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
            catch
            {
            }
            return true;
        }
    }
}
