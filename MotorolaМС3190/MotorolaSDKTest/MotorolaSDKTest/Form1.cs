using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MotorolaSDKTest
{
    public partial class Form1 : Form
    {
        public Form1()
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
                textBox1.Text = nextReaderData.Text;
            }
            else
            {
                textBox1.Text = "Формат считанного Штрихового Кода - не распознан!";
                //Проигрываем звук - ненайденного ШК
                    System.Media.SystemSounds.Exclamation.Play();
                    System.Media.SystemSounds.Asterisk.Play();
                    System.Media.SystemSounds.Exclamation.Play();
                    System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //При закрытии не забыть остановить и очистить, иначе повиснет.
            barcode_reader.Stop();
            barcode_reader.Dispose();

            this.Dispose();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Создаем событие на чтение ШК сканером...
            barcode_reader.ListChanged += new ListChangedEventHandler(reader_ListChanged);
            barcode_reader.Start();

            //Форму во весь экран.
            this.MinimizeBox = true;

        }
    }
}