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
    public partial class Clientes : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            dataClientes.Columns[0].Visible = false;
            nombresdecolumnas();
        }

        private void nombresdecolumnas()
        {
            dataClientes.Columns[0].HeaderText = "CUIT";
            dataClientes.Columns[1].HeaderText = "NOMBRE";
            dataClientes.Columns[2].HeaderText = "TELEFONO";
            dataClientes.Columns[3].HeaderText = "DIRECCION";
            dataClientes.Columns[4].HeaderText = "LOCALIDAD";
            dataClientes.Columns[5].HeaderText = "EMAIL";
            dataClientes.Columns[6].HeaderText = "OBSERVACION";
        }

        private void Limpiar()
        {
            txtCuit.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDirecc.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtObs.Text = string.Empty;
        }

        public void Habilitar(bool valor) // si recibo true las cajas de texto dejan de ser ReadOnly y pueden editarse
        {
            txtNombre.ReadOnly = !valor;
            txtCuit.ReadOnly = !valor;
            txtTelefono.ReadOnly = !valor;
            txtDirecc.ReadOnly = !valor;
            txtLocalidad.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
            txtObs.ReadOnly = !valor;
        }

        public void Mostrar()
        {
            Gestion ges = new Gestion();
            dataClientes.DataSource = ges.MostrarClientes();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataClientes.Rows.Count);
        }

        public void Botones()
        {
            if (IsNuevo || IsEditar)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtCuit.Focus();
        }
        public void MensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, " Error ", MessageBoxButtons.OK);
        }

        public void OcultarColumnas()
        {
            dataClientes.Columns[0].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Gestion ges = new Gestion();
            string rpta = "";
            if (txtNombre.Text == string.Empty)
            {
                MensajeError("Falta Ingresar algunos datos");
            }
            else
            {
                if (IsNuevo)
                {

                    //respuesta = ges.InsertarCategoria(txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim()); HACER ESTO sque insertarcodigo devuelva el string ese si esta bien o no el cargado 
                    rpta = ges.InsertarCliente(txtCuit.Text.Trim(),
                         txtNombre.Text.Trim().ToUpper(),txtTelefono.Text,txtDirecc.Text,
                         txtLocalidad.Text,txtEmail.Text,txtObs.Text);
                }
                else
                {
                    rpta = ges.EditarCliente(txtCuit.Text.Trim(),
                         txtNombre.Text.Trim().ToUpper(), txtTelefono.Text, txtDirecc.Text,
                         txtLocalidad.Text, txtEmail.Text, txtObs.Text);
                }
                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        MessageBox.Show("Se inserto de forma correcta el registro ", "CODE");
                    }
                    else
                    {
                        MessageBox.Show("Se actualizo de forma correcta el registro ", "CODE");
                    }

                }
                else
                {
                    MensajeError("Error no se efectuo la operacion correctamente");
                }
                IsNuevo = false;
                IsEditar = false;
                Botones();
                Limpiar();
                Mostrar();

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtCuit.Text.Equals(""))
            {
                IsEditar = true;
                Botones();
                Habilitar(true);
            }
            else
            {
                MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsEditar = false;
            IsNuevo = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }

        private void dataClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataClientes.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataClientes.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dataClientes_DoubleClick(object sender, EventArgs e)
        {
            txtCuit.Text = Convert.ToString(dataClientes.CurrentRow.Cells["cuit"].Value);
            txtNombre.Text = Convert.ToString(dataClientes.CurrentRow.Cells["nombre"].Value);
            txtTelefono.Text = Convert.ToString(dataClientes.CurrentRow.Cells["telefono"].Value);
            txtDirecc.Text = Convert.ToString(dataClientes.CurrentRow.Cells["direccion"].Value);
            txtLocalidad.Text = Convert.ToString(dataClientes.CurrentRow.Cells["localidad"].Value);
            txtEmail.Text = Convert.ToString(dataClientes.CurrentRow.Cells["email"].Value);
            txtObs.Text = Convert.ToString(dataClientes.CurrentRow.Cells["observacion"].Value);
            tabControl1.SelectedIndex = 1;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            DialogResult opc;
            opc = MessageBox.Show("Realmente desea eliminar los registros", "Eliminacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opc == DialogResult.OK)
            {
                string cuit;
                string rpta = "";

                foreach (DataGridViewRow row in dataClientes.Rows)
                {
                    if (row.Selected)
                    {
                        cuit = Convert.ToString(row.Cells[0].Value);
                        rpta = ges.EliminarCliente(cuit);

                        if (rpta.Equals("OK"))
                        {
                            MessageBox.Show("Se elimino correctamente el registro");
                        }
                        else
                        {
                            MensajeError("No se elimino ocurrio un Error");
                        }
                    }
                }
                dataClientes.Columns[0].Visible = false;
                Mostrar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            dataClientes.DataSource = ges.BuscarNombreCliente(txtBuscar.Text);
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataClientes.Rows.Count);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo permiten numeros", "Advertencia");
                e.Handled = true;
            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo permiten numeros", "Advertencia");
                e.Handled = true;
            }
        }
    }
}
