using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading;

namespace GearLockSecurityCenter
{
    class ChangeUserPasswords
    {
        public ChangeUserPasswords()
        {
            
        }

        public void ChangePasswordsAsynk()
        {
            Thread t = new Thread(ChangePasswords);
            t.Start();
        }
        private void ChangePasswords()
        {
            DirectoryEntry localDirectory = new DirectoryEntry("WinNT://" + Environment.MachineName.ToString());
            DirectoryEntries users = localDirectory.Children;
            DirectoryEntry user = users.Find("Henry");
            Console.WriteLine(user.Path);
            Console.WriteLine(user.Name);
        }
    }
}
