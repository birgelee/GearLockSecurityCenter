using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using GearLockSecurityCenter;
using System.Web.Script.Serialization;
using System.Threading;
namespace GearLockSecurityCenter
{
    public class FileSearcher
    {
        private Dictionary<string, bool> knownFiles = new Dictionary<string,bool>();
        private Dictionary<string, bool> foundFiles = new Dictionary<string,bool>();
        public delegate void LineWriter(string line);
        private string currentUser;

        public void SearchFilesAsynk(string rootPath, string dumpPath, string excludeUser, LineWriter output, bool include)
        {
            Thread t = new Thread(() => SearchFiles(rootPath, dumpPath, excludeUser, output, include));
            t.Start();
        }

        public void SearchFiles(string rootPath, string dumpPath, string excludeUser, LineWriter output, bool include)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            knownFiles = jss.Deserialize<Dictionary<string, bool>>("{" + Properties.Resources.IgnoreFileJSON + Properties.Resources.IgnoreFileJSONAllUsers + Properties.Resources.IgnoreFileJSONDefaultUser + Properties.Resources.IgnoreFileJSONMISC1 + "\"\":true}");
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            this.rootPath = rootPath;
            dir.GetFiles().ForEach((f) => ProcessFile(f));
            if (include)
            {
                output("Searching the User: " + excludeUser);
                currentUser = excludeUser;
                var usrdir = dir.GetDirectories().Where((d) => d.Name.Equals(excludeUser));
                if (usrdir.Count() < 1)
                {
                    output("Error: no such user dir was found.");
                    return;
                }
                
                SearchDir(usrdir.ElementAt(0));
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
            writer.Serialize(file, knownFiles);
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
                {
                    foundFiles.Add(KnownFile.TrimPath(file.FullName, rootPath, currentUser), true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //Returns true of the file is a microsoft file.
        private bool CheckFiles(FileInfo file)
        {
            try
            {

                string trimmedPath = KnownFile.TrimPath(
                    file.FullName, rootPath, currentUser);
                if (trimmedPath.StartsWith("\\AppData\\Local\\Microsoft\\") || trimmedPath.StartsWith("\\AppData\\Local\\Temp\\" + currentUser + ".bmp") || trimmedPath.StartsWith("\\Contacts\\" + currentUser + ".contact") || trimmedPath.StartsWith("\\AppData\\Roaming\\Microsoft\\Protect\\"))
                {
                    return true;
                }
                    
                if (file.Name.StartsWith("NTUSER.DAT") || file.Name.StartsWith("desktop.ini"))
                {
                    return true;
                }
                if (knownFiles[trimmedPath] == true)
                {
                    return true;
                }

            }
            catch (KeyNotFoundException ex)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}
