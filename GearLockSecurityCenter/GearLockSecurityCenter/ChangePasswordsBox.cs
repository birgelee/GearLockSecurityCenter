using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GearLockSecurityCenter
{
    public partial class ChangePasswordsBox : Form
    {
        public ChangePasswordsBox()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ChangeUserPasswords passwordChanger = new ChangeUserPasswords();
            passwordChanger.ChangePasswordsAsynk();
            

        }





    }
}
