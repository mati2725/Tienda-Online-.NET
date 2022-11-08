using Entities.Usuarios;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO.UsuariosData
{
    public class UsuariosDB
    {

        private string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public int AgregarUsuario(UsuariosModel usuario)
        {
            var cmd = AccesoDatos.AccesoaDatos.GetCommandSp("AgregarUsuario");
            cmd.Parameters.AddWithValue("@USUARIO", usuario.Usuario);
            cmd.Parameters.AddWithValue("@NOMBRE", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@APELLIDO", usuario.ApellidoUsuario);
            cmd.Parameters.AddWithValue("@NACIMIENTO", usuario.FechaNacimiento);
            cmd.Parameters.AddWithValue("@TELEFONO", usuario.Telefono);
            cmd.Parameters.AddWithValue("@DIRECCION", usuario.Direccion);
            cmd.Parameters.AddWithValue("@CONTRASEAÑA", usuario.Contraseña);
            cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
            cmd.Parameters.AddWithValue("@DNI", usuario.Dni);
            var guardo = AccesoDatos.AccesoaDatos.ModifyData(cmd);
            return guardo;
        }

        public bool EliminarUsuario(string IdUsuario)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "EliminarUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", IdUsuario);


                int filasafectadas = cmd.ExecuteNonQuery();

                if (filasafectadas == 0)
                {
                    estado = false;

                }
                else
                {
                    estado = true;
                }
            }
            catch (Exception e)
            {
                estado = false;
            }
            finally
            {
                con.Close();
            }
            return estado;
        }


        public bool ExisteUsuario(string usuario)
        {
            string query = "SELECT * FROM USUARIOS WHERE Usuario_U='"+ usuario+"'AND Estado_U= 'True'";
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public bool ExisteDNI(string dni)
        {
            string query = "Select * From Usuarios Where Dni_U='" + dni + "'And Estado_U= 'True'";
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public UsuariosModel GetUsuario(string usuario)
        {
            var usmodel = new UsuariosModel();
            string query = "SELECT * FROM USUARIOS WHERE Usuario_U='" + usuario + "'AND Estado_U= 'True'";
            SqlCommand cmd = AccesoDatos.AccesoaDatos.GetCommand(query);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usmodel.Usuario = dr.GetString(0);
                    usmodel.NombreUsuario = dr.GetString(1);
                    usmodel.ApellidoUsuario = dr.GetString(2);
                    usmodel.Telefono = dr.GetInt32(4);
                    usmodel.Direccion = dr.GetString(5);
                    usmodel.Contraseña = dr.GetString(6);
                    usmodel.Email = dr.GetString(7);
                }
            }
            return usmodel;
        }

        public bool LoginUsuario(string usuario, string contraseña)
        {
            string query = "SELECT * FROM USUARIOS WHERE Usuario_U='" + usuario + "' AND Contraseña_U='" + contraseña + "' AND Estado_U= 'True'";
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public int ModificarUsuario(UsuariosModel usuario)
        {
            var cmd = AccesoDatos.AccesoaDatos.GetCommandSp("ModificarUsuario");
            cmd.Parameters.AddWithValue("@USUARIONUEVO", usuario.UsuarioNuevo);
            cmd.Parameters.AddWithValue("@USUARIO", usuario.Usuario);
            cmd.Parameters.AddWithValue("@NOMBRE", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@APELLIDO", usuario.ApellidoUsuario);
            cmd.Parameters.AddWithValue("@NACIMIENTO", usuario.FechaNacimiento);
            cmd.Parameters.AddWithValue("@TELEFONO", usuario.Telefono);
            cmd.Parameters.AddWithValue("@DIRECCION", usuario.Direccion);
            cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
            var guardo = AccesoDatos.AccesoaDatos.ModifyData(cmd);
            return guardo;
        }

        public DataTable GetUsuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT Usuario_U,Nombre_U,Apellido_U,CONVERT(varchar,FechaNacimiento_U,23) as [FechaNacimiento_U]," +
                "Telefono_U,Direccion_U,Email_U,Dni_U FROM USUARIOS WHERE Estado_U = 1 AND Usuario_U != 'admin'";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionCategoria");
            cn.Close();
            return ds.Tables["GestionCategoria"];
        }

        public DataTable BuscarUsuarios(string Usuario)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT Usuario_U,Nombre_U,Apellido_U,CONVERT(varchar,FechaNacimiento_U,23) as [FechaNacimiento_U]," +
                "Telefono_U,Direccion_U,Email_U,Dni_U FROM USUARIOS WHERE Estado_U = 1 AND Usuario_U != 'admin' AND Usuario_U LIKE '" + Usuario + "%'";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionCategoria");
            cn.Close();
            return ds.Tables["GestionCategoria"];
        }
    }
}
