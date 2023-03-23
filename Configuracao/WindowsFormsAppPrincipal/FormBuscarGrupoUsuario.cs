using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarGrupoUsuario : Form
    {
        public FormBuscarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscarPorGrupoUsuario_Click(object sender, EventArgs e)
        {
            grupoUsuariosBindingSource.DataSource = new GrupoUsuarioBLL().BuscarTodos();
        }

        private void buttonAlterarGrupoUsuario_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdicionarGrupoUsuario_Click(object sender, EventArgs e)
        {
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario())
              frm.ShowDialog();
        }

        private void buttonExcluirGrupoUsuario_Click(object sender, EventArgs e)
        {
            if(grupoUsuariosBindingSource.Count <= 0)
            {
                MessageBox.Show("Não existe registro para ser excluido");
                return;
            }
            if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int id = ((GrupoUsuario)grupoUsuariosBindingSource.Current).Id;
            new GrupoUsuarioBLL().Excluir(id);
            grupoUsuariosBindingSource.RemoveCurrent();
            MessageBox.Show("Registro excluido com sucesso!");
        }
    }
}
