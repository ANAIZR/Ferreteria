using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;

namespace Capa_Datos
{
    public class D_Proveedor
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable D_listar_proveedor()
        {
            SqlCommand cmd = new SqlCommand("listar_proveedor", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_buscar_proveedor(E_Proveedor obje)
        {
            SqlCommand cmd = new SqlCommand("buscar_proveedor",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@razon_social", obje.Razon_social);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public String D_mantenimiento_proveedor(E_Proveedor obje)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("mantenimiento_proveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ruc", obje.Id_proveedor);
            cmd.Parameters.AddWithValue("@razon_social", obje.Razon_social);
            cmd.Parameters.AddWithValue("@direccion", obje.Direccion);
            cmd.Parameters.AddWithValue("@celular", obje.Celular);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.Accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }
    }
}
