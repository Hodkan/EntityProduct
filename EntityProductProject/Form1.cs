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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        DbEntityProductEntities db = new DbEntityProductEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLCATEGORY.ToList();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBLCATEGORY t = new TBLCATEGORY();
            t.NAME = textBox2.Text;
            db.TBLCATEGORY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Category Added");
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var ctgry = db.TBLCATEGORY.Find(id);
            db.TBLCATEGORY.Remove(ctgry);
            db.SaveChanges();
            MessageBox.Show("Category Deleted");

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var ctgry = db.TBLCATEGORY.Find(id);
            ctgry.NAME = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Updated Successfully.");
        }
    }
}
