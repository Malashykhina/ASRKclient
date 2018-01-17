namespace ASRKclient
{
    partial class PackType
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
            this.back = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.choose = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.back.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.back.Location = new System.Drawing.Point(203, 220);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(103, 40);
            this.back.TabIndex = 29;
            this.back.Text = "Назад";
            this.back.Click += new System.EventHandler(this.pack_Click);
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.create.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.create.Location = new System.Drawing.Point(13, 43);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(293, 50);
            this.create.TabIndex = 28;
            this.create.Text = "Створити оболонку";
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // choose
            // 
            this.choose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.choose.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.choose.Location = new System.Drawing.Point(13, 119);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(293, 50);
            this.choose.TabIndex = 30;
            this.choose.Text = "Обрати оболонку";
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(232, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 40);
            this.button2.TabIndex = 35;
            this.button2.Text = "Вийти";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // PackType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 270);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.choose);
            this.Controls.Add(this.back);
            this.Controls.Add(this.create);
            this.Name = "PackType";
            this.Text = "Оберіть оболонку";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.Button button2;
    }
}