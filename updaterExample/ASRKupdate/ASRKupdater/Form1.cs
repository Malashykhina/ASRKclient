using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.Diagnostics;
using testSqLite;
using System.Security.Cryptography;
using System.Threading;

namespace ASRKupdator
{
    public partial class Form1 : Form
    {
        public static string Url = "http://10.49.170.56:61090/Updater.svc";
        public static string SourceDir = "\\Program Files\\asrkclient";//"\\Program Files\\testsqlite";//"\\Program Files\\client4";
        public static string StartFileName = "\\ASRKclient.exe";
        public static string StartFileLink = "ASRKclient.lnk";//42#"\Program Files\asrkclient\ASRKclient.exe"
        public static string StartUpDir = "\\Windows\\StartUp";
        public static string ProgramsDir = "\\Windows\\Start Menu\\Programs";
        public Form1()
        {
            InitializeComponent();
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
                        MessageBox.Show("Error writing data.");
                        return;
                    }
                }
            }
        }
        private byte[] ReadFile(string fileName)
        {
            using (FileStream
            fileStream = new FileStream(fileName, FileMode.Open))
            {
                return  ReadFully(fileStream);
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        Thread thread;
        static public string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public void Draw(string s1, int i,int length )
        {
                var lvi = new ListViewItem(s1);//+";"
                lvi.BackColor = Color.LightGoldenrodYellow;
                listView1.Items.Add(lvi);
                progressBar1.Value = ((i + 1 )* 100 / length);
                label1.Text = "Завантажено " + (i + 1) + " з " + (length+1) + " файлів";
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kill())
            {
                thread = new Thread(this.DownloadFromServer);
                thread.Start();
            //                //Declare this in class
            //public delegate void delege();

            ////Write this lines when you want to background thread start
            //    Thread thread = new Thread(new ThreadStart(() => {
            //    //Do what you what with backgorund threading , can not use any interface comand here
            //         BeginInvoke(new delege(() => { 
            //           //Do here any main thread thread job,this can do interface and control jobs without any error 
            //         }));
            //    }));
            //    thread.Start();
            }
        }
        public delegate void DrawDelegate(string s1, int i, int length);
        public delegate void DrawProgresBarDelegate(bool visibility);
        public delegate void Show2ButtonDelegate();
        private void DrawProgresBar(bool visibility) {
            progressBar1.Visible = visibility;
            label1.Visible = visibility;
            button2.Enabled = false;//
        }
        private void Disable1Button()
        {
            button1.Enabled = false;
        }
        private void Enable1Button()
        {
            button1.Enabled = true;
        }
        private void Show2Button()
        {
            //button1.Visible = false;
            button1.Enabled = false;//
            button2.Enabled = true;//
            button2.Visible = true;
        }
        private void DownloadFromServer() {
            try
            {
                DrawProgresBarDelegate handler = DrawProgresBar;
                Invoke(handler, new object[] { true });
                //Show2ButtonDelegate handler0 = Disable1Button;
                //Invoke(handler0, new object[] {});                

                DirectoryInfo source = new DirectoryInfo(SourceDir);

                if (!source.Exists)
                {
                    source.Create();
                }

                string remoteAddress = Url;
                EndpointAddress endpoint = new EndpointAddress(remoteAddress);


                BasicHttpBinding binding = new BasicHttpBinding();
                binding.MaxReceivedMessageSize = Int32.MaxValue; // 658752;//458752;// Int32.MaxValue; //104857600;
                var update = new UpdaterClient(binding, endpoint);
                var names = update.GetHeshes();
                var localFiles = GetLocalFilesWithHeshes();
               // var filesDevice = Directory.GetFiles(SourceDir);

                for (int i = 0; i < names.Length; i++)
                {
                    var s = names[i].Key;
                    if (s != null)
                    {

                        int pos = s.LastIndexOf(@"\") + 1;
                        var s1 = s.Substring(pos, s.Length - pos);

                            DrawDelegate handler2 = Draw;
                            Invoke(handler2, new object[] { s1, i, names.Length });
                            if (!SearchFileInLocalDir(s1, names[i].Value, localFiles))// filesDevice))
                        {
                            //Draw(s1, i, names.Length);
                            var a0 = update.DownloadFile(s);
                            if (s1 == StartFileLink)
                            {
                                WriteFile(StartUpDir + "\\" + s1, a0);
                                WriteFile(ProgramsDir + "\\" + s1, a0);
                            }
                            else
                            {
                                WriteFile(SourceDir + "\\" + s1, a0);
                            }
                        }
                           
                            
                    }
                }
                DrawProgresBarDelegate handler3 = DrawProgresBar;
                Invoke(handler3, new object[] { false });

                Show2ButtonDelegate handler4 = Show2Button;
                Invoke(handler4, new object[] {});
               // button2.Visible = true;
                //MessageBox.Show("That's all, folks");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format
                    ("Connection Error: {0}", ex.Message));
                DrawProgresBarDelegate handler8 = DrawProgresBar;
                Invoke(handler8, new object[] { false });

                Show2ButtonDelegate handler9 = Enable1Button;
                Invoke(handler9, new object[] {}); 
                
               // progressBar1.Visible = false;
            }
        }

        private bool SearchFileInLocalDir(string name, string serverHesh, string[,] localNames){//string timestamp, string[] localNames){
            if (localNames != null)
            {
                for (int i = 0; i < localNames.GetLength(1); i++)
                {
                    var s = localNames[0, i];
                    //int pos = s.LastIndexOf(@"\") + 1;
                    //s = s.Substring(pos, s.Length - pos);
                    //var hesh = md5_hash(ReadFile(localNames[i]));//byte[]
                    var hesh = localNames[1, i];
                    if (name.Equals(s))
                    {
                        if (serverHesh.Equals(hesh))
                        {
                           // MessageBox.Show(s + " ; " + serverHesh + " ; " + hesh);
                            return true;
                        }
                        else { return false; }
                    }
                }
            }
            return false;
        }

        private static string md5_hash(byte[] arr)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(arr)).Replace("-", string.Empty);
        }

        private string[,] GetLocalFilesWithHeshes()
        {
            string url = SourceDir;
            string[,] dict=null;
            var fileNames = Directory.GetFiles(url);
            if (fileNames != null)
            {
                dict = new string[2, fileNames.Length];
                for (int i = 0; i < fileNames.Length; i++)
                {
                    var s = fileNames[i];
                    int pos = s.LastIndexOf(@"\") + 1;
                    s = s.Substring(pos, s.Length - pos);
                    dict[0, i] = s;
                    dict[1, i] = md5_hash(ReadFile(fileNames[i]));
                }
            }
            return dict;
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = SourceDir + StartFileName;// @"\Program Files\client3\testSqLite.exe";
            try
            {
                Process.Start(processStartInfo);
                Application.Exit();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            Settings st = new Settings();
            st.Show();
        }

        private bool kill() {
            ProcessInfo[] list = ProcessCE.GetProcesses();
            bool result = true;
            foreach (ProcessInfo item in list)
            {
                //MessageBox.Show(item.FullPath);
                if (item.FullPath.Contains(SourceDir))
                {
                    switch (MessageBox.Show("Запущена програма скану штрихкодів. Бажаєте завершити її і здійснити оновлення?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                    {
                        case DialogResult.Yes:
                            item.Kill();
                            result = true;
                            break;

                        case DialogResult.No:
                            result = false;
                            break;
                    }
                }
            }
            return result;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (thread != null) {
                try
                {
                    thread.Abort();
                    thread.Join();
                }
                catch(Exception ex){}
            }
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();

            myProcess.StartInfo.FileName = @"\Windows\ctlpnl.exe";// @"\Program files\SettingLaunch\SettingsUI.exe";
            //myProcess.StartInfo.Arguments = "cplmain.cpl,8";
            //myProcess.StartInfo.Arguments = "cplmain.cpl, 8, 7, 3";

            myProcess.StartInfo.Arguments = "cplmain.cpl, 17, 0";

            //myProcess.StartInfo.Arguments = "cplmain.cpl,1";
            //myProcess.StartInfo.FileName = @"\Windows\ctlpnl.exe";
            //myProcess.StartInfo.Arguments = "cplmain.cpl,8";
            try
            {
                myProcess.Start();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }
            //ProcessStartInfo processStartInfo = new ProcessStartInfo();
            //processStartInfo.FileName = @"\Program files\SettingLaunch\SettingsUI.exe";// -settings";// @"\Windows\edm2.exe";
            //// @"\Windows\CoreCon1.1\ConManClient2.exe";// @"\Program Files\client3\testSqLite.exe";
            //try
            //{
            //    Process.Start(processStartInfo);
            //   // Application.Exit();
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show(f.ToString());
            //}
        }

    }
}