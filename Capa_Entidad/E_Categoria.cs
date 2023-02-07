using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Categoria
    {
        private string id_categoria;
        private string descripcion;
        private string accion;

        public string Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Accion { get => accion; set => accion = value; }
    }
}
