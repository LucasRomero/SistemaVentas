using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Deposito
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        public void PegarIDClientNombreYapellidodeCliente(string idCliente, string apellidoynombre)
        {
            txtIDCliente.Text = idCliente;
            txtCliente.Text = apellidoynombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaArticulos vistaArt = new VistaArticulos();
            vistaArt.ShowDialog();
            string nombre = "";
            string pu = "";
            string stock = "";
            string cantmin = "";
            vistaArt.obtenerdatos(ref nombre, ref pu, ref stock,ref cantmin);
            txtArticulo.Text = nombre;
            txtPU.Text = pu;
            txtStock.Text = stock;
            txtCantidadMin.Text = cantmin;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
            dtFechaVenta.Enabled = true;
            txtCliente.Enabled = true;
            txtIDCliente.Enabled = true;
            txtArticulo.Enabled = true;
            txtCantidad.Enabled = true;
            BtnBuscarCliente.Enabled = true;
            BtnMasArticulos.Enabled = true;
            txtPU.Enabled = true;
            txtStock.Enabled = true;
            txtCantidadMin.Enabled = true;
            BtnAgregarLinea.Enabled = true;
            completarNroPedido();
        }

        private void completarNroPedido()
        {
            using (SqlConnection conn = new SqlConnection("Data Source = localhost\\sqlexpress; Initial Catalog = Deposito; Integrated Security = True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(*) from Productos";
                Int32 count = (Int32)cmd.ExecuteScalar();
                count += 1;
                txtIDNroPedido.Text = count.ToString();
            }
        }

        private void BtnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            VistaClientes vistacli = new VistaClientes();
            vistacli.ShowDialog();
            string par1 = "";
            string par2 = "";
            vistacli.obtenerdatos(ref par1, ref par2);
            txtIDCliente.Text = par1;
            txtCliente.Text = par2;
        }
    }
}
