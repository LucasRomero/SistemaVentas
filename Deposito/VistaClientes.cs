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
    public partial class VistaClientes : Form
    {
        public VistaClientes()
        {
            InitializeComponent();
        }

        private void VistaClientes_Load(object sender, EventArgs e)
        {
            Mostrar();
            OcultarColumnas();
        }

        public void Mostrar()
        {
            Gestion ges = new Gestion();
            dataVistaClientes.DataSource = ges.MostrarClientes();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataVistaClientes.Rows.Count);
        }
        public void OcultarColumnas()
        {
            dataVistaClientes.Columns[0].Visible = false;
        }

        public void BuscarCliente()
        {
            Gestion ges = new Gestion();
            dataVistaClientes.DataSource = ges.BuscarNombreCliente(txtBuscar.Text);
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataVistaClientes.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void obtenerdatos(ref string par1, ref string par2)
        {
            if(dataVistaClientes.CurrentRow  != null)
            {
                par1 = Convert.ToString(dataVistaClientes.CurrentRow.Cells["cuit"].Value);
                par2 = Convert.ToString(dataVistaClientes.CurrentRow.Cells["nombre"].Value);
            }
        }
        private void dataVistaClientes_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
