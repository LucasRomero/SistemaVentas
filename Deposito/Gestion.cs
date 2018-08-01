using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Deposito
{
    class Gestion
    {
        // este es GENERICO PARA TODOS, ejecuta el procedimiento almacenado de todos
        public string EjecutarProcedimientoAlmacenado(SqlCommand comando, string nombresp) 
        {
            string rpta = "";
            Datos ad = new Datos();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = nombresp;
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataReader dr = cmd.ExecuteReader(); // ver como hacer para devolver un verdadero o falso, por q no esta funcionando 
            rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "Error";
            return rpta;
        }

        // parametros usuario
        public void ArmarParametrosEliminarUsuario(ref SqlCommand comando, string ideliminar)
        {
            //SqlParameter Sqlparametros = new SqlParameter();
            comando.Parameters.Add("@IDUSUARIO", SqlDbType.VarChar,30).Value = ideliminar;
            
        }
        // eliminar usuario
        public string EliminarUsuario(string ideliminar) // poner esto en una clase de gestion de form y tablas y etc
        {
            string rpta = "";
           // Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminarUsuario(ref comando, ideliminar);
            rpta =EjecutarProcedimientoAlmacenado(comando, "spEliminarUsuario");
            return rpta;   
        }

        // parametros nuevo usuario
        public void ArmarProcedimientoNuevoUSuario(ref SqlCommand comando, string dni, string usuario, string pass, int tipo, int estado)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@dni", SqlDbType.VarChar, 20);
            SqlParametros.Value = dni;
            SqlParametros = comando.Parameters.Add("@usuario", SqlDbType.VarChar, 20);
            SqlParametros.Value = usuario;
            SqlParametros = comando.Parameters.Add("@pass", SqlDbType.VarChar, 20);
            SqlParametros.Value = pass;
            SqlParametros = comando.Parameters.Add("@tipo", SqlDbType.Int);
            SqlParametros.Value = tipo;
            SqlParametros = comando.Parameters.Add("@estado", SqlDbType.Int);
            SqlParametros.Value = estado;
        }

        // proc buscar producto
        public void ArmarProcedimientoBuscarNombreProducto(ref SqlCommand comando,string textobuscar)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@textobuscar", SqlDbType.VarChar, 50);
            SqlParametros.Value = textobuscar;
            
        }
        public string NuevoUsuario(string dni,string usuario,string pass,int tipo, int estado)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoNuevoUSuario(ref comando,dni, usuario,pass,tipo,estado);
           rpta = EjecutarProcedimientoAlmacenado(comando, "InsertarUsuarios");
            return rpta;
        }


        public DataTable MostrarCategorias()
        {
            DataTable Categorias = new DataTable("categoria");
            Datos ad = new Datos();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spMostrar_Categoria";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Categorias);
            return Categorias;
        }
        public DataTable BuscarNombreCategoria(string textobuscar)
        {
            Datos ad = new Datos();
            DataTable Categorias = new DataTable("categorias");
            SqlCommand cmd = new SqlCommand();
            ArmarProcedimientoBuscarNombreProducto(ref cmd, textobuscar);
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spBuscar_Categoria";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Categorias);
            return Categorias;
        }

        public DataTable BuscarxNombre(string textobuscar,string nombresp) //   ESTE quiero hacer generico.
        {
            Datos ad = new Datos();
            DataTable elementos = new DataTable("categorias");
            SqlCommand cmd = new SqlCommand();
            ArmarProcedimientoBuscarNombreProducto(ref cmd, textobuscar);
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = nombresp;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(elementos);
            return elementos;
        }

        public string InsertarCategoria(string nombre, string descripcion)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoNuevaCategoria(ref comando, nombre, descripcion);
           rpta= EjecutarProcedimientoAlmacenado(comando, "spInsertar_Categoria");
            return rpta;
        }

        public void ArmarProcedimientoNuevaCategoria(ref SqlCommand comando,string nombre,string descripcion)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros.ParameterName = "@codcategoria";
            SqlParametros.SqlDbType = SqlDbType.Int;
            SqlParametros.Direction = ParameterDirection.Output;
            comando.Parameters.Add(SqlParametros);

            SqlParameter ParNombre = new SqlParameter();
            ParNombre.ParameterName = "@nombre";
            ParNombre.SqlDbType = SqlDbType.VarChar;
            ParNombre.Size = 30;
            ParNombre.Value = nombre;
            comando.Parameters.Add(ParNombre);

            SqlParameter ParDesc = new SqlParameter();
            ParDesc.ParameterName = "@descripcion";
            ParDesc.SqlDbType = SqlDbType.VarChar;
            ParDesc.Size = 256;
            ParDesc.Value = descripcion;
            comando.Parameters.Add(ParDesc);
        }
        public string EditarCategoria(int id,string nombre,string descripcion)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEditarCategoria(ref comando,id, nombre, descripcion);
            rpta =  EjecutarProcedimientoAlmacenado(comando, "spEditar_Categoria");
            return rpta;

        }

        public void ArmarProcedimientoEditarCategoria(ref SqlCommand comando,int id,string nombre,string descripcion)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros.ParameterName = "@codcategoria";
            SqlParametros.SqlDbType = SqlDbType.Int;
            SqlParametros.Value = id;
            comando.Parameters.Add(SqlParametros);

            SqlParameter ParNombre = new SqlParameter();
            ParNombre.ParameterName = "@nombre";
            ParNombre.SqlDbType = SqlDbType.VarChar;
            ParNombre.Size = 30;
            ParNombre.Value = nombre;
            comando.Parameters.Add(ParNombre);

            SqlParameter ParDesc = new SqlParameter();
            ParDesc.ParameterName = "@descripcion";
            ParDesc.SqlDbType = SqlDbType.VarChar;
            ParDesc.Size = 256;
            ParDesc.Value = descripcion;
            comando.Parameters.Add(ParDesc);
        }

        public string EliminarCategoria(int id)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEliminarCategoria(ref comando, id);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEliminar_Categoria");
            return rpta;

        }
        public void ArmarProcedimientoEliminarCategoria(ref SqlCommand comando,int id)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros.ParameterName = "@codcategoria";
            SqlParametros.SqlDbType = SqlDbType.Int;
            SqlParametros.Value = id;
            comando.Parameters.Add(SqlParametros);
        }
        // insertar productos
        public string InsertarProducto(string nombre, int codcategoria,string stock,string puntopedido,string cantminima,double precioU)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoNuevoProducto(ref comando, nombre, codcategoria,stock,puntopedido,cantminima, precioU);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spInsertar_Producto");
            return rpta;
        }
        // proc nuevo producto
        public void ArmarProcedimientoNuevoProducto(ref SqlCommand comando, string nombre, int codcategoria, string stock, string puntopedido, string cantminima, double precioU)
        {
           /* SqlParameter parID = new SqlParameter();
            parID.ParameterName = "@idarticulo";
            parID.SqlDbType = SqlDbType.Int;
            parID.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parID);
            */
            SqlParameter ParNombre = new SqlParameter();
            ParNombre.ParameterName = "@nombre";
            ParNombre.SqlDbType = SqlDbType.VarChar;
            ParNombre.Size = 30;
            ParNombre.Value = nombre;
            comando.Parameters.Add(ParNombre);

            SqlParameter ParCodCategoria = new SqlParameter();
            ParCodCategoria.ParameterName = "@codcategoria";
            ParCodCategoria.SqlDbType = SqlDbType.Int;
            ParCodCategoria.Value = codcategoria;
            comando.Parameters.Add(ParCodCategoria);

            SqlParameter ParStock = new SqlParameter();
            ParStock.ParameterName = "@stock";
            ParStock.SqlDbType = SqlDbType.VarChar;
            ParStock.Size = 30;
            ParStock.Value = stock;
            comando.Parameters.Add(ParStock);

            SqlParameter ParPuntoPedido = new SqlParameter();
            ParPuntoPedido.ParameterName = "@puntopedido";
            ParPuntoPedido.SqlDbType = SqlDbType.VarChar;
            ParPuntoPedido.Size = 30;
            ParPuntoPedido.Value = puntopedido;
            comando.Parameters.Add(ParPuntoPedido);

            SqlParameter ParCantMinima = new SqlParameter();
            ParCantMinima.ParameterName = "@cantminima";
            ParCantMinima.SqlDbType = SqlDbType.VarChar;
            ParCantMinima.Size = 30;
            ParCantMinima.Value = puntopedido;
            comando.Parameters.Add(ParCantMinima);

            SqlParameter ParPU = new SqlParameter();
            ParPU.ParameterName = "@precioU";
            ParPU.SqlDbType = SqlDbType.Float;
            ParPU.Value = precioU;
            comando.Parameters.Add(ParPU);
        }

        public string EditarProducto(int id,string nombre, int codcategoria, string stock, string puntopedido, string cantminima)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEditarProducto(ref comando, id, nombre, codcategoria,stock,puntopedido,cantminima);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEditar_Producto");
            return rpta;

        }

        public void ArmarProcedimientoEditarProducto(ref SqlCommand comando,int id, string nombre, int codcategoria, string stock, string puntopedido, string cantminima)
        {
            SqlParameter parID = new SqlParameter();
            parID.ParameterName = "@idarticulo";
            parID.SqlDbType = SqlDbType.Int;
            parID.Value = id;
            comando.Parameters.Add(parID);

            SqlParameter ParNombre = new SqlParameter();
            ParNombre.ParameterName = "@nombre";
            ParNombre.SqlDbType = SqlDbType.VarChar;
            ParNombre.Size = 30;
            ParNombre.Value = nombre;
            comando.Parameters.Add(ParNombre);

            SqlParameter ParCodCategoria = new SqlParameter();
            ParCodCategoria.ParameterName = "@codcategoria";
            ParCodCategoria.SqlDbType = SqlDbType.Int;
            ParCodCategoria.Value = codcategoria;
            comando.Parameters.Add(ParCodCategoria);

            SqlParameter ParStock = new SqlParameter();
            ParStock.ParameterName = "@stock";
            ParStock.SqlDbType = SqlDbType.VarChar;
            ParStock.Size = 30;
            ParStock.Value = stock;
            comando.Parameters.Add(ParStock);

            SqlParameter ParPuntoPedido = new SqlParameter();
            ParPuntoPedido.ParameterName = "@puntopedido";
            ParPuntoPedido.SqlDbType = SqlDbType.VarChar;
            ParPuntoPedido.Size = 30;
            ParPuntoPedido.Value = puntopedido;
            comando.Parameters.Add(ParPuntoPedido);

            SqlParameter ParCantMinima = new SqlParameter();
            ParCantMinima.ParameterName = "@cantminima";
            ParCantMinima.SqlDbType = SqlDbType.VarChar;
            ParCantMinima.Size = 30;
            ParCantMinima.Value = cantminima;
            comando.Parameters.Add(ParCantMinima);
        }

        public string EliminarProducto(int id)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEliminarProducto(ref comando, id);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEliminar_Producto");
            return rpta;

        }
        public void ArmarProcedimientoEliminarProducto(ref SqlCommand comando, int id)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros.ParameterName = "@idarticulo";
            SqlParametros.SqlDbType = SqlDbType.Int;
            SqlParametros.Value = id;
            comando.Parameters.Add(SqlParametros);
        }

        public DataTable MostrarProductos()
        {
            DataTable Productos = new DataTable("productos");
            Datos ad = new Datos();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spMostrar_Producto";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Productos);
            return Productos;
        }
        public DataTable BuscarNombreProducto(string textobuscar)
        {
            Datos ad = new Datos();
            DataTable Productos = new DataTable("productos");
            SqlCommand cmd = new SqlCommand();
            ArmarProcedimientoBuscarNombreProducto(ref cmd, textobuscar);
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spBuscar_Producto";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Productos);
            return Productos;
        }

        // cliente insertar
        public string InsertarCliente(string cuit, string nombre, string telefono, string direc, string localidad,string email,string obs)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoNuevoCliente(ref comando, cuit, nombre, telefono, direc, localidad,email,obs);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spInsertarCliente");
            return rpta;
        }
        // proc nuevo producto
        public void ArmarProcedimientoNuevoCliente(ref SqlCommand comando, string cuit, string nombre, string telefono, string direc, string localidad,string email, string obs)
        {
             SqlParameter parID = new SqlParameter();
             parID.ParameterName = "@cuit";
             parID.SqlDbType = SqlDbType.VarChar;
             parID.Size = 30;
            parID.Value = cuit;
             comando.Parameters.Add(parID);
             
            SqlParameter ParNombre = new SqlParameter();
            ParNombre.ParameterName = "@nombre";
            ParNombre.SqlDbType = SqlDbType.VarChar;
            ParNombre.Size = 30;
            ParNombre.Value = nombre;
            comando.Parameters.Add(ParNombre);

            SqlParameter ParTel = new SqlParameter();
            ParTel.ParameterName = "@telefono";
            ParTel.SqlDbType = SqlDbType.VarChar;
            ParTel.Size = 30;
            ParTel.Value = telefono;
            comando.Parameters.Add(ParTel);

            SqlParameter ParDirec = new SqlParameter();
            ParDirec.ParameterName = "@direccion";
            ParDirec.SqlDbType = SqlDbType.VarChar;
            ParDirec.Size = 30;
            ParDirec.Value = direc;
            comando.Parameters.Add(ParDirec);

            SqlParameter ParLocal = new SqlParameter();
            ParLocal.ParameterName = "@localidad";
            ParLocal.SqlDbType = SqlDbType.VarChar;
            ParLocal.Size = 30;
            ParLocal.Value = localidad;
            comando.Parameters.Add(ParLocal);

            SqlParameter Paremail = new SqlParameter();
            Paremail.ParameterName = "@email";
            Paremail.SqlDbType = SqlDbType.VarChar;
            Paremail.Size = 30;
            Paremail.Value = email;
            comando.Parameters.Add(Paremail);

            SqlParameter ParObs = new SqlParameter();
            ParObs.ParameterName = "@oberservacion";
            ParObs.SqlDbType = SqlDbType.VarChar;
            ParObs.Size = 250;
            ParObs.Value = obs;
            comando.Parameters.Add(ParObs);

        }

        public string EditarCliente(string cuit, string nombre, string telefono, string direc, string localidad, string email, string obs)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEditarCliente(ref comando, cuit, nombre, telefono, direc, localidad, email, obs);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEditar_Cliente");
            return rpta;

        }

        public void ArmarProcedimientoEditarCliente(ref SqlCommand comando, string cuit, string nombre, string telefono, string direc, string localidad, string email, string obs)
        {
            SqlParameter parID = new SqlParameter();
            parID.ParameterName = "@cuit";
            parID.SqlDbType = SqlDbType.VarChar;
            parID.Size = 30;
            parID.Value = cuit;
            comando.Parameters.Add(parID);

            SqlParameter ParNombre = new SqlParameter();
            ParNombre.ParameterName = "@nombre";
            ParNombre.SqlDbType = SqlDbType.VarChar;
            ParNombre.Size = 30;
            ParNombre.Value = nombre;
            comando.Parameters.Add(ParNombre);

            SqlParameter ParTel = new SqlParameter();
            ParTel.ParameterName = "@telefono";
            ParTel.SqlDbType = SqlDbType.VarChar;
            ParTel.Size = 30;
            ParTel.Value = telefono;
            comando.Parameters.Add(ParTel);

            SqlParameter ParDirec = new SqlParameter();
            ParDirec.ParameterName = "@direccion";
            ParDirec.SqlDbType = SqlDbType.VarChar;
            ParDirec.Size = 30;
            ParDirec.Value = direc;
            comando.Parameters.Add(ParDirec);

            SqlParameter ParLocal = new SqlParameter();
            ParLocal.ParameterName = "@localidad";
            ParLocal.SqlDbType = SqlDbType.VarChar;
            ParLocal.Size = 30;
            ParLocal.Value = localidad;
            comando.Parameters.Add(ParLocal);

            SqlParameter Paremail = new SqlParameter();
            Paremail.ParameterName = "@email";
            Paremail.SqlDbType = SqlDbType.VarChar;
            Paremail.Size = 30;
            Paremail.Value = email;
            comando.Parameters.Add(Paremail);

            SqlParameter ParObs = new SqlParameter();
            ParObs.ParameterName = "@oberservacion";
            ParObs.SqlDbType = SqlDbType.VarChar;
            ParObs.Size = 250;
            ParObs.Value = obs;
            comando.Parameters.Add(ParObs);
        }

        public string EliminarCliente(string cuit)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEliminarCliente(ref comando, cuit);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEliminar_Cliente");
            return rpta;

        }
        public void ArmarProcedimientoEliminarCliente(ref SqlCommand comando, string cuit)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros.ParameterName = "@cuit";
            SqlParametros.SqlDbType = SqlDbType.VarChar;
            SqlParametros.Size = 30;
            SqlParametros.Value = cuit;
            comando.Parameters.Add(SqlParametros);
        }

        public DataTable MostrarClientes()
        {
            DataTable Clientes = new DataTable("clientes");
            Datos ad = new Datos();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spMostrar_Cliente";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Clientes);
            return Clientes;
        }

        public DataTable BuscarNombreCliente(string textobuscar)
        {
            Datos ad = new Datos();
            DataTable Clientes = new DataTable("clientes");
            SqlCommand cmd = new SqlCommand();
            ArmarProcedimientoBuscarNombreProducto(ref cmd, textobuscar);
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spBuscar_Cliente";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Clientes);
            return Clientes;
        }


        public DataTable MostrarUsuarios()
        {
            DataTable Usuarios = new DataTable("usuario");
            Datos ad = new Datos();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spMostrar_Usuario";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Usuarios);
            return Usuarios;
        }

        public string EditarUsuario(string dni, string usuario, string pass, int tipo, int estado)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEditarUsuario(ref comando, dni, usuario, pass,tipo,estado);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEditar_Usuario");
            return rpta;

        }

        public void ArmarProcedimientoEditarUsuario(ref SqlCommand comando, string dni, string usuario, string pass, int tipo, int estado)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@dni", SqlDbType.VarChar, 30);
            SqlParametros.Value = dni;
            SqlParametros = comando.Parameters.Add("@usuario", SqlDbType.VarChar, 30);
            SqlParametros.Value = usuario;
            SqlParametros = comando.Parameters.Add("@pass", SqlDbType.VarChar, 30);
            SqlParametros.Value = pass;
            SqlParametros = comando.Parameters.Add("@estado", SqlDbType.Int);
            SqlParametros.Value = tipo;
            SqlParametros = comando.Parameters.Add("@tipo", SqlDbType.Int);
            SqlParametros.Value = estado;
        }
        //------------- camiones
        public DataTable MostrarCamiones()
        {
            DataTable Camiones = new DataTable("camiones");
            Datos ad = new Datos();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spMostrar_Camion";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Camiones);
            return Camiones;
        }
        public DataTable BuscarPatente(string textobuscar)
        {
            Datos ad = new Datos();
            DataTable Camiones = new DataTable("camiones");
            SqlCommand cmd = new SqlCommand();
            ArmarProcedimientoBuscarPatente(ref cmd, textobuscar);
            cmd.Connection = ad.ObtenerConexion();
            cmd.CommandText = "spBuscar_Camion";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SqlDat = new SqlDataAdapter(cmd);
            SqlDat.Fill(Camiones);
            return Camiones;
        }

        public void ArmarProcedimientoBuscarPatente(ref SqlCommand comando, string textobuscar)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@textobuscar", SqlDbType.VarChar, 50);
            SqlParametros.Value = textobuscar;

        }

        public string EditarCamion(string patente, string cargamax, int estado)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEditarCamion(ref comando, patente, cargamax, estado);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEditar_Camion");
            return rpta;

        }

        public void ArmarProcedimientoEditarCamion(ref SqlCommand comando, string patente, string cargamax, int estado)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@patente", SqlDbType.VarChar, 30);
            SqlParametros.Value = patente;
            SqlParametros = comando.Parameters.Add("@carga_max", SqlDbType.VarChar, 30);
            SqlParametros.Value = cargamax;
            SqlParametros = comando.Parameters.Add("@estado", SqlDbType.Int);
            SqlParametros.Value = estado;
        }

        public string InsertarCamion(string patente, string cargamax, int estado)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoNuevoCamion(ref comando, patente, cargamax, estado);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spInsertar_Camion");
            return rpta;
        }
        
        public void ArmarProcedimientoNuevoCamion(ref SqlCommand comando, string patente, string cargamax, int estado)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@patente", SqlDbType.VarChar, 30);
            SqlParametros.Value = patente;
            SqlParametros = comando.Parameters.Add("@carga_max", SqlDbType.VarChar, 30);
            SqlParametros.Value = cargamax;
            SqlParametros = comando.Parameters.Add("@estado", SqlDbType.Int);
            SqlParametros.Value = estado;

        }

        public string EliminarCamion(string patente)
        {
            string rpta = "";
            Gestion gestion = new Gestion();
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoEliminarCamion(ref comando, patente);
            rpta = EjecutarProcedimientoAlmacenado(comando, "spEliminar_Camion");
            return rpta;

        }
        public void ArmarProcedimientoEliminarCamion(ref SqlCommand comando, string patente)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros.ParameterName = "@patente";
            SqlParametros.SqlDbType = SqlDbType.VarChar;
            SqlParametros.Size = 30;
            SqlParametros.Value = patente;
            comando.Parameters.Add(SqlParametros);
        }
    }
}
