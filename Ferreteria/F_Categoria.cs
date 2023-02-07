using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria
{
    public partial class F_Categoria : Form
    {
        E_Categoria e_Cat = new E_Categoria();
        N_Categoria n_Cat = new N_Categoria();
        public F_Categoria()
        {
            InitializeComponent();
        }
        void mantenimiento(String accion)
        {
            e_Cat.Id_categoria = txtID.Text;
            e_Cat.Descripcion = txt_describir.Text;
            e_Cat.Accion = accion;
            string mensaje = n_Cat.N_mantenimiento_categoria(e_Cat);
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
        void limpiar()
        {
            txtID.Text = "";
            txt_describir.Text = "";
            dataGridView1.DataSource = n_Cat.N_listar_categoria();
        }
        private void boton_agregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas registrar a " + txt_describir.Text + "?", "Mensaje",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                mantenimiento("1");
                limpiar();
            }
        }

        private void boton_modificar_Click(object sender, EventArgs e)
        {

            if (txt_describir.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txt_describir.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void boton_eliminar_Click(object sender, EventArgs e)
        {
            if (txt_describir.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txt_describir.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView1.CurrentCell.RowIndex;

            txtID.Text = dataGridView1[0, fila].Value.ToString();
            txt_describir.Text = dataGridView1[1, fila].Value.ToString();
          
        }

        private void F_Categoria_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = n_Cat.N_listar_categoria();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
