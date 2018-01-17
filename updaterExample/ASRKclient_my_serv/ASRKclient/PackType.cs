using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ASRKclient
{
    public partial class PackType : Form
    {
        public PackType()
        {
            InitializeComponent();
        }
        //public static string package;

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
           // this.Dispose();
            this.Close();
            Application.Exit();
        }

        private void create_Click(object sender, EventArgs e)
        {
            try
            {
               // PackType.package 
                    var a= GeneratePack();

                if(a!="")// (PackType.package != "")
                {
                    //MessageBox.Show(PackType.package);
                    Pack p = new Pack();
                    Pack.package = a;// PackType.package;
                    p.Show();//
                    this.Close(); //
                }
                else MessageBox.Show("Штрихкод оболонки пустий");
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace, ex.Message); }
        }

        private void choose_Click(object sender, EventArgs e)
        {
            ChoosePack frmPack = new ChoosePack();
            frmPack.Show();

            this.Close();
        }

        private void pack_Click(object sender, EventArgs e)
        {
            this.Close();// this.Dispose();
        }
        private string GeneratePack() {
           var res =  ServiceProxy.createShell(Login.INDEX,Login.REGISTRARID);
           return res.barcodeShell;
        }

    }
}