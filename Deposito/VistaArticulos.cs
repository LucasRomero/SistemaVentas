using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deposito
{
    public partial class VistaArticulos : Form
    {
        public VistaArticulos()
        {
            InitializeComponent();
            Mostrar();
            OcultarColumnas();
        }
        public void Mostrar()
        {
            Gestion ges = new Gestion();
            dataVistaProductos.DataSource = ges.MostrarProductos();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataVistaProductos.Rows.Count);
        }
        public void OcultarColumnas()
        {
            dataVistaProductos.Columns[0].Visible = false;
        }

        public void BuscarProducto()
        {
            Gestion ges = new Gestion();
            dataVistaProductos.DataSource = ges.BuscarNombreCliente(txtBuscar.Text);
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataVistaProductos.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }
        public void obtenerdatos(ref string nombre,ref string pu, ref string stock,ref string cantmin)
        {
            if(dataVistaProductos.CurrentRow != null)
            {
                nombre = Convert.ToString(dataVistaProductos.CurrentRow.Cells["nombre"].Value);
                pu = Convert.ToString(dataVistaProductos.CurrentRow.Cells["precio_unitario"].Value);
                stock = Convert.ToString(dataVistaProductos.CurrentRow.Cells["stock"].Value);
                cantmin = Convert.ToString(dataVistaProductos.CurrentRow.Cells["cant_minima"].Value);
            }  
        }

        private void dataVistaProductos_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
