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
    public partial class FormCadastroGrupoUsuario : Form
    {
        public int Id;
        public FormCadastroGrupoUsuario(int _id=0)
        {
            InitializeComponent();
            Id = _id;
        }

        private void FormCadastroGrupoUsuario_Load(object sender, EventArgs e)
        {
            if (Id == 0)
                grupoUsuarioBindingSource.AddNew();
        }

        private void buttonSalvarCadastroGrupoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
            GrupoUsuarioBLL grupoUsuarioBLL = new GrupoUsuarioBLL();
            grupoUsuarioBindingSource.EndEdit();
            if (Id == 0)
                grupoUsuarioBLL.Inserir((GrupoUsuario)grupoUsuarioBindingSource.Current);
            else
                grupoUsuarioBLL.Alterar((GrupoUsuario)grupoUsuarioBindingSource.Current);
            MessageBox.Show("Registro salvo com sucesso");
            Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelarCadastroGrupoUsuario_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
