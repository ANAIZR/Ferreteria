using Capa_Entidad;
using Capa_Negocio;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ferreteria
{
    public partial class F_Proveedor : Form
    {
        E_Proveedor e_proveedor = new E_Proveedor();
        N_Proveedor n_proveedor = new N_Proveedor();
        public F_Proveedor()
        {
            InitializeComponent();
        }

        private void F_Proveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = n_proveedor.N_listar_proveedor();
        }
        void mantenimiento(String accion)
        {
            e_proveedor.Id_proveedor = txtRuc.Text;
            e_proveedor.Razon_social = txtRazonS.Text;
            e_proveedor.Direccion = txtDireccion.Text;
            e_proveedor.Celular = txtCelular.Text;
            e_proveedor.Accion = accion;
            string mensaje = n_proveedor.N_mantenimiento_proveedor(e_proveedor);
            MessageBox.Show(mensaje,"Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void limpiar()
        {
            txtRuc.Text="";
            txtRazonS.Text = "";
            txtDireccion.Text = "";
            txtCelular.Text = "";
            busq_proveedor.Text = "";
            dataGridView1.DataSource = n_proveedor.N_listar_proveedor();
        }

        private void boton_agregar_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text != "")
            {
                if (txtRuc.TextLength < 11)
                {
                    MessageBox.Show("RUC debe tener 11 digitos","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                if (txtCelular.TextLength < 9)
                {
                    MessageBox.Show("Número de celular debe tener 9 digitos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txtRazonS.TextLength < 3)
                {
                    MessageBox.Show("Razón social debe tener al menos 3 digitos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (txtDireccion.TextLength < 3)
                {
                    MessageBox.Show("Dirección debe tener al menos 3 digitos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (!txtCelular.Text.StartsWith("9"))
                {
                    MessageBox.Show("Ingrese un numero de celular valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("¿Deseas registrar a " + txtRazonS.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        mantenimiento("1");
                        limpiar();
                    }
                }
               
            }
        }

        private void boton_eliminar_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtRazonS.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void boton_modificar_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtRazonS.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void busq_proveedor_TextChanged(object sender, EventArgs e)
        {
            if (busq_proveedor.Text != "")
            {
                e_proveedor.Razon_social = busq_proveedor.Text;
                DataTable dt = new DataTable();
                dt = n_proveedor.N_buscar_proveedor(e_proveedor);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = n_proveedor.N_listar_proveedor();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtRuc.Text = dataGridView1[0, fila].Value.ToString();
            txtRazonS.Text = dataGridView1[1, fila].Value.ToString();
            txtDireccion.Text = dataGridView1[2, fila].Value.ToString();
            txtCelular.Text = dataGridView1[3, fila].Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar>=32 && e.KeyChar<=47) || (e.KeyChar>=58 && e.KeyChar<=255 ))
            {
                MessageBox.Show("Solo números","Alerta",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled= true;
                return;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 34) || (e.KeyChar >= 36 && e.KeyChar <= 45) || (e.KeyChar ==47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo caracteres validos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtRazonS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 34) || (e.KeyChar >= 36 && e.KeyChar <= 45) || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo caracteres validos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

       
    }
}
