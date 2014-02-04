using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;

namespace GearLockSecurityCenter
{
    class ChangeUserPasswords
    {

        const int SCRIPT = 0x0001, ACCOUNTDISABLE = 0x0002, HOMEDIR_REQUIRED = 0x0008, LOCKOUT = 0x0010, PASSWD_NOTREQD = 0x0020, PASSWD_CANT_CHANGE = 0x0040, ENCRYPTED_TEXT_PWD_ALLOWED = 0x0080, TEMP_DUPLICATE_ACCOUNT = 0x0100, NORMAL_ACCOUNT = 0x0200, INTERDOMAIN_TRUST_ACCOUNT = 0x0800, WORKSTATION_TRUST_ACCOUNT = 0x1000, SERVER_TRUST_ACCOUNT = 0x2000, DONT_EXPIRE_PASSWORD = 0x10000, MNS_LOGON_ACCOUNT = 0x20000, SMARTCARD_REQUIRED = 0x40000, TRUSTED_FOR_DELEGATION = 0x80000, NOT_DELEGATED = 0x100000, USE_DES_KEY_ONLY = 0x200000, DONT_REQ_PREAUTH = 0x400000, PASSWORD_EXPIRED = 0x800000, TRUSTED_TO_AUTH_FOR_DELEGATION = 0x1000000;
        public ChangeUserPasswords()
        {

        }
        string masterPassword;
        GearLockSecurityCenter.FileSearcher.LineWriter output;
        public void ChangePasswordsAsynk(string masterPassword, string excludeUser, GearLockSecurityCenter.FileSearcher.LineWriter output)
        {
            this.masterPassword = masterPassword;
            this.output = output;
            Thread t = new Thread(() => ChangePasswords(masterPassword, excludeUser));
            t.Start();
        }
        private void ChangePasswords(string masterPassword, string excludeUser)
        {
            output("Connecting to local AD Server");
            DirectoryEntry localDirectory = new DirectoryEntry("WinNT://" + Environment.MachineName.ToString());
            DirectoryEntries users = localDirectory.Children;
            foreach (DirectoryEntry user in users)
            {
                try
                {
                    try
                    {
                        if ((int)user.Properties["UserFlags"].Value == 0);

                    }
                    catch
                    {
                        Console.WriteLine("not a user");
                        continue;
                    }
                    Console.WriteLine("iterating user " + user.Name);
                    if (user.Name.Equals(excludeUser) || (user.Username != null && user.Username.Equals(excludeUser)))
                    {
                        output("Excluding User " + user.Name);
                        continue;
                    }
                    if (user.Name.Equals("Administrators"))
                    {
                        output("Skiping chinging user polocies on Administrator");
                    }
                    Console.WriteLine("checked if exclude user");
                    output("Changing password on user " + user.Name);
                    user.Invoke("SetPassword", new object[] { masterPassword });

                    int val = (int)user.Properties["UserFlags"].Value;
                    user.Properties["UserFlags"].Value = (val & ~DONT_EXPIRE_PASSWORD);
                    
                    user.CommitChanges();
                    user.Close();
                }
                catch (Exception ex)
                {
                    output("Failed to change password or user settings on " + user.Name);
                    Console.WriteLine("Failed to change password or user settings on " + user.Name);
                }

            }
            localDirectory.Close();
            output("Changed All User Passwords.");
        }
    }
}
