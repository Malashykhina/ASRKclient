namespace ASRKclient
{
    partial class PackType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.back = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.choose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Налаштування";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Вийти";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.back.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.back.Location = new System.Drawing.Point(142, 196);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(73, 47);
            this.back.TabIndex = 29;
            this.back.Text = "Назад";
            this.back.Click += new System.EventHandler(this.pack_Click);
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.create.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.create.Location = new System.Drawing.Point(25, 37);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(190, 50);
            this.create.TabIndex = 28;
            this.create.Text = "Створити оболонку";
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // choose
            // 
            this.choose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.choose.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.choose.Location = new System.Drawing.Point(25, 114);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(190, 50);
            this.choose.TabIndex = 30;
            this.choose.Text = "Обрати оболонку";
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // PackType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.choose);
            this.Controls.Add(this.back);
            this.Controls.Add(this.create);
            this.Menu = this.mainMenu1;
            this.Name = "PackType";
            this.Text = "Оберіть оболонку";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Button choose;
    }
}