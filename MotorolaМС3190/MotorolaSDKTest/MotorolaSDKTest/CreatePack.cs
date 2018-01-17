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
    public partial class CreatePack : Form
    {
        public CreatePack()
        {
            InitializeComponent();
        }

        //Читает ШК SYMBOL
        private Symbol.Barcode.BarcodeReader barcode_reader = new Symbol.Barcode.BarcodeReader();
        void reader_ListChanged(object sender, ListChangedEventArgs e)
        {
            Symbol.Barcode.ReaderData nextReaderData = barcode_reader.ReaderData;
            if (nextReaderData.Result == Symbol.Results.SUCCESS)
            {
                tareTextBox.Text = nextReaderData.Text;
                var a = tareTextBox.Text;//
                /*var tare=tareTextBox.Text.Trim();//
                var indexTo = IndexToTextBox.Text.Trim();//
                var a = GeneratePack(tare, indexTo);//*/
                Pack p = new Pack();
                Pack.package = a;
               
                /*this.Hide();
                p.Closing += Frm2_Closing;*/
                if (barcode_reader != null)
                {
                    barcode_reader.Stop();
                    barcode_reader.Dispose();
                }

                this.Close();
                p.Show();
            }
            else
            {
                tareTextBox.Text = "Формат считанного Штрихового Кода - не распознан!";
                //Проигрываем звук - ненайденного ШК
                System.Media.SystemSounds.Exclamation.Play();
                System.Media.SystemSounds.Asterisk.Play();
                System.Media.SystemSounds.Exclamation.Play();
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
             //this.Dispose();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var tare=tareTextBox.Text.Trim();
            var indexTo=IndexToTextBox.Text.Trim();
            if ((tare != "") && (indexTo != ""))
            {
                try
                {
                    // PackType.package 
                    var a = GeneratePack(tare, indexTo);

                    if ((a!=null)&&(a != ""))// (PackType.package != "")
                    {
                        //MessageBox.Show(PackType.package);
                        Pack p = new Pack();
                        Pack.package = a;// PackType.package;
                       if (barcode_reader != null)
                        {
                            barcode_reader.Stop();
                            barcode_reader.Dispose();
                        }

                        this.Close();
                        p.Show();//
                        /* this.Dispose();////
                        this.Close(); ////
                        this.Hide();//
                        p.Closing += Frm2_Closing; //*/
                    }
                    else MessageBox.Show("Перевірте правильність індекса призначення контейнера");
                }
                catch (Exception ex) { MessageBox.Show(ex.StackTrace, ex.Message); }
            }
            else MessageBox.Show("Заповніть поля");
        }
        private void Frm2_Closing(object sender, EventArgs e)// FormClosingEventArgs e)
        {
            this.Close(); //this.Show();
        }

        private string GeneratePack(string tare, string indexTo)
        {
            var res = ServiceProxy.createShell(indexTo, Login.INDEX, Login.REGISTRARID, tare);
            if (res.status == 1)
            {
                return res.barcodeShell;
            }
            else return null;
        }

        private void CreatePack_Closing(object sender, CancelEventArgs e)
        {
            if (barcode_reader != null)
            {
                barcode_reader.Stop();
                barcode_reader.Dispose();
            }
           // this.Dispose();
        }

        private void CreatePack_Load(object sender, EventArgs e)
        {
            //Создаем событие на чтение ШК сканером...
            barcode_reader.ListChanged += new ListChangedEventHandler(reader_ListChanged);
            barcode_reader.Start();
        }
    }
}