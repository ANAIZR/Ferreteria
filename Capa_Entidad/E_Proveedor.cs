using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Proveedor
    {
        private string id_proveedor;
        private string razon_social;
        private string direccion;
        private string celular;
        private string accion;

        public string Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public string Razon_social { get => razon_social; set => razon_social = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Accion { get => accion; set => accion = value; }
    }
}
