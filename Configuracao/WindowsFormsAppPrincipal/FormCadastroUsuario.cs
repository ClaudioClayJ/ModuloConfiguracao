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
    public partial class FormCadastroUsuario : Form
    {
        public int Id;
        public FormCadastroUsuario(int _id=0)
        {
            InitializeComponent();
            Id = _id;
        }

        private void buttonSalvarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBindingSource.EndEdit();
            if (Id == 0)
                usuarioBLL.Inserir((Usuario)usuarioBindingSource.Current);
            else
                usuarioBLL.Alterar((Usuario)usuarioBindingSource.Current);
            MessageBox.Show("Registro Salvo com Sucesso");
            Close();

        }

        private void FormCadastroUsuario_Load(object sender, EventArgs e)
        {
            if (Id == 0)
                usuarioBindingSource.AddNew();
        }

    }
}
