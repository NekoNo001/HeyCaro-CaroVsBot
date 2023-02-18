using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCaro
{
    public partial class Score : Form
    {
        public Score()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'banDiemCoCaroDataSet3.DiemCoCaro' table. You can move, or remove it, as needed.
            this.diemCoCaroTableAdapter2.Fill(this.banDiemCoCaroDataSet3.DiemCoCaro);
            // TODO: This line of code loads data into the 'banDiemCoCaroDataSet1.DiemCoCaro' table. You can move, or remove it, as needed.
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
