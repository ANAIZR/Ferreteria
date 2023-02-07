using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_Categoria
    {
        D_Categoria d_cat = new D_Categoria();
        public DataTable N_listar_categoria()
        {
            return d_cat.D_listar_categoria();
        }
       
        public string N_mantenimiento_categoria(E_Categoria obje)
        {
            return d_cat.D_mantenimiento_Categorias(obje);
        }
    }
}
