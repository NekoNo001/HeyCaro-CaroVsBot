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

namespace CoCaro
{
    public partial class from1 : Form
    {
        #region Properties
        ChessBoardsetup banco;
        #endregion
        public from1(string name, string mode)
        {
            InitializeComponent();

            banco = new ChessBoardsetup(pnlbanco,sonuocdi, txtplayername, txtmode);
            banco.Player[0].Name = name;
            banco.Player[0].Mode = mode;
            txtplayername.Text = name;
            txtmode.Text = mode;
            newgame();
        }

        void newgame()
        {
            banco.reset();
            banco.vebanco();

        }

        void Quit()
        {
            this.Close();
        }


        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newgame();

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void from1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn về thoát game hiện tại?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)

                e.Cancel = true;
        }

        private void from1_Load(object sender, EventArgs e)
        {
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Score frmbandiem = new Score();
            frmbandiem.Show();
        }


        private void pnlbanco_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
