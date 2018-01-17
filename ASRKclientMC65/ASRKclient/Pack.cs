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
    public partial class Pack : Form
    {
        public Pack()
        {
            InitializeComponent();
            //barcode_reader1.Parameters.BeepTime = 0;//прибрати звук
        }

        public static string package;
        public static string numberOfThings;
        public static string numberOfThingsUser;

        public List<BarcodeData> barcodeDataList = new List<BarcodeData>();
        private Symbol.Barcode.BarcodeReader barcode_reader1 = new Symbol.Barcode.BarcodeReader();
        public delegate void ChangeStatusInLocalDBDelegate(int message);
        public delegate void UpdateDelegate();
        public delegate void UpdateNumberDelegate(string number);

        private bool WriteBarcode(string barcode)
        {
            try
            {
                var result= ServiceProxy.packShell(barcode, Login.INDEX, package, Login.REGISTRARID);
                switch (result.status)
                    {
                        case 1: 
                                ChangeStatusInList(barcode, 1);
                                numberOfThings = result.pack.ToString();
                                numberOfThingsUser = result.packUser.ToString();
                                UpdateNumberDelegate handler3 = DrowNumber;
                                Invoke(handler3, new object[] { numberOfThings + "/" + numberOfThingsUser });
                                break;
                        case -990: MessageBox.Show("Поштове відправлення зі штрихкодом " + barcode + " не знайдено серед прийнятої пошти (гілка «Сканована на вхід»)."); ChangeStatusInList(barcode, -1); break;
                        case -999: MessageBox.Show("Штрихкод " + barcode + " не знайдено."); ChangeStatusInList(barcode, -1); break;
                        case -998: MessageBox.Show("Штрихкод " + barcode + " являється оболонкою."); ChangeStatusInList(barcode, -1); break;
                        case -997: MessageBox.Show("Штрихкод " + barcode + " не знайдено на індексі " + Login.INDEX); ChangeStatusInList(barcode, -1); break;
                        case -996: MessageBox.Show("Статус оболонки " + package + " !=0 "); ChangeStatusInList(barcode, -1); break;
                        case -1: MessageBox.Show("Штрихкод уже запакований в дану оболонку"); break;
                        case -2: MessageBox.Show("Штрихкод уже вивантажено в АСРК (статус -2)"); ChangeStatusInList(barcode, -1); break;
                        case 2: MessageBox.Show("Штрихкод уже вивантажено в АСРК (статус 2)"); ChangeStatusInList(barcode, -1); break;
                        case -994: MessageBox.Show("Штрихкод запаковано в іншу оболонку"); ChangeStatusInList(barcode, -1); break;

                    //-999 если не найден баркод
                    //-barcode.getStatus() если статус баркода не 0 и не 99
                    //-998 если баркод является шеллом (операция 20201)
                    //-997 если не найден текой шелл для данного отделения
                    //-996 если шелл имеет статус не 0 (то есть уже запакован или отменен)
                      //-1 если упакован в текущий шелл
                    //-994 если упакован в другой шелл


                        default:
                            {
                                MessageBox.Show("Статус = " + result.status); ChangeStatusInList(barcode, -1); break;                              
                            }
                            UpdateDelegate handler = DrowFromLocalDB;
                            Invoke(handler, new object[] { });
                    }
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
       
        private void menuItem1_Click(object sender, EventArgs e)
        {
            barcode_reader1.Stop();
            barcode_reader1.Dispose();

            this.Close(); //this.Dispose();
            Application.Exit();
        }

        private void finish_Click(object sender, EventArgs e)
        {
            try
            {
                var res = ServiceProxy.finishShell(Login.INDEX, package);
                switch (res.status)
                {
                    case 1:
                        MessageBox.Show("Сканування оболонки " + package + " завершено. Запаковано " + res.inShell.ToString() + " речей.");
                        close(); break;
                    default:
                        MessageBox.Show("Статус " + res.status); break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void close(){
            barcode_reader1.Stop();
            barcode_reader1.Dispose();

            //this.Dispose();
            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            barcode_reader1.Stop();
            barcode_reader1.Dispose();

            this.Close(); //this.Dispose();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            //DeleteAllFromLocalDB();//TO DO!!!
            barcodeDataList = new List<BarcodeData>();
            DrowFromLocalDB();
        }


        //відображення локальної БД
        private void DrowFromLocalDB()
        {
            //System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch(); // создаем объект
            //swatch.Start(); // старт
            //// Тут код

            
            try
                {
                    listView1.Items.Clear();//
                    if (barcodeDataList != null)
                    {
                      // MessageBox.Show(barcodeDataList.Count.ToString());
                       for (int i = 0; i < barcodeDataList.Count; i++)
                        {
                            //MessageBox.Show(barcodeDataList.Count.ToString());
                            var lvi = new ListViewItem(barcodeDataList[i].Barcode_value.ToString());
                            if (barcodeDataList[i].Status.ToString() == "0")
                            {
                                lvi.BackColor = Color.LightGoldenrodYellow;
                            }
                            else if (barcodeDataList[i].Status.ToString() == "-1")
                            { lvi.BackColor = Color.LightCoral; }
                            else
                            {
                                lvi.BackColor = Color.LightGreen;
                            }
                            listView1.Items.Add(lvi);
                        }
                    }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            //swatch.Stop(); // стоп
            //MessageBox.Show(swatch.Elapsed.ToString()); 
        }
        //відображення локальної БД інверсно
        private void DrowFromLocalDBinv()
        {
            try
            {
                listView1.Items.Clear();//
                if (barcodeDataList != null)
                {
                    // MessageBox.Show(barcodeDataList.Count.ToString());
                    for (int i = barcodeDataList.Count-1; i >= 0; i--)
                    {
                        //MessageBox.Show(barcodeDataList.Count.ToString());
                        var lvi = new ListViewItem(barcodeDataList[i].Barcode_value.ToString());
                        if (barcodeDataList[i].Status.ToString() == "0")
                        {
                            lvi.BackColor = Color.LightGoldenrodYellow;
                        }
                        else if (barcodeDataList[i].Status.ToString() == "-1")
                        { lvi.BackColor = Color.LightCoral; }
                        else
                        {
                            lvi.BackColor = Color.LightGreen;
                        }
                        listView1.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DrowNumber(string number) {
            count.Text = number;// numberOfThings;
        }
      
        //Процедура работает при получении новых данных со считывателя.
        void reader_ListChanged(object sender, ListChangedEventArgs e)
        {
            //task1  
            barcode_reader1.Parameters.BeepTime = 0;//////
            var s = ScanBarcodes();//"2900400196018"; //"567812345678" //сканувати
            if (s != null)
            {
                textBox1.Text = s;
                //додати унікальну
                AddItem(barcodeDataList, new BarcodeData() { Barcode_id = barcodeDataList.Count(), Barcode_value = s, Status = 0 });
               // barcodeDataList.Add(new BarcodeData() { Barcode_id=barcodeDataList.Count(), Barcode_value=s, Status=0});// SaveIntoLocalDB(s);
                DrowFromLocalDBinv();// DrowFromLocalDB();//відображення 
                peopleDataSource.DataSource = barcodeDataList;

               WriteBarcode(s);//,"1");//WriteBarcode(string barcode, string status)// 
            }
        }

        private int AddItem(List<BarcodeData> list, BarcodeData newItem)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Barcode_value == newItem.Barcode_value)
                {
                    return -1;
                }
            }
            list.Add(newItem);
            return 1;
        }
        private string readTagByTagName(string source, string tagName)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(source)))
            {
                reader.ReadToFollowing(tagName);
                return reader.ReadElementContentAsString();
            }
        }
       public class RespStructure
        {
            public string UNID;//64F65A6215179881C22581B1002598E5</UNID>
            public int REALENTRIESTOTAL;//96
            public int SCANED;//29
        }
       
        //сканувати штрихкод
        private string ScanBarcodes()
        {
            Symbol.Barcode.ReaderData nextReaderData = barcode_reader1.ReaderData;
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
       
        BindingSource peopleDataSource = new BindingSource();//!!!
        private void Pack_Load(object sender, EventArgs e)
        {
            //Создаем событие на чтение ШК сканером...
            barcode_reader1.ListChanged += new ListChangedEventHandler(reader_ListChanged);
            barcode_reader1.Start();
            //DrowFromLocalDB();
            shell.Text = package;
        }

        private void Pack_Closing(object sender, CancelEventArgs e)
        {
            barcode_reader1.Stop();
            barcode_reader1.Dispose();

            this.Close(); //this.Dispose();
            //exitBtn_Click(sender, e);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var s = textBox1.Text.Trim();// ScanBarcodes();//"2900400204932";//"567812345678" //сканувати
                if (s != null)
                {
                    textBox1.Text = s;
                    AddItem(barcodeDataList, new BarcodeData() { Barcode_id = barcodeDataList.Count(), Barcode_value = s, Status = 0 });
               
                    DrowFromLocalDBinv();// DrowFromLocalDB();//відображення //
                    peopleDataSource.DataSource = barcodeDataList;

                    WriteBarcode(s);//, "1");//

                }
            }
        }
        //позначка що відправили на сервер
        public void ChangeStatusInList(string barcode, int status)
        {
            var t = ((BarcodeData)barcodeDataList.First(s => s.Barcode_value == barcode)).Status = status;//.ToString();//.Where instead of .First

            DrowFromLocalDBinv();// DrowFromLocalDB();//!!!!!!винести//
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked == true)
                {
                    MessageBox.Show("Cansel of " + listView1.Items[i].Text);
                    try
                    {
                        barcodeDataList.RemoveAt(i);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.StackTrace, ex.Message); }
                }
            }
            DrowFromLocalDB();
        }

    }
}