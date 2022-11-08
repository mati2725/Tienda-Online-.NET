using DAO.UsuariosData;
using Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UsuariosModule
{
    
    public class UsuariosModule
    {
        private readonly UsuariosDB _usuariosDB;

        public UsuariosModule()
        {
            _usuariosDB = new UsuariosDB();
        }

        public UsuariosModel GetUsuarioLogin(string usuario)
        {
            var uslogin = _usuariosDB.GetUsuario(usuario);
            return uslogin;
        }

        public int GuardarUsuario(UsuariosModel usuario)
        {
            string nombre = usuario.Usuario;
            var ExisteUsuario = _usuariosDB.ExisteUsuario(nombre);
            var ExisteDni = _usuariosDB.ExisteDNI(usuario.Dni);

            if(ExisteUsuario) return -2;
          
            else
            
            {
                if (ExisteDni) return -3;

                else
                {
                    var guardar = _usuariosDB.AgregarUsuario(usuario);
                    return guardar;
                }
            }
        }

        public bool LoginUsuarioExist(string usuario, string contraseña)
        {
            var existe = _usuariosDB.LoginUsuario(usuario, contraseña);
            return existe;
        }

        public bool EliminarUsuario(string usuario)
        {
            return _usuariosDB.EliminarUsuario(usuario);
  
        }

        public int ModificarUs(UsuariosModel usuario)
        {
            string nombre = usuario.Usuario;
            var modificado = _usuariosDB.ExisteUsuario(nombre);
            if (modificado)
            {

                return -2;
            }
            else
            {
                var modify = _usuariosDB.ModificarUsuario(usuario);
                return modify;
            }
        }

        public UsuariosModel GetUsuario(string IdUsuario)
        {
            return _usuariosDB.GetUsuario(IdUsuario);
        }

        public DataTable GetUsuarios()
        {
            return _usuariosDB.GetUsuarios();
        }

        public DataTable BuscarUsuarios(string IdUsuario)
        {
            return _usuariosDB.BuscarUsuarios(IdUsuario);
        }

    }
}
