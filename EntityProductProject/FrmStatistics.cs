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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        DbEntityProductEntities db = new DbEntityProductEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLCATEGORY.Count().ToString();
            label3.Text = db.TBLPRODUCT.Count().ToString();
            label7.Text = db.TBLCUSTOMER.Count(x => x.STATUS == true).ToString();
            label9.Text = db.TBLCUSTOMER.Count(x => x.STATUS == false).ToString();
            label11.Text = db.TBLPRODUCT.Sum(x => x.STOCK).ToString();
            label19.Text = db.TBLSALES.Sum(x => x.PRICE).ToString();

            label13.Text = (from x in db.TBLPRODUCT orderby x.PRICE descending select x.PRODUCTNAME).FirstOrDefault();
            label15.Text = (from x in db.TBLPRODUCT orderby x.PRICE ascending select x.PRODUCTNAME).FirstOrDefault();

            label5.Text = db.TBLPRODUCT.Count(x => x.CATEGORY == 1).ToString();
            //Non repeat -- distinct count
            label17.Text = (from x in db.TBLCUSTOMER select x.CITY).Distinct().Count().ToString();

            label21.Text = db.GETBRAND().FirstOrDefault();

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
