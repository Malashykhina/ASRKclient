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
    public partial class DestinationPlan : Form
    {
        public DestinationPlan()
        {
            InitializeComponent();
        }
        
        getAllRoutePlansResponse allRoutePlans;
        getRoutePointByRouteIdResponse allPointByRouteId;

        private void choose_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem != null) && (comboBox2.SelectedItem != null))
            {
                Pack.destinationPlan = comboBox1.SelectedItem.ToString();
                Pack.destinationPlanId = allRoutePlans.routePlan[comboBox1.SelectedIndex].routeId;
                Pack.destinationPoint = comboBox2.SelectedItem.ToString();
                Pack.destinationPointId = allPointByRouteId.routePoint[comboBox2.SelectedIndex].id;
                Pack pack=new Pack();
                pack.createPack();

                //this.Close();
            }
            else { MessageBox.Show("Будь ласка оберіть маршрут"); }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DestinationPlan_Load(object sender, EventArgs e)
        {
            allRoutePlans = ServiceProxy.getAllRoutePlans();
            if ((allRoutePlans.status == 1) && (allRoutePlans.routePlan != null))
            {
                for (int i = 0; i < allRoutePlans.routePlan.Length; i++)
                {
                    string s = allRoutePlans.routePlan[i].routeName;
                    comboBox1.Items.Add(s);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            allPointByRouteId = ServiceProxy.getRoutePointByRouteId(allRoutePlans.routePlan[comboBox1.SelectedIndex].routeId);//Convert.ToInt32;
            if ((allPointByRouteId.status == 1) && (allPointByRouteId.routePoint != null))
            {
                for (int i = 0; i < allPointByRouteId.routePoint.Length; i++)
                {
                    string s = allPointByRouteId.routePoint[i].objectName;
                    comboBox2.Items.Add(s);
                }
            }
        }
    }
}