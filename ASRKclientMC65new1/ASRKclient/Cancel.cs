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

namespace ASRKclient
{
    public partial class Cancel : Form
    {
        public Cancel()
        {
            InitializeComponent();
            //barcode_reader.Parameters.BeepTime = 0;
        }
        public delegate void CancelDelegate();

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var s = comboBox1.SelectedItem.ToString();//textBox1.Text;//PackType.package = "123";
                if (s != "")
                {
                    CancelShell(s, "99");    //textBox1.Text 
                }
            }
            else MessageBox.Show("Будь ласка оберіть штрихкод оболонки");       
        }
        //private Symbol.Barcode.BarcodeReader barcode_reader = new Symbol.Barcode.BarcodeReader();

        private void CancelShell(string barcode, string status)
        {
            try
            {
                //MessageBox.Show("barcode: " + barcode + ". Статус: " + status);
                var t = ServiceProxy.cancelShell(Login.INDEX, Login.REGISTRARID, barcode);
                switch (t.status) {
                    case 0: MessageBox.Show("Оболонку " + barcode + " скасовано."); break;
                    case -99: MessageBox.Show("Оболонка " + barcode + " має статус скасованої."); break;
                    case -999: MessageBox.Show("Оболонку " + barcode + " не знайдено."); break;
                    case -1: MessageBox.Show("Оболонку " + barcode + " вже запаковано."); break;
                    case -2: MessageBox.Show("Оболонку " + barcode + " вже вивантажено в АСРК."); break;
                    default: MessageBox.Show("Операцію завершено зі статусом " + t.status); break;
                }
               // MessageBox.Show("Оболонку " + barcode+ " скасовано.");// + t.status + ". cancel: " + t.cancel);//
            }
            catch (Exception ex) {
                 //MessageBox.Show("Не знайдено оболонку");
               MessageBox.Show(ex.Message);
            }
        }

        private void CancelShellOld(string barcode, string status)
        {
            try
            {
                string url = "http://10.49.170.56:61090/Barcode.svc/CancelPackingShell/" + barcode +
                   // "/" + Login.LOGIN +
                    "/" + status + "/" + Login.INDEX;
                //CancelPackingShell/55/99/03993

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
                                 //MessageBox.Show("ok", res2);//
                                try{
                                int res3 = Convert.ToInt32(res2);
                                if (res3 > 0)
                                {
                                    MessageBox.Show("Кількість речей в скасованій оболонці рівна " + (res3 - 1).ToString() + ". Оболонка " + barcode + " скасована.");
                                    this.Close();
                                }
                                else
                                {
                                    switch (res3)
                                    {
                                        //case 1:
                                        //    MessageBox.Show("Оболонка " + barcode + " скасована.");
                                        //    this.Close();
                                        //    break;
                                        case 0:
                                            MessageBox.Show("Оболонку " + barcode + " не знайдено."); break;
                                        case -2:
                                            MessageBox.Show("Оболонка " + barcode + " вже вивантажена."); break;
                                        case -99:
                                            MessageBox.Show("Не знайдено " + barcode + " на індексі " + Login.INDEX); break;
                                        default:
                                            MessageBox.Show("Непередбачувана помилка: " + res + "."); break;

                                    }
                                }
                                }
                                    catch (Exception exept){ MessageBox.Show("Непередбачувана помилка: " + res + "."); }
                                

                                
                                //ChangeStatusInLocalDB(Convert.ToInt32(barcodeData.Barcode_id));
                                myHttpWebResponse.Close();
                                CancelDelegate handler = this.Close;
                                Invoke(handler, new object[] { });
                                //this.Close();///////////

                                /*Stream dataStream = response.GetResponseStream();
                                // Open the stream using a StreamReader for easy access.
                                StreamReader reader = new StreamReader(dataStream);
                                // Read the content.
                                string responseFromServer = reader.ReadToEnd();
                                reader.Close();
                                dataStream.Close();
                                res = responseFromServer.ToString();*/


                            }
                            else
                            {
                                MessageBox.Show("Помилка при відправці на сервер. HttpStatusCode<>OK");
                            }
                        }

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }, null);
                //return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при відправці на сервер! Перевірте з'єднання з інтернетом. " + ex.Message);//
                //return null;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
           /* barcode_reader.Stop();
            barcode_reader.Dispose();*/
            this.Close();
            //this.Dispose();
            Application.Exit();
        }

        private void Cancel_Load(object sender, EventArgs e)
        {
           /* barcode_reader.ListChanged += new ListChangedEventHandler(reader_ListChanged);
            barcode_reader.Start();*/


            var res = ServiceProxy.getUnpackedShells(Login.INDEX);
            if (res.shell != null)
            {
                for (int i = 0; i < res.shell.Length; i++)
                {
                    string s = res.shell[i];
                    comboBox1.Items.Add(s);
                }
            }


            //DrowFromLocalDB();
        }

        private void Cancel_Closing(object sender, CancelEventArgs e)
        {
           /* barcode_reader.Stop();
            barcode_reader.Dispose();*/
            this.Close();//
            //this.Dispose();
        }

        //Процедура работает при получении новых данных со считывателя.
       /* void reader_ListChanged(object sender, ListChangedEventArgs e)
        {
            //task1  
            //barcode_reader.Parameters.BeepTime = 0;////
            var s = ScanBarcodes();//"2900400204932";//"567812345678" //сканувати
            if (s != null)
            {
                textBox1.Text = s;
                CancelShell(s, "99");  
                //SaveIntoLocalDB(s);
                //DrowFromLocalDB();//відображення 
                //barcodeDataList = SelectAllBarcodesFromDB();//!!!!!!!!!!!!!!!!
                //dataGrid1.DataSource = barcodeDataList;
                ////peopleDataSource.DataSource = barcodeDataList;

                ////var barcodeData = SelectFirstUnchecked();
                ////if (barcodeData != null)
                ////{
                ////    //SendOnServer(s);
                ////    SendBarcodeStatus(barcodeData, "1", "0");
                ////    //DrowFromLocalDB();
                ////}
            }
        }*/
        //сканувати штрихкод
       /* private string ScanBarcodes()
        {
            Symbol.Barcode.ReaderData nextReaderData = barcode_reader.ReaderData;
            if (nextReaderData.Result == Symbol.Results.SUCCESS)
            {
                ////if (isRegistered(nextReaderData.Text))
                ////{
                ////    //MessageBox.Show("Такий штрихкод в системі вже зафіксовано", "Помилка");//Формат считанного Штрихового Кода - не распознан
                ////    ////Проигрываем звук - ненайденного ШК
                ////    //System.Media.SystemSounds.Exclamation.Play();
                ////    //System.Media.SystemSounds.Asterisk.Play();
                ////    //System.Media.SystemSounds.Exclamation.Play();
                ////    //System.Media.SystemSounds.Asterisk.Play();
                ////    return null;
                ////}
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
        */
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}