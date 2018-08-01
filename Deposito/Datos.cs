using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Deposito

{
    class Datos
    {

        string rutaNeptunoSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=Deposito;Integrated Security=True"; // ruteo de la DB

        public SqlConnection ObtenerConexion()
        {
            SqlConnection con = new SqlConnection(rutaNeptunoSQL);

            con.Open();
            return con;
        }

        public void BackUp()
        {
            SqlCommand cmd = new SqlCommand("backupdb", ObtenerConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            MessageBox.Show("El BackUp fue realizado con exito");
        }

        public void AbrirManualdeUsuario()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Users\\Administrador\\Desktop\\WR\\Deposito\\Resources\\ManualWR.pdf";
            proc.Start();
            proc.Close();
        }

        public SqlDataAdapter ObtenerAdaptador(String consultaSql)
        {
            SqlDataAdapter adaptador;
            adaptador = new SqlDataAdapter(consultaSql, rutaNeptunoSQL);
            return adaptador;
        }

        /*  private void AgregarTablaDataSetSQLServer(string ConexionBD, string ConsultaSQL,
                                    string NombreTabla, ref DataSet ds)
          {
              SqlConnection cn = new SqlConnection(ConexionBD);
              SqlDataAdapter adaptador = new SqlDataAdapter(ConsultaSQL, cn);
              cn.Open();
              adaptador.Fill(ds, NombreTabla);
              cn.Close();
          }
          */
          

    }
}
