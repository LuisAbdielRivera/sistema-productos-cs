using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudProducts
{
    public partial class Form1 : Form
    {
        private ConexionProductosDataContext conexion = new ConexionProductosDataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = conexion.LeerProducto_Test();
        }

        private void Limpiar()
        {
            tbProducto.Text = "";
            tbPrecio.Text = "";
            tbCantidad.Text = "";
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            tbPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            tbCantidad.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            conexion.InsertarProductos_Test(tbProducto.Text, 
                Convert.ToDecimal(tbPrecio.Text), 
                Convert.ToInt16(tbCantidad.Text));

            MessageBox.Show("Producto Insertado");

            dgvProductos.DataSource = conexion.LeerProducto_Test();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);

            conexion.EliminarProducto_Test(idProducto);

            MessageBox.Show("Producto Eliminado");

            dgvProductos.DataSource = conexion.LeerProducto_Test();
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);

            conexion.ActualizarProducto_Test(
                tbProducto.Text, 
                Convert.ToDecimal(tbPrecio.Text), 
                Convert.ToInt16(tbCantidad.Text), 
                idProducto
                );

            MessageBox.Show("Producto Actualizado");

            dgvProductos.DataSource = conexion.LeerProducto_Test();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
