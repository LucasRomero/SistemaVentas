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
    public partial class Camiones : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;
        int estado;

        public Camiones()
        {
            InitializeComponent();

        }

        private void Camiones_Load(object sender, EventArgs e)
        {
            LlenarCMBEstado();
            Mostrar();
            Habilitar(false);
            nombresdecolumnas();
        }

        private void nombresdecolumnas()
        {
            dataCamiones.Columns[0].HeaderText = "PATENTE";
            dataCamiones.Columns[1].HeaderText = "CARGA MAXIMA";
            dataCamiones.Columns[2].HeaderText = "ESTADO DEL CAMION";

        }

        public void LlenarCMBEstado()
        {
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Desactivo");
        }

        public void Limpiar()
        {
            txtcargamax.Text = string.Empty;
            txtPatente.Text = string.Empty;
            cmbEstado.Text = string.Empty;
        }

        public void Habilitar(bool valor) // si recibo true las cajas de texto dejan de ser ReadOnly y pueden editarse
        {
            txtcargamax.ReadOnly = !valor;
            txtPatente.ReadOnly = !valor;
            cmbEstado.Enabled = valor;
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

        public void MensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, " Error ", MessageBoxButtons.OK);
        }

        public void Mostrar()
        {
            Gestion ges = new Gestion();
            dataCamiones.DataSource = ges.MostrarCamiones();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataCamiones.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            dataCamiones.DataSource = ges.BuscarPatente(txtBuscar.Text);
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataCamiones.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtPatente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (cmbEstado.SelectedItem.ToString() == "Activo")
            {
                estado = 1;
            }
            if (cmbEstado.SelectedItem.ToString() == "Desactivado")
            {
                estado = 0;
            }
            Gestion ges = new Gestion();
            string rpta = "";
            if (txtPatente.Text == string.Empty || cmbEstado.Text == string.Empty || txtcargamax.Text == string.Empty)
            {
                MensajeError("Falta Ingresar algunos datos");
            }
            else
            {
                if (IsNuevo)
                {
                    //respuesta = ges.InsertarCategoria(txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim()); HACER ESTO sque insertarcodigo devuelva el string ese si esta bien o no el cargado 
                    rpta = ges.InsertarCamion(txtPatente.Text.Trim().ToUpper(),txtcargamax.Text,estado);
                }
                else
                {
                    rpta = ges.EditarCamion(txtPatente.Text.Trim().ToUpper(), txtcargamax.Text, estado);
                }
                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        MessageBox.Show("Se inserto de forma correcta el registro ", "WR Gestion");
                    }
                    else
                    {
                        MessageBox.Show("Se actualizo de forma correcta el registro ", "WR Gestion");
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
            if (!txtPatente.Text.Equals(""))
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

        private void dataCamiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataCamiones_DoubleClick(object sender, EventArgs e)
        {
            txtPatente.Text = Convert.ToString(dataCamiones.CurrentRow.Cells["patente"].Value);
            txtcargamax.Text = Convert.ToString(dataCamiones.CurrentRow.Cells["carga_max"].Value);
            cmbEstado.SelectedValue = Convert.ToString(dataCamiones.CurrentRow.Cells["estado"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            DialogResult opc;
            opc = MessageBox.Show("Realmente desea eliminar los registros", "Eliminacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opc == DialogResult.OK)
            {
                string patente;
                string rpta = "";
                foreach (DataGridViewRow row in dataCamiones.Rows)
                {
                    if (row.Selected)
                    {
                        patente = Convert.ToString(row.Cells[0].Value);
                        rpta = ges.EliminarCamion(patente);

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
                Mostrar();
            }
        }

        private void txtcargamax_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
        }
    }
}
