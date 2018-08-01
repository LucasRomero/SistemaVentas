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
    public partial class Productos : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            LlenarCMBCategorias();
            Limpiar();
            //dataProductos.Columns[0].Visible = false;
            nombresdecolumnas();
        }

        private void CompletarCodProducto()
        {
            using (SqlConnection conn = new SqlConnection("Data Source = localhost\\sqlexpress; Initial Catalog = Deposito; Integrated Security = True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(*) from Productos";
                Int32 count = (Int32)cmd.ExecuteScalar();
                count += 1;
                txtCod.Text = count.ToString();
            }
        }

        private void nombresdecolumnas()
        {
            dataProductos.Columns[0].HeaderText = "ID PRODUCTO";
            dataProductos.Columns[1].HeaderText = "NOMBRE PRODUCTO";
            dataProductos.Columns[2].HeaderText = "CODIGO DE CATEGORIA";
            dataProductos.Columns[3].HeaderText = "STOCK DISPONIBLE";
            dataProductos.Columns[4].HeaderText = "PUNTO DE PEDIDO";
            dataProductos.Columns[5].HeaderText = "CANTIDAD MINIMA PEDIDA";
            dataProductos.Columns[6].HeaderText = "PRECIO UNITARIO";
        }

        public void LlenarCMBCategorias()
        {
            Gestion ges = new Gestion();
            ges.MostrarCategorias();
            cmbCategoria.DataSource = ges.MostrarCategorias();
            cmbCategoria.ValueMember = "cod_categoria";
            cmbCategoria.DisplayMember = "nombre";
        }

        public void Limpiar()
        {
            txtCod.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cmbCategoria.Text = string.Empty;
            txtPuntopedido.Text = string.Empty;
            txtstock.Text = string.Empty;
            txtCantMinima.Text = string.Empty;
            txtPrecioU.Text = string.Empty;
        }

        public void Habilitar(bool valor) // si recibo true las cajas de texto dejan de ser ReadOnly y pueden editarse
        {
            txtNombre.ReadOnly = !valor;
            cmbCategoria.Enabled = valor;
            txtPuntopedido.ReadOnly = !valor;
            txtCantMinima.ReadOnly = !valor;
            txtstock.ReadOnly = !valor;
            txtPrecioU.ReadOnly = !valor;
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
            dataProductos.Columns[0].Visible = false;
            dataProductos.Columns[2].Visible = false;
        }

        public void MensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, " Error ", MessageBoxButtons.OK);
        }
        public void Mostrar()
        {
            Gestion ges = new Gestion();
            dataProductos.DataSource = ges.MostrarProductos();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataProductos.Rows.Count);
            OcultarColumnas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            dataProductos.DataSource = ges.BuscarNombreProducto(txtBuscar.Text);
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataProductos.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtNombre.Focus();
            CompletarCodProducto();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            string rpta = "";
            if (txtNombre.Text == string.Empty || cmbCategoria.Text == string.Empty || txtCod.Text == string.Empty)
            {
                MensajeError("Falta Ingresar algunos datos");
            }
            else
            {
                if (IsNuevo)
                {
                    //respuesta = ges.InsertarCategoria(txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim()); HACER ESTO sque insertarcodigo devuelva el string ese si esta bien o no el cargado 
                    rpta = ges.InsertarProducto(txtNombre.Text.Trim().ToUpper(), Convert.ToInt32(cmbCategoria.SelectedValue), txtstock.Text,
                        txtPuntopedido.Text, txtCantMinima.Text,Convert.ToDouble(txtPrecioU.Text));
                }
                else
                {
                    rpta = ges.EditarProducto(Convert.ToInt32(txtCod.Text),
                        txtNombre.Text.Trim().ToUpper(), Convert.ToInt32(cmbCategoria.SelectedValue), txtstock.Text,
                        txtPuntopedido.Text, txtCantMinima.Text);
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
            if (!txtCod.Text.Equals(""))
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            DialogResult opc;
            opc = MessageBox.Show("Realmente desea eliminar los registros", "Eliminacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opc == DialogResult.OK)
            {
                int codigo;
                string rpta = "";

                foreach (DataGridViewRow row in dataProductos.Rows)
                {
                    if (row.Selected)
                    {
                        codigo = Convert.ToInt32(row.Cells[0].Value);
                        rpta = ges.EliminarProducto(codigo);

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
                dataProductos.Columns[0].Visible = false;
                Mostrar();
            }
        }

        private void dataProductos_DoubleClick(object sender, EventArgs e)
        {
            txtCod.Text = Convert.ToString(dataProductos.CurrentRow.Cells["idproducto"].Value);
            txtNombre.Text = Convert.ToString(dataProductos.CurrentRow.Cells["nombre"].Value);
            cmbCategoria.SelectedValue = Convert.ToString(dataProductos.CurrentRow.Cells["cod_categoria"].Value);
            txtstock.Text = Convert.ToString(dataProductos.CurrentRow.Cells["stock"].Value);
            txtPuntopedido.Text = Convert.ToString(dataProductos.CurrentRow.Cells["punto_pedido"].Value);
            txtCantMinima.Text = Convert.ToString(dataProductos.CurrentRow.Cells["cant_minima"].Value);   
            tabControl1.SelectedIndex = 1;
        }

       /* private void dataProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataProductos.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataProductos.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }*/

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo permiten numeros", "Advertencia");
                e.Handled = true;
            }
        }

        private void txtPrecioU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo permiten numeros", "Advertencia");
                e.Handled = true;
            }
        }

        private void txtCantMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo permiten numeros", "Advertencia");
                e.Handled = true;
            }
        }

        private void txtPuntopedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo permiten numeros", "Advertencia");
                e.Handled = true;
            }
        }
    }
}