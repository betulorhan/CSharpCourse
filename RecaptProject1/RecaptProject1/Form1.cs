using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecaptProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();   
        }

        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList(); // Veritabanındaki products tablosunu datagriedviewde işleme 
            }
        }

        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();   
                cbxCategory.DisplayMember = "CategoryName"; // Categoryde kayıtlı isimleri seçtik
                cbxCategory.ValueMember = "CategoryId"; // Seçili categoryi idye göre getir.
            }
        }

        private void ListProductsByCategoryId(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p=>p.CategoryId == categoryId).ToList();
                // Ürünleri category idleri, parametre olarak verilen categoryId ile aynı olanlara göre listele. 
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(cbxCategory.SelectedValue.ToString()); // CBX'tan seçilen ürüne göre, ürüne ait idyi mesaj olarak yazdırdık. 

            try
            {
                ListProductsByCategoryId(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }
            
        }
    }
}
