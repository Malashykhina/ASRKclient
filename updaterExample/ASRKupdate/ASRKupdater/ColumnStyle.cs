using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace testSqLite
{
    public class ColumnStyle : DataGridTextBoxColumn
    {
        //public event CheckCellEventHandler CheckCellEven;
        //public event CheckCellEventHandler CheckCellContains;
        //public event CheckCellEventHandler CheckCellEquals;

        private int _col;

        public ColumnStyle(int column)
        {
            _col = column;
        }

        protected override void Paint(Graphics g, Rectangle Bounds, CurrencyManager Source, int RowNum, Brush BackBrush, Brush ForeBrush, bool AlignToRight)
        {//
            //DataGridEnableEventArgs e = new DataGridEnableEventArgs(RowNum, _col, false);//true, enabled(інший стиль для selected)
            /*if (CheckCellEven != null)
            {
                DataGridEnableEventArgs e = new DataGridEnableEventArgs(RowNum, _col, false);
                CheckCellEven(this, e); 
                if (e.MeetsCriteria)
                    BackBrush = new SolidBrush(Color.Green);
                else
                    BackBrush = new SolidBrush(Color.Orange);
            }*/
            //CheckCellEquals(this, e);
            DataGridEnableEventArgs e = new DataGridEnableEventArgs(RowNum, _col, false);//true, enabled(інший стиль для selected)
            //CheckCellEven(this, e); 
            if (e.MeetsCriteria)
            BackBrush = new SolidBrush(Color.Green);
            else
                BackBrush = new SolidBrush(Color.Orange);
            base.Paint(g, Bounds, Source, RowNum, BackBrush, ForeBrush, AlignToRight);


        }

    }
    public delegate void CheckCellEventHandler(object sender, DataGridEnableEventArgs e);

    public class DataGridEnableEventArgs : EventArgs
    {
        private int _column;
        private int _row;
        private bool _meetsCriteria;

        public DataGridEnableEventArgs(int row, int col, bool val)
        {
            _row = row;
            _column = col;
            _meetsCriteria = val;
        }

        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        public bool MeetsCriteria
        {
            get {return _meetsCriteria; }// Random rnd = new Random(1); return rnd.Next() == 1 ? true : false; }// _meetsCriteria; }
            set { _meetsCriteria = value; }
        }
    }


}
