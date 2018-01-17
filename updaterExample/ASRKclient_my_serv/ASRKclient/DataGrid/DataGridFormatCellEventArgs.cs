using System;
using System.Windows.Forms;
using System.Drawing;

namespace DataGridTest.DataGrid
{
	public delegate void FormatCellEventHandler(object sender, DataGridFormatCellEventArgs e);

	public class DataGridFormatCellEventArgs : EventArgs
	{
		public int Row;
		public CurrencyManager Source;
		public Brush BackBrush;
		public Brush ForeBrush;

		public DataGridFormatCellEventArgs(int row, CurrencyManager manager)
		{
			this.Row = row;
			this.Source = manager;
		}
	}
}
