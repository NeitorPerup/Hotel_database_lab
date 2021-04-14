
namespace HotelView
{
    partial class FormRegister
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
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(22, 80);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(45, 13);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Пароль";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(22, 32);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "Email";
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(89, 146);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(124, 27);
            this.buttonSignUp.TabIndex = 10;
            this.buttonSignUp.Text = "Зарегистрироваться";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(104, 73);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(104, 29);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmail.TabIndex = 8;
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(104, 115);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(100, 21);
            this.comboBoxRoles.TabIndex = 13;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(22, 123);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(32, 13);
            this.labelRole.TabIndex = 14;
            this.labelRole.Text = "Роль";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 195);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Name = "FormRegister";
            this.Text = "FormRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Label labelRole;
    }
}