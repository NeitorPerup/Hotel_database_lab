
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.комнатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.персоналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.должностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.личныеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снятьКомнатуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчёт1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчёт2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.входToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.регистрацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.личныеДанныеToolStripMenuItem,
            this.снятьКомнатуToolStripMenuItem,
            this.отчёт1ToolStripMenuItem,
            this.отчёт2ToolStripMenuItem,
            this.входToolStripMenuItem,
            this.регистрацияToolStripMenuItem});
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
            this.комнатыToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.комнатыToolStripMenuItem.Text = "Комнаты";
            this.комнатыToolStripMenuItem.Click += new System.EventHandler(this.комнатыToolStripMenuItem_Click);
            // 
            // категорииToolStripMenuItem
            // 
            this.категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            this.категорииToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.категорииToolStripMenuItem.Text = "Категории";
            this.категорииToolStripMenuItem.Click += new System.EventHandler(this.категорииToolStripMenuItem_Click);
            // 
            // персоналToolStripMenuItem
            // 
            this.персоналToolStripMenuItem.Name = "персоналToolStripMenuItem";
            this.персоналToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.персоналToolStripMenuItem.Text = "Персонал";
            this.персоналToolStripMenuItem.Click += new System.EventHandler(this.персоналToolStripMenuItem_Click);
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.должностиToolStripMenuItem_Click);
            // 
            // личныеДанныеToolStripMenuItem
            // 
            this.личныеДанныеToolStripMenuItem.Name = "личныеДанныеToolStripMenuItem";
            this.личныеДанныеToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.личныеДанныеToolStripMenuItem.Text = "Личные данные";
            this.личныеДанныеToolStripMenuItem.Click += new System.EventHandler(this.личныеДанныеToolStripMenuItem_Click);
            // 
            // снятьКомнатуToolStripMenuItem
            // 
            this.снятьКомнатуToolStripMenuItem.Name = "снятьКомнатуToolStripMenuItem";
            this.снятьКомнатуToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.снятьКомнатуToolStripMenuItem.Text = "Снять комнату";
            this.снятьКомнатуToolStripMenuItem.Click += new System.EventHandler(this.снятьКомнатуToolStripMenuItem_Click);
            // 
            // отчёт1ToolStripMenuItem
            // 
            this.отчёт1ToolStripMenuItem.Name = "отчёт1ToolStripMenuItem";
            this.отчёт1ToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.отчёт1ToolStripMenuItem.Text = "Комнаты";
            this.отчёт1ToolStripMenuItem.Click += new System.EventHandler(this.ВсеКомнатыToolStripMenuItem_Click);
            // 
            // отчёт2ToolStripMenuItem
            // 
            this.отчёт2ToolStripMenuItem.Name = "отчёт2ToolStripMenuItem";
            this.отчёт2ToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчёт2ToolStripMenuItem.Text = "Счета";
            this.отчёт2ToolStripMenuItem.Click += new System.EventHandler(this.СчетаToolStripMenuItem_Click);
            // 
            // входToolStripMenuItem
            // 
            this.входToolStripMenuItem.Name = "входToolStripMenuItem";
            this.входToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.входToolStripMenuItem.Text = "Вход";
            this.входToolStripMenuItem.Click += new System.EventHandler(this.входToolStripMenuItem_Click);
            // 
            // регистрацияToolStripMenuItem
            // 
            this.регистрацияToolStripMenuItem.Name = "регистрацияToolStripMenuItem";
            this.регистрацияToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.регистрацияToolStripMenuItem.Text = "Регистрация";
            this.регистрацияToolStripMenuItem.Click += new System.EventHandler(this.регистрацияToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(653, 341);
            this.dataGridView.TabIndex = 16;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 393);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem комнатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem персоналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem личныеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снятьКомнатуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчёт1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчёт2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem входToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem регистрацияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

