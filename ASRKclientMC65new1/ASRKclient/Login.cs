using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using System.Threading;
using Microsoft.Win32;
using DataGridTest.DataGrid;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;
using System.Reflection;
using System.Diagnostics;

namespace ASRKclient
{
    public partial class Login : Form
    {
        public static string SoftwareVersion = "0";
        public static string LOGIN;
        public static string INDEX;
        public static string PASS;
        public static string REGISTRARID;
        public static string USERNAME;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN = loginTextBox.Text.Trim();
            INDEX = IndexTextBox.Text.Trim();
            PASS = PassTextBox.Text.Trim();
            try
            {
                var res = ServiceProxy.login(INDEX, LOGIN, PASS);
                if (res != null)
                {
                    if ((res.registerId != null) && (res.userName != null))
                    {
                        REGISTRARID = res.registerId;
                        USERNAME = res.userName;
                        showNextWindow();
                    }
                    else
                    {
                        MessageBox.Show("Користувача не знайдено");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка з'єднання"); }//ex.StackTrace, 
        }
        private void showNextWindow() {
            ChoseOperation choseOpForm = new ChoseOperation();
            choseOpForm.Show();
        }
        private void showButton2()
        {
            button2.Visible = true;
        }

        private void Login_Closing(object sender, CancelEventArgs e)
        {
            this.Close(); //this.Dispose();
            Application.Exit();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }

        public delegate void NextWindowDelegate();
      
        public class RespStructure
        {
            public string STATUS;
            public string REGISTRARID;
            public string USERNAME;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "\\Program Files\\ASRKupdater\\ASRKupdater.exe";
            try
            {
                Process.Start(processStartInfo);//викрнує exe файл на пристрої
                Application.Exit();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }
        }

        private void WriteFile(string fileName, byte[] dataArray)
        {
            using (FileStream
                fileStream = new FileStream(fileName, FileMode.Create))
            {
                // Write the data to the file, byte by byte.
                for (int i = 0; i < dataArray.Length; i++)
                {
                    fileStream.WriteByte(dataArray[i]);
                }

                // Set the stream position to the beginning of the file.
                fileStream.Seek(0, SeekOrigin.Begin);

                // Read and verify the data.
                for (int i = 0; i < fileStream.Length; i++)
                {
                    if (dataArray[i] != fileStream.ReadByte())
                    {
                        Console.WriteLine("Error writing data.");
                        return;
                    }
                }
                Console.WriteLine("The data was written to {0} " +
                    "and verified.", fileStream.Name);
            }
        }
        static public string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            loginTextBox.Text = "";// Setting.Login;//!!!!!!!! потім повернемо
            IndexTextBox.Text = Setting.Index; //"";// Setting.Index;//
            PassTextBox.Text = "";// Setting.Password;//
            //CheckConnection();

            //перевіряємо чи є оновлення!
            //NextWindowDelegate handler = showButton2;
            //Invoke(handler, new object[] { });
        }

        private void IndexTextBox_TextChanged(object sender, EventArgs e)
        {
            INDEX = IndexTextBox.Text;
            Setting.Index = IndexTextBox.Text;//
            Setting.Update();
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            LOGIN = loginTextBox.Text;
            Setting.Login = loginTextBox.Text;//
            Setting.Update();
        }

        private void PassTextBox_TextChanged(object sender, EventArgs e)
        {
            PASS = PassTextBox.Text;
            Setting.Password  = PassTextBox.Text;
            Setting.Update();
        }

        private void CheckConnection()
        {
            string url = Setting.ServiceUrl;
            try
            {
                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(url);
                System.Net.WebResponse myResponse = myRequest.GetResponse();
            }
            catch (System.Net.WebException ex)
            {
              //MessageBox.Show("Перевірте підключення до серверу");
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close(); //this.Dispose();
            Application.Exit();
        }
    }
}