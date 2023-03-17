using BLL;
using Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.DataSource = new UsuarioBLL().BuscarTodos();
        }

        private void buttonExcluirUsuario_Click(object sender, EventArgs e)
        {
            if(usuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Não existe registro para ser excluido");
                return;
            }
            if (MessageBox.Show("Deseja realmente excluir este registro?",
                "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int id =((Usuario)usuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(id);
            usuarioBindingSource.RemoveCurrent();

            MessageBox.Show("Registro excluido com sucesso");
        }
    }
}
