namespace GearLockSecurityCenter
{
    partial class ChangePasswordsBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.globalPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.excludeUser = new System.Windows.Forms.TextBox();
            this.excludeUserCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // globalPassword
            // 
            this.globalPassword.Location = new System.Drawing.Point(12, 55);
            this.globalPassword.Name = "globalPassword";
            this.globalPassword.Size = new System.Drawing.Size(417, 20);
            this.globalPassword.TabIndex = 0;
            this.globalPassword.TextChanged += new System.EventHandler(this.globalPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Global Password:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(562, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Change User Passwords";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 282);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(562, 20);
            this.output.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Running Output:";
            // 
            // excludeUser
            // 
            this.excludeUser.Location = new System.Drawing.Point(120, 81);
            this.excludeUser.Name = "excludeUser";
            this.excludeUser.Size = new System.Drawing.Size(417, 20);
            this.excludeUser.TabIndex = 13;
            // 
            // excludeUserCheckBox
            // 
            this.excludeUserCheckBox.AutoSize = true;
            this.excludeUserCheckBox.Location = new System.Drawing.Point(13, 81);
            this.excludeUserCheckBox.Name = "excludeUserCheckBox";
            this.excludeUserCheckBox.Size = new System.Drawing.Size(101, 17);
            this.excludeUserCheckBox.TabIndex = 15;
            this.excludeUserCheckBox.Text = "Exclude a User:";
            this.excludeUserCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangePasswordsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 314);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.excludeUserCheckBox);
            this.Controls.Add(this.excludeUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.output);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.globalPassword);
            this.Name = "ChangePasswordsBox";
            this.Text = "Secure Users";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox globalPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox excludeUser;
        private System.Windows.Forms.CheckBox excludeUserCheckBox;
        private System.Windows.Forms.Button button1;

    }
}