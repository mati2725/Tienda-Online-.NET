using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Usuarios
{
    public class UsuariosModel
    {
        public object usuario;

        public string UsuarioNuevo { get; set; }

        public string RepContraseña { get; set; }

        public string Usuario { get; set; }

        public string NombreUsuario { get; set; }

        public string ApellidoUsuario { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Telefono { get; set; }

        public string Direccion { get; set; }

        public string Contraseña { get; set; }

        public string Email { get; set; }

        public string Dni { get; set; }

        public bool EstadoUsuario { get; set; }
    }
}
