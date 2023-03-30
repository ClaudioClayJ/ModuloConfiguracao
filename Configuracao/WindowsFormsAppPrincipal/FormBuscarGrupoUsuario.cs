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
            int id = ((GrupoUsuario)grupoUsuariosBindingSource.Current).Id;
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario(id))
            {
                frm.ShowDialog();
            }
            buttonBuscarPorGrupoUsuario_Click(null, null);
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

        private void buttonAdicionarPermissao_Click(object sender, EventArgs e)
        {
            try
            {
                using(FormConsultaPermissao frm = new FormConsultaPermissao())
                {
                    frm.ShowDialog();
                    if (frm.Id != 0)
                    {
                        int idGrupoUsuario = ((GrupoUsuario)grupoUsuariosBindingSource.Current).Id;
                        new GrupoUsuarioBLL().AdicionarPermissao(idGrupoUsuario, frm.Id);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExcluirPermissao_Click(object sender, EventArgs e)
        {
            try
            {

                int idGrupoUsuario = ((GrupoUsuario)grupoUsuariosBindingSource.Current).Id;
                int idPermissao = ((Permissao)permissaoBindingSource.Current).Id;
                new GrupoUsuarioBLL().RemoverPermissao(idPermissao, idGrupoUsuario);
                permissaoBindingSource.RemoveCurrent();
                MessageBox.Show("Registro excluido com sucesso!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormBuscarGrupoUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
