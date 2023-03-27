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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
           /* Usuario usuario = new Usuario();
            usuario.Nome = "Claudio";
            usuario.NomeUsuario = "Claudio_Junior";
            usuario.Ativo = true;
            usuario.CPF = "12345678909";
            usuario.Senha = "Cj123";
            usuario.Email = "ClaudioFagundes@Gmail.com";*/

           // new UsuarioBLL().Inserir(usuario);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                using (FormLogin frm = new FormLogin())
                {
                    frm.ShowDialog();
                    if(!frm.Logou)
                        Application.Exit();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarUsuario frm = new FormBuscarUsuario())
            {
                frm.ShowDialog();
            }
        }

        private void grupoDeSuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarGrupoUsuario frm = new FormBuscarGrupoUsuario())
            {
                frm.ShowDialog();
            }
        }
    }
}
