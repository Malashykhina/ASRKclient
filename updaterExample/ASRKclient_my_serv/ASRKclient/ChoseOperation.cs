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
    public partial class ChoseOperation : Form
    {
        public static int TIMEOUT = 10000;
        public static string IP = "10.255.102.149";//"10.255.102.148";//:8080
        public static string PORT = "8080";
        public static string IP2 = "10.49.170.56";//"10.255.102.148";//:8080
        public static string PORT2 = "61090";
        //public static AcceptPost ap;
        //public static Packing frmPack;
        //public static Cancel canselFrm;
        public static int curOperation;
        public ChoseOperation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //curOperation = 1;
            //AcceptPost ap = new AcceptPost();
            //ap.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Unpack frm = new Unpack();
            //frm.Show();
            curOperation = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curOperation = 3;
            PackType frmPack = new PackType();
            frmPack.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            curOperation = 4;
            //if (canselFrm == null)
            //{
            //    canselFrm = new Cancel();
            //}
            Cancel canselFrm = new Cancel();
            canselFrm.Show();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem2_Click_1(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }

        private void ChoseOperation_Load(object sender, EventArgs e)
        {
            label1.Text = "Вітаємо, " + Login.USERNAME + ".";
        }
    }
}