using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CoCaro
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Mode fmMode = new Mode();
            fmMode.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Score frmbandiem = new Score();
            frmbandiem.Show();
         }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Quit();
        }

        void Quit()
        {
            Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)

                e.Cancel = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form3 fmcredits = new Form3();
            fmcredits.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
