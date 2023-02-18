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
    public partial class Mode : Form
    {
        public string do_kho= " ";
        public string name = " ";

        public Mode()
        {
            InitializeComponent();
        }


        #region Event
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            do_kho = "Easy";
            nhapten();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            do_kho = "Normal";
            nhapten();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            do_kho = "Hard";
            nhapten();
        }

        public void nhapten()
        {
            if (Name1.Text == "") 
            {
            MessageBox.Show("Vui lòng nhập tên","Thong bao"); 
            }
            else
            {
                name = Name1.Text;
                from1 fmfrom1 = new from1(Name1.Text,do_kho);
                fmfrom1.ShowDialog();
                this.Close();
            }
            
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
