namespace ASRKclient
{
    partial class CreatePack
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
            this.button1 = new System.Windows.Forms.Button();
            this.tareTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IndexToTextBox = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(17, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(284, 45);
            this.button1.TabIndex = 18;
            this.button1.Text = "Створити";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tareTextBox
            // 
            this.tareTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tareTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.tareTextBox.Location = new System.Drawing.Point(131, 36);
            this.tareTextBox.Name = "tareTextBox";
            this.tareTextBox.Size = new System.Drawing.Size(178, 28);
            this.tareTextBox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 27);
            this.label3.Text = "№ тари";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 54);
            this.label4.Text = "Індекс призначення";
            // 
            // IndexToTextBox
            // 
            this.IndexToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.IndexToTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.IndexToTextBox.Location = new System.Drawing.Point(131, 84);
            this.IndexToTextBox.Name = "IndexToTextBox";
            this.IndexToTextBox.Size = new System.Drawing.Size(178, 28);
            this.IndexToTextBox.TabIndex = 17;
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.back.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.back.Location = new System.Drawing.Point(171, 219);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(130, 38);
            this.back.TabIndex = 30;
            this.back.Text = "Назад";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // CreatePack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 270);
            this.ControlBox = false;
            this.Controls.Add(this.back);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IndexToTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tareTextBox);
            this.Controls.Add(this.label3);
            this.Name = "CreatePack";
            this.Text = "Створити оболонку";
            this.Load += new System.EventHandler(this.CreatePack_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CreatePack_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tareTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IndexToTextBox;
        private System.Windows.Forms.Button back;
    }
}