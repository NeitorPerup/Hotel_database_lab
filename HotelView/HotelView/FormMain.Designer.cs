
namespace HotelView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.buttonClientData = new System.Windows.Forms.Button();
            this.buttonRentRoom = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.комнатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.персоналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.должностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(540, 32);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(84, 23);
            this.buttonSignUp.TabIndex = 8;
            this.buttonSignUp.Text = "Регистрация";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Location = new System.Drawing.Point(468, 32);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(55, 23);
            this.buttonSignIn.TabIndex = 7;
            this.buttonSignIn.Text = "Вход";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // buttonClientData
            // 
            this.buttonClientData.Location = new System.Drawing.Point(12, 32);
            this.buttonClientData.Name = "buttonClientData";
            this.buttonClientData.Size = new System.Drawing.Size(55, 38);
            this.buttonClientData.TabIndex = 9;
            this.buttonClientData.Text = "Личные данные";
            this.buttonClientData.UseVisualStyleBackColor = true;
            this.buttonClientData.Click += new System.EventHandler(this.buttonClientData_Click);
            // 
            // buttonRentRoom
            // 
            this.buttonRentRoom.Location = new System.Drawing.Point(73, 32);
            this.buttonRentRoom.Name = "buttonRentRoom";
            this.buttonRentRoom.Size = new System.Drawing.Size(61, 38);
            this.buttonRentRoom.TabIndex = 10;
            this.buttonRentRoom.Text = "Снять комнату";
            this.buttonRentRoom.UseVisualStyleBackColor = true;
            this.buttonRentRoom.Click += new System.EventHandler(this.ButtonAddRoom_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(540, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(540, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(540, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(653, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.комнатыToolStripMenuItem,
            this.категорииToolStripMenuItem,
            this.персоналToolStripMenuItem,
            this.должностиToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // комнатыToolStripMenuItem
            // 
            this.комнатыToolStripMenuItem.Name = "комнатыToolStripMenuItem";
            this.комнатыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.комнатыToolStripMenuItem.Text = "Комнаты";
            this.комнатыToolStripMenuItem.Click += new System.EventHandler(this.комнатыToolStripMenuItem_Click);
            // 
            // категорииToolStripMenuItem
            // 
            this.категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            this.категорииToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.категорииToolStripMenuItem.Text = "Категории";
            this.категорииToolStripMenuItem.Click += new System.EventHandler(this.категорииToolStripMenuItem_Click);
            // 
            // персоналToolStripMenuItem
            // 
            this.персоналToolStripMenuItem.Name = "персоналToolStripMenuItem";
            this.персоналToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.персоналToolStripMenuItem.Text = "Персонал";
            this.персоналToolStripMenuItem.Click += new System.EventHandler(this.персоналToolStripMenuItem_Click);
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.должностиToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 393);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRentRoom);
            this.Controls.Add(this.buttonClientData);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Button buttonClientData;
        private System.Windows.Forms.Button buttonRentRoom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem комнатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem персоналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem;
    }
}

