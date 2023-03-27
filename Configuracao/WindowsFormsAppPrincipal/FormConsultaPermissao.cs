using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormConsultaPermissao : Form
    {
        public int Id;
        public FormConsultaPermissao()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                permissaoBindingSource.DataSource = new PermissaoBLL().BuscarPorDescricao(textBoxBuscarDescrissao.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        
        private void buttonSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (permissaoBindingSource.Count > 0)
                {
                    Id = ((Permissao)permissaoBindingSource.Current).Id;
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormConsultaPermissao_Load(object sender, EventArgs e)
        {

        }
    }
}
