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
    public partial class SecureUsersBox : Form
    {
        public SecureUsersBox()
        {
            InitializeComponent();
            textBox1.Text = @"C:\Users";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowser.SelectedPath;
            }
        }
    }
}
