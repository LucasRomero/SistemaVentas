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
    public partial class Usuarios : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        int tipo, estado;

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
           mostrar();
            Habilitar(false);
            agregarcmb();
            nombresdecolumnas();
        }

        private void nombresdecolumnas()
        {
            dataUsuarios.Columns[0].HeaderText = "DNI";
            dataUsuarios.Columns[1].HeaderText = "USUARIO";
            dataUsuarios.Columns[2].HeaderText = "PASSWORD";
            dataUsuarios.Columns[3].HeaderText = "ESTADO";
            dataUsuarios.Columns[4].HeaderText = "TIPO";
        }

        public void agregarcmb()
        {
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Desactivado");
            cmbTipo.Items.Add("Admin");
            cmbTipo.Items.Add("Ventas");
            cmbTipo.Items.Add("Expedicion");
        }
        public void mostrar()
        {
            Gestion ges = new Gestion();
            dataUsuarios.DataSource = ges.MostrarUsuarios();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataUsuarios.Rows.Count);
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
        public void OcultarColumnas()
        {
            dataUsuarios.Columns[0].Visible = false;
        }
        public void MensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, " Error ", MessageBoxButtons.OK);
        }

        private void Limpiar()
        {
            txtDNI.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtPass.Text = string.Empty;
            cmbEstado.Text = "";
            cmbTipo.Text= "";
        }
        public void Habilitar(bool valor) // si recibo true las cajas de texto dejan de ser ReadOnly y pueden editarse
        {

            txtDNI.ReadOnly = !valor;
            txtUsuario.ReadOnly = !valor;
            txtPass.ReadOnly = !valor;
            cmbEstado.Enabled = valor;
            cmbTipo.Enabled = valor;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsEditar = false;
            IsNuevo = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {   
            if (!txtDNI.Text.Equals(""))
            {
                IsEditar = true;
                Botones();
                Habilitar(true);
                txtDNI.Focus();
            }
            else
            {
                MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            Gestion ges = new Gestion();
            string rpta = "";
            if (cmbTipo.Text == string.Empty || cmbEstado.Text == string.Empty)
            {
                MensajeError("Falta Ingresar algunos datos");
            }
            else
            {
                if (cmbTipo.SelectedItem.ToString() == "Admin")
                {
                    tipo = 1;
                }
                if (cmbTipo.SelectedItem.ToString() == "Ventas")
                {
                    tipo = 2;
                }
                if (cmbTipo.SelectedItem.ToString() == "Expedicion")
                {
                    tipo = 3;
                }
                if (cmbEstado.SelectedItem.ToString() == "Activo")
                {
                    estado = 1;
                }
                if (cmbEstado.SelectedItem.ToString() == "Desactivado")
                {
                    estado = 0;
                }
                if (txtDNI.Text == string.Empty || txtUsuario.Text == string.Empty || txtPass.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos datos");
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = ges.NuevoUsuario(txtDNI.Text.Trim().ToUpper(), txtUsuario.Text, txtPass.Text, tipo, estado);
                    }
                    else
                    {
                        rpta = ges.EditarUsuario(txtDNI.Text.Trim().ToUpper(), txtUsuario.Text, txtPass.Text, tipo, estado);
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
                }
                IsNuevo = false;
                IsEditar = false;
                Botones();
                Limpiar();
                mostrar();

            }
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
                string dni;
                string rpta = "";

                foreach (DataGridViewRow row in dataUsuarios.Rows)
                {
                    if (row.Selected)
                    {
                        dni = Convert.ToString(row.Cells[0].Value);
                        rpta = ges.EliminarUsuario(dni);

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
                dataUsuarios.Columns[0].Visible = false;
                mostrar();
            }
        }

        private void dataUsuarios_DoubleClick(object sender, EventArgs e)
        {
            txtDNI.Text = Convert.ToString(dataUsuarios.CurrentRow.Cells["dni"].Value);
            txtUsuario.Text = Convert.ToString(dataUsuarios.CurrentRow.Cells["Usuario"].Value);
            txtPass.Text = Convert.ToString(dataUsuarios.CurrentRow.Cells["Password"].Value);
            cmbEstado.SelectedValue = Convert.ToString(dataUsuarios.CurrentRow.Cells["Estado"].Value);
            cmbTipo.SelectedValue = Convert.ToString(dataUsuarios.CurrentRow.Cells["Tipo"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtDNI.Focus();
        }
    }
}
