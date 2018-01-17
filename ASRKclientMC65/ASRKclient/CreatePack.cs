using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASRKclient
{
    public partial class CreatePack : Form
    {
        public CreatePack()
        {
            InitializeComponent();
        }


        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var tare=tareTextBox.Text.Trim();
            var indexTo=IndexToTextBox.Text.Trim();
            if ((tare != "") && (indexTo != ""))
            {
                try
                {
                    // PackType.package 
                    var a = GeneratePack(tare, indexTo);

                    if ((a!=null)&&(a != ""))// (PackType.package != "")
                    {
                        //MessageBox.Show(PackType.package);
                        Pack p = new Pack();
                        Pack.package = a;// PackType.package;
                        p.Show();//
                        this.Close(); //
                    }
                    else MessageBox.Show("Перевірте правильність індекса призначення контейнера");
                }
                catch (Exception ex) { MessageBox.Show(ex.StackTrace, ex.Message); }
            }
            else MessageBox.Show("Заповніть поля");
        }


        private string GeneratePack(string tare, string indexTo)
        {
            var res = ServiceProxy.createShell(indexTo, Login.INDEX, Login.REGISTRARID, tare);
            if (res.status == 1)
            {
                return res.barcodeShell;
            }
            else return null;
        }
    }
}