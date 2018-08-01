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
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
        }
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private void Productos_Load(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            dataCategorias.DataSource = ges.MostrarCategorias();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataCategorias.Rows.Count);
            Habilitar(false);
            Botones();
            dataCategorias.Columns[0].Visible = false;
            nombresdecolumnas();
            Limpiar();
        }

        private void CompletarCodCategoria()
        {
            using (SqlConnection conn = new SqlConnection("Data Source = localhost\\sqlexpress; Initial Catalog = Deposito; Integrated Security = True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(*) from Categorias";
                Int32 count = (Int32)cmd.ExecuteScalar();
                count += 1;
                txtCod.Text = count.ToString();
            }
        }


        private void nombresdecolumnas()
        {
            dataCategorias.Columns[0].HeaderText = "CODIGO DE CATEGORIA";
            dataCategorias.Columns[1].HeaderText = "NOMBRE DE CATEGORIA";
            dataCategorias.Columns[2].HeaderText = "DESCRIPCION";

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            dataCategorias.DataSource = ges.BuscarNombreCategoria(txtBuscar.Text);
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataCategorias.Rows.Count);
        }
        // limpiar controlores del formulario
        private void Limpiar()
        {
            txtCod.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        public void Habilitar(bool valor) // si recibo true las cajas de texto dejan de ser ReadOnly y pueden editarse
        {
            txtNombre.ReadOnly = !valor;
            txtDescripcion.ReadOnly = !valor;
        }

        public void Mostrar()
        {
            Gestion ges = new Gestion();
            dataCategorias.DataSource = ges.MostrarCategorias();
            lbTotal.Text = "Total de Registros: " + Convert.ToString(dataCategorias.Rows.Count);
        }

        // botones habilitados
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

        public void SetearCodCategoria()
        {

        }

        public void OcultarColumnas()
        {
            dataCategorias.Columns[0].Visible = false; 
            dataCategorias.Columns[1].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            SetearCodCategoria();
            txtNombre.Focus();
            CompletarCodCategoria();
        }

        public void MensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, " Error ", MessageBoxButtons.OK);
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
                   rpta= ges.InsertarCategoria(txtNombre.Text.Trim().ToUpper(),
                        txtDescripcion.Text.Trim());
                }
                else
                {
                    rpta = ges.EditarCategoria(Convert.ToInt32(txtCod.Text),
                        txtNombre.Text.Trim().ToUpper(),
                        txtDescripcion.Text.Trim());
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

        private void dataCategorias_DoubleClick(object sender, EventArgs e)
        {
            txtCod.Text = Convert.ToString(dataCategorias.CurrentRow.Cells["cod_categoria"].Value);
            txtNombre.Text = Convert.ToString(dataCategorias.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataCategorias.CurrentRow.Cells["descripcion"].Value);

            tabControl1.SelectedIndex = 1;
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

        private void dataCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCod.Text = Convert.ToString(dataCategorias.CurrentRow.Cells["cod_categoria"].Value);
            txtNombre.Text = Convert.ToString(dataCategorias.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataCategorias.CurrentRow.Cells["descripcion"].Value);

            tabControl1.SelectedIndex = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Gestion ges = new Gestion();
            DialogResult opc;
            opc = MessageBox.Show("Realmente desea eliminar los registros", "Eliminacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(opc == DialogResult.OK)
            {
                int codigo;
                string rpta = "";

                foreach(DataGridViewRow row in dataCategorias.Rows)
                {
                    if (row.Selected)
                    {
                        codigo = Convert.ToInt32(row.Cells[0].Value);
                        rpta = ges.EliminarCategoria(codigo);

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
                dataCategorias.Columns[0].Visible = false;
                Mostrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsEditar = false;
            IsNuevo = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }
    }
}
