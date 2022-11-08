using DAO.CategoriasData;
using Entities.Categorias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Business.CategoriasModule
{
    public class CategoriasModule
    {

        public int Actualizar(CategoriasModel categoria)
        {

            bool Estado = new CategoriasDB().ExisteCategoria(categoria.NombreCategoria,Convert.ToString(categoria.IdCategoria));

            if (Estado) return -2;

            if (new CategoriasDB().ActualizarCategoria(categoria)) return 1;

            return -1;

        }

        public int Agregar(CategoriasModel categoria)
        {
            bool Estado = new CategoriasDB().ExisteCategoria(categoria.NombreCategoria);

            if (Estado) return -2;

            if(new CategoriasDB().AgregarCategoria(categoria)) return 1;

            return -1;
        }

        public bool Eliminar(int idCategoria)
        {
            return new CategoriasDB().EliminarCategoria(idCategoria);
        }

        public DataTable GetCategorias()
        {
            return new CategoriasDB().GetCategorias();
        }

        public void LlenarDDL(ref DropDownList ddl)
        {
            DataTable dt = new CategoriasDB().GetCategorias();
            foreach (DataRow Dato in dt.Rows)
            {
                ListItem li = new ListItem(Dato.Field<string>("Nombre_Cat"), Convert.ToString(Dato.Field<int>("IdCategoria_Cat")));
                ddl.Items.Add(li);

            }
        }

        public DataTable BuscarCategorias(string categoria)
        {
            return new CategoriasDB().BuscarCategorias(categoria);
        }
    }
}
