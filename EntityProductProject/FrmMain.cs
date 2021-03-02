using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProductProject
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmStatistics frm = new FrmStatistics();
            frm.Show();
        }
    }
}
