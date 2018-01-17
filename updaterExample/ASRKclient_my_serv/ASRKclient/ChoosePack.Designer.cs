namespace ASRKclient
{
    partial class ChoosePack
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
            this.back = new System.Windows.Forms.Button();
            this.choose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.back.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.back.Location = new System.Drawing.Point(142, 220);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(73, 40);
            this.back.TabIndex = 29;
            this.back.Text = "Назад";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // choose
            // 
            this.choose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.choose.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.choose.Location = new System.Drawing.Point(25, 151);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(190, 50);
            this.choose.TabIndex = 28;
            this.choose.Text = "Обрати оболонку";
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.comboBox1.Location = new System.Drawing.Point(3, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 30);
            this.comboBox1.TabIndex = 30;
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Налаштування";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Вихід";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // ChoosePack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.choose);
            this.Menu = this.mainMenu1;
            this.Name = "ChoosePack";
            this.Text = "ChoosePack";
            this.Load += new System.EventHandler(this.ChoosePack_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;

    }
}