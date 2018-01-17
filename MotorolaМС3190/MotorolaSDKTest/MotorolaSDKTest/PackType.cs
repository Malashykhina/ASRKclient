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
            this.Close();  
            //this.Dispose();
            Application.Exit();
        }

        private void create_Click(object sender, EventArgs e)
        {
            CreatePack cp = new CreatePack();
            cp.Show();
            this.Hide();
            cp.Closing += cp_Closing;
        }
        private void cp_Closing(object sender, EventArgs e)
        {
            this.Show();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            ChoosePack frmPack = new ChoosePack();
            frmPack.Show();
            this.Hide();
            frmPack.Closing += frmPack_Closing;
        }
        private void frmPack_Closing(object sender, EventArgs e)
        {
            this.Show();
        }

        private void pack_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //try { this.Owner.Close(); }
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            //finally
            //{
                this.Close();
                //this.Dispose();
                Application.Exit();
            //}
        }

    }
}