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
    public partial class inicio : Form
    {
        public int tipo = 0;

        public inicio()
        {
            InitializeComponent();
        }

        public int login()
        {
            Datos ad = new Datos();
            SqlCommand cmd = new SqlCommand("ValidarUsuario", ad.ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = txtusuario.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtpass.Text;


            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[2].ToString() == "1") // mira si el estado es 1 osea DISPONIBLE
                {
                    tipo = dr.GetInt32(3);
                    this.Close();
                    return tipo;
                }
                else
                { MessageBox.Show("Usuario No Disponible"); }
            }
            else { MessageBox.Show("No ingresó con exito", "Advertencia"); }
            txtusuario.Text = "";
            txtpass.Text = "";
            txtusuario.Focus();
            return -1;
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
