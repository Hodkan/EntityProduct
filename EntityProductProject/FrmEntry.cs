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
    public partial class FrmEntry : Form
    {
        public FrmEntry()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbEntityProductEntities db = new DbEntityProductEntities();
            var query = from x in db.TBLADMIN
                        where x.USERNAME == textBox1.Text && x.PASSWORD == textBox2.Text
                        select x;

            // if anything returns from the query
            if (query.Any())
            {
                FrmMain fr = new FrmMain();
                fr.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Invalid Login!");
            }
        }
    }
}
