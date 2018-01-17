namespace ASRKclient
{
    partial class Pack
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
            this.finish = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.exitBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.shell = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // finish
            // 
            this.finish.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.finish.Location = new System.Drawing.Point(12, 227);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(111, 40);
            this.finish.TabIndex = 29;
            this.finish.Text = "Завершити";
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.listView1.Location = new System.Drawing.Point(12, 70);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(293, 106);
            this.listView1.TabIndex = 28;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.exitBtn.Location = new System.Drawing.Point(129, 227);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(176, 40);
            this.exitBtn.TabIndex = 27;
            this.exitBtn.Text = "Назад";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(12, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 28);
            this.textBox1.TabIndex = 24;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.clear.Location = new System.Drawing.Point(12, 182);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(291, 40);
            this.clear.TabIndex = 25;
            this.clear.Text = "Очистити";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // shell
            // 
            this.shell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.shell.Location = new System.Drawing.Point(12, 11);
            this.shell.Name = "shell";
            this.shell.Size = new System.Drawing.Size(293, 20);
            this.shell.Text = "Оболонка";
            // 
            // count
            // 
            this.count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.count.BackColor = System.Drawing.Color.Transparent;
            this.count.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.count.Location = new System.Drawing.Point(256, 11);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(47, 20);
            this.count.Text = "К-сть";
            this.count.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(189, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 40);
            this.button2.TabIndex = 33;
            this.button2.Text = "Вийти";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Pack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 270);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.count);
            this.Controls.Add(this.shell);
            this.Controls.Add(this.finish);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.clear);
            this.Name = "Pack";
            this.Text = "Запаковка";
            this.Load += new System.EventHandler(this.Pack_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Pack_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button finish;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label shell;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Button button2;

    }
}