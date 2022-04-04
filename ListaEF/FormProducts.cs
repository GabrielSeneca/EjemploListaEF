using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaEF
{
    public partial class FormProducts : Form
    {
        NorthwindEntities bd = new NorthwindEntities();

        public FormProducts()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ProductName = txtProduct.Text,
            };
            bd.Products.Add(product);
            if (bd.SaveChanges() > 0)
            {
                MessageBox.Show("El Producto ha sido agregado");
            }
            else
            {
                MessageBox.Show("El Producto no pudo ser agregado");
            }
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.Products' Puede moverla o quitarla según sea necesario.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            dgvProductos.DataSource = bd.Products.ToList();
        }
    }
}
