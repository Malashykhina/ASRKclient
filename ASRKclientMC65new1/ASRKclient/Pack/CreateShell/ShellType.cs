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
    public partial class ShellType : Form
    {
        public ShellType()
        {
            InitializeComponent();
        }
        getAllShellTypesResponse allShellTypes;
        private void choose_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Pack.shellType = comboBox1.SelectedItem.ToString();
                Pack.shellTypeId = allShellTypes.shellType[comboBox1.SelectedIndex].shellId;

                DialogResult result = MessageBox.Show("Запакувати за планом напрямків?", "", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    DestinationPlan dp = new DestinationPlan();
                    dp.Show();
                }
                else
                {
                    // CreatePack cp = new CreatePack();
                    // cp.Show();
                    Pack.destinationPlan = "";
                    Pack.destinationPlanId = 0;
                    Pack.destinationPoint = "";
                    Pack.destinationPointId = 0;
                    Pack pack=new Pack();
                    pack.createPack();
                }
                this.Close();
            }
            else {
                MessageBox.Show("Будь ласка оберіть тип запакування");
              //  Pack.shellType = ""; 
            }

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShellType_Load(object sender, EventArgs e)
        {
            try
            {
                allShellTypes = ServiceProxy.getAllShellTypes();
                if (allShellTypes.status == 1)
                {
                    for (int i = 0; i < allShellTypes.shellType.Length; i++)
                    {
                        string s = allShellTypes.shellType[i].shellDoctitle;
                        comboBox1.Items.Add(s);
                    }
                }else MessageBox.Show("Не знайдено типів оболонок");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

    }
}