using DAO.MarcasData;
using Entities.Marcas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Business.MarcasModule
{
    public class MarcasModule
    {

        MarcasDB Datos = new MarcasDB();

        public bool EliminarMarca(int IdMarca)
        {
            return Datos.EliminarMarca(IdMarca);
        }

        public int ActualizarMarca(MarcasModel Model)
        {
            bool Estado = new MarcasDB().ExisteMarca(Model.NombreMarca, Convert.ToString(Model.IdMarca));
            if (Estado) return -2;

            if (new MarcasDB().ActualizarMarca(Model)) return 1;

            return -1;
        }

        public int AgregarMarca(MarcasModel Model)
        {
            bool Estado = new MarcasDB().ExisteMarca(Model.NombreMarca);

            if (Estado) return -2;

            if (new MarcasDB().AgregarMarca(Model)) return 1;

            return -1;
        }

        public DataTable GetMarcas()
        {
            return Datos.GetMarcas();
        }

        public void LlenarDropDownList(ref DropDownList ddl)
        {
            DataTable dt = Datos.GetMarcas();
            foreach (DataRow Dato in dt.Rows)
            {
                ListItem li = new ListItem(Dato.Field<string>("Nombre_M"), Convert.ToString(Dato.Field<int>("IdMarca_M")));
                ddl.Items.Add(li);

            }
        }

        public DataTable BuscarMarcas(string Marcas)
        {
            return Datos.BuscarMarcas(Marcas);
        }
    }
}
