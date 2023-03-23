using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario, string _confirmarSenha)
        {
        UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario, _confirmarSenha);
        }
        public void Alterar(Usuario _usuario, string _confirmarSenha)
        {
            ValidarDados(_usuario, _confirmarSenha);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario, _confirmarSenha);
        }

        public void Excluir(int _id)
        {
            new UsuarioDAL().Excluir(_id);
        }
        private void ValidarDados(Usuario _usuario, string _confirmarSenha)
        {
            if (_usuario.Senha != _confirmarSenha)
                throw new Exception("A senha e a configuração da senha devem ser iguais.");

            if (_usuario.Senha.Length <= 3)
                throw new Exception("A senha deve ter mais de 3 caracteres.");

            if (_usuario.Nome.Length <= 2)
                throw new Exception("O nome deve ter mais de 2 letras.");
        }

        public List<Usuario> BuscarTodos()
        {
            return new UsuarioDAL().BuscarTodos();
        }
        public Usuario BuscarPorId(int _id)
        {
            return new UsuarioDAL().BuscarPorId(_id);
        }
        public Usuario BuscarPorCPF(string _cPF)
        {
            return new UsuarioDAL().BuscarPorCPF(_cPF);
        }
        public Usuario BuscarPorNome(string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }

        public void AdicionarGrupoUsuario(int _idUsuario, int _id)
        {
            if (!new UsuarioDAL().UsuarioPertenceAoGrupo(_idUsuario, _id))
                new UsuarioDAL().AdicionarGrupoUsuario(_idUsuario, _id);
        }

        public void RemoverGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            new UsuarioDAL().RemoverGrupoUsuario(_idUsuario, _idGrupoUsuario);
        }
    }
}
