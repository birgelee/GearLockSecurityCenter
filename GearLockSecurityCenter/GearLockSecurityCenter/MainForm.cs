﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GearLockSecurityCenter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            /*
             */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void gpedit_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sb = new SecureUsersBox();
            sb.TopLevel = false;
            sb.ShowInTaskbar = false;
            sb.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sb.Show();
            sb.Dock = DockStyle.Fill;

            this.Controls.Add(sb);
            sb.BringToFront();
        }
    }
}
