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
    public partial class DestinationPoints : Form
    {
        public DestinationPoints()
        {
            InitializeComponent();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            Pack.indexTo = textBox1.Text.Trim();
            if (Pack.indexTo != "") {
                if (ServiceProxy.postUnitExists(Pack.indexTo))
                {
                    //MessageBox.Show(Pack.indexTo);
                    ShellType st = new ShellType();
                    st.Show();

                    this.Close();
                }
                else {
                    MessageBox.Show("Такого індексу немає");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка заповніть поле");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}