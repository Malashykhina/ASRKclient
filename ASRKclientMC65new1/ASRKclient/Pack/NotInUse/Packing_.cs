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

namespace ASRKclient
{
    public partial class Packing_ : Form
    {
        public Packing_()
        {
            InitializeComponent();
           // barcode_reader2.Parameters.BeepTime = 0;//вимкнути звук
        }
        private Symbol.Barcode.BarcodeReader barcode_reader2 = new Symbol.Barcode.BarcodeReader();

        public static string package;

        private void button1_Click(object sender, EventArgs e)
        {
            //barcode_reader2.Parameters.BeepTime = 0;////
            var s = textBox1.Text;// ScanBarcodes();//"567812345678" //сканувати//"2900400196018";//
            if ((s != null) &&(s!=""))
            {
                WriteBarcode2(s, "0");
                //textBox1.Text = s;
            }
            //next_Window();
        }
        private void next_Window() {
            package = textBox1.Text;
            if (package != "")
            {
                Pack p = new Pack();
                Pack.package = Packing_.package;
                //p.Parent
                p.Show();
                this.Close();
            }
            else MessageBox.Show("Будь ласка зіскануйте штрихкод оболонки");
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            //if(Login.choseOpForm == null){
            //    Login.choseOpForm = new ChoseOperation();
            //}
            //Login.choseOpForm.Show();
            //this.Close();
            barcode_reader2.Stop();
            barcode_reader2.Dispose();

            this.Close(); //this.Dispose();
        }

        //Процедура работает при получении новых данных со считывателя.
        void reader_ListChanged(object sender, ListChangedEventArgs e)
        {
            //task1  
            //barcode_reader2.Parameters.BeepTime = 0;////
            var s =  ScanBarcodes();//"567812345678" //сканувати//"2900400196018";//
            if (s != null)
            {
                textBox1.Text = s;
                WriteBarcode2(s, "0");
            }
            //next_Window();//
        }

        //сканувати штрихкод
        private string ScanBarcodes()
        {
            Symbol.Barcode.ReaderData nextReaderData = barcode_reader2.ReaderData;
            if (nextReaderData.Result == Symbol.Results.SUCCESS)
            {
                return nextReaderData.Text;
            }
            else
            {
                textBox1.Text = "Формат зчитанного Штрихового Кода - не розпізнано!";//Формат считанного Штрихового Кода - не распознан
                //Проигрываем звук - ненайденного ШК
                System.Media.SystemSounds.Exclamation.Play();
                System.Media.SystemSounds.Asterisk.Play();
                System.Media.SystemSounds.Exclamation.Play();
                System.Media.SystemSounds.Asterisk.Play();
                return null;
            }
        }
        public delegate void NextWindowDelegate();
        //посилає на сервер значення штрихкоду
        private string WriteBarcode2(string barcode, string status)
        {
            try
            {
                 
                //string url = "http://10.49.170.56:61090/Barcode.svc/SetPackingShell/" + barcode + "/" + Login.LOGIN + "/" + status + "/" + Login.INDEX + "/0/2";//mailtype/typeinvoice
                string url = "http://" + ChoseOperation.IP2 + ":" + ChoseOperation.PORT2 + "/Barcode.svc/SetPackingShell/" + barcode + "/" + Login.LOGIN + "/" + status + "/" + Login.INDEX + "/0/2";//mailtype/typeinvoice

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ReadWriteTimeout = ChoseOperation.TIMEOUT;//
                request.Method = "GET";// "POST";//
                request.ContentType = "application/x-www-form-urlencoded";// "application/xml";// "application/x-www-form-urlencoded";
                request.Timeout = ChoseOperation.TIMEOUT;
                string res = null;
                request.BeginGetResponse(result =>
                {
                    try
                    {
                        using (WebResponse myHttpWebResponse = (WebResponse)request.EndGetResponse(result))//(HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result))
                        {
                            if (((HttpWebResponse)myHttpWebResponse).StatusCode == HttpStatusCode.OK)//(response.StatusCode == HttpStatusCode.OK)
                            {
                                Stream dataStream = myHttpWebResponse.GetResponseStream();
                                // Open the stream using a StreamReader for easy access.
                                StreamReader reader = new StreamReader(dataStream);
                                // Read the content.
                                string responseFromServer = reader.ReadToEnd();
                                reader.Close();
                                dataStream.Close();
                                //string 
                                    res = responseFromServer.ToString();

                                //  MessageBox.Show("ok",res);
                                string res2 = res.Trim('"');
                                //int res = Convert.ToInt32(objText.Trim('"'));
                                //res.Replace(@"", "");//res.Replace(@"", "");
                                // MessageBox.Show("ok", res2);
                                switch (res2)
                                {
                                    case "1":
                                        MessageBox.Show("Вітаємо! Оболонку " + barcode + " додано.");
                                        NextWindowDelegate handler = next_Window;
                                        Invoke(handler, new object[] { });
                                        //next_Window();
                                        break;
                                    case "0":
                                        MessageBox.Show("Ви приєднуєтесь до запакування оболонки " + barcode + ".");
                                        NextWindowDelegate handler1 = next_Window;
                                        Invoke(handler1, new object[] { });
                                        //next_Window();
                                        break;
                                    case "-1":
                                        MessageBox.Show("Оболонка " + barcode + " вже запакована."); break;
                                    case "-2":
                                        MessageBox.Show("Оболонка " + barcode + " вже вивантажена."); break;
                                    case "-99":
                                        MessageBox.Show("Некоректне ім'я оболонки " + barcode + "."); break;
                                    case "-":
                                        MessageBox.Show("Некоректне ім'я оболонки " + barcode + "."); break;
                                    case "99":
                                        MessageBox.Show("Оболонку " + barcode + " створено."); 
                                        NextWindowDelegate handler2 = next_Window;
                                        Invoke(handler2, new object[] { }); break;
                                    default:
                                        MessageBox.Show("Непередбачувана помилка: " + res + "."); break;

                                }
                                //ChangeStatusInLocalDB(Convert.ToInt32(barcodeData.Barcode_id));
                                myHttpWebResponse.Close();                              
                            }
                            else
                            {
                                MessageBox.Show("Помилка при відправці на сервер. HttpStatusCode<>OK");
                            }
                        }

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }, null);
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при відправці на сервер! Перевірте з'єднання з інтернетом. " + ex.Message);//
                return null;
            }
        }

        private void Packing_Closing(object sender, CancelEventArgs e)
        {
            //exitBtn_Click(sender, e);
            barcode_reader2.Stop();
            barcode_reader2.Dispose();

            this.Close(); // this.Dispose();
        }

        private void Packing_Load(object sender, EventArgs e)
        {
            //Создаем событие на чтение ШК сканером...
            barcode_reader2.ListChanged += new ListChangedEventHandler(reader_ListChanged);
            barcode_reader2.Start();
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            barcode_reader2.Stop();
            barcode_reader2.Dispose();

            this.Close(); //this.Dispose();
            Application.Exit();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }
    }
}