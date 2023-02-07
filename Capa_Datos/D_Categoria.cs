using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public  class D_Categoria
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable D_listar_categoria()
        {
            SqlCommand cmd = new SqlCommand("listar_categoria",cn);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dataTable= new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        public String D_mantenimiento_Categorias(E_Categoria cat) {
            String accion = "";
            SqlCommand cmd = new SqlCommand("mantenimiento_categoria", cn);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_categoria", cat.Id_categoria);
            cmd.Parameters.AddWithValue("@descripcion", cat.Descripcion);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar,50).Value = cat.Accion;
            cmd.Parameters["@accion"].Direction= ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;

        }

    }
}
