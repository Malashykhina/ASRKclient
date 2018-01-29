using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace ASRKclient
{
    public partial class ChoosePack : Form
    {
        public ChoosePack()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close(); // this.Dispose();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                //PackType.package
                    var a = comboBox1.SelectedItem.ToString();//textBox1.Text;//PackType.package = "123";
                if (a!="")//(PackType.package != "")
                {
                    Pack p = new Pack();
                    Pack.package = a;// PackType.package;
                    p.Show();
                    this.Close();//
                }
            }
            else MessageBox.Show("Будь ласка оберіть штрихкод оболонки");
        }

        private void ChoosePack_Load(object sender, EventArgs e)
        {
            try
            {
                var res = ServiceProxy.getUnpackedShells(Login.INDEX);
                if (res.shell != null)
                {
                    for (int i = 0; i < res.shell.Length; i++)
                    {
                        string s = res.shell[i];
                        comboBox1.Items.Add(s);
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.StackTrace); }
        }
    }
}