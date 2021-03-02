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
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var catagories = (from x in db.TBLCATEGORY
                              select new
                              { x.ID, x.NAME }
                              ).ToList();

            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = catagories;

        }

        DbEntityProductEntities db = new DbEntityProductEntities();
        private void BtnList_Click(object sender, EventArgs e)
        {

            //dataGridView1.DataSource = db.TBLPRODUCT.ToList();
            dataGridView1.DataSource = (from x in db.TBLPRODUCT
                                        select new
                                        {
                                            x.PRODUCTID,
                                            x.PRODUCTNAME,
                                            x.BRAND,
                                            x.STOCK,
                                            x.PRICE,
                                            x.TBLCATEGORY.NAME,
                                            x.STATUS
                                        }).ToList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TBLPRODUCT tbl = new TBLPRODUCT();
            tbl.BRAND = txtBrand.Text;
            tbl.PRODUCTNAME = txtProduct.Text;
            tbl.STOCK = Convert.ToInt16(txtStock.Text);
            tbl.CATEGORY = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            tbl.PRICE = Convert.ToDecimal(txtPrice.Text);
            tbl.STATUS = true;

            db.TBLPRODUCT.Add(tbl);
            db.SaveChanges();

            MessageBox.Show("Product is saved");

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var product = db.TBLPRODUCT.Find(Convert.ToInt32(txtID.Text));
            db.TBLPRODUCT.Remove(product);
            db.SaveChanges();

            MessageBox.Show("The product is deleted.");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var product = db.TBLPRODUCT.Find(Convert.ToInt32(txtID.Text));
            product.BRAND = txtBrand.Text;
            product.PRODUCTNAME = txtProduct.Text;
            product.STOCK = Convert.ToInt16(txtStock.Text);
            //product.CATEGORY = Convert.ToInt32(comboBox1.Text);
            product.PRICE = Convert.ToDecimal(txtPrice.Text);
            product.STATUS = true;

            db.SaveChanges();

            MessageBox.Show("Product information is updated");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
