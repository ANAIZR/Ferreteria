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
    public class N_Proveedor
    {
        D_Proveedor obj = new D_Proveedor();
        public DataTable N_listar_proveedor()
        {
            return obj.D_listar_proveedor();
        }
        public DataTable N_buscar_proveedor(E_Proveedor obje)
        {
            return obj.D_buscar_proveedor(obje);
        }
        public string N_mantenimiento_proveedor(E_Proveedor obje)
        {
            return obj.D_mantenimiento_proveedor(obje);
        }
    }
}
