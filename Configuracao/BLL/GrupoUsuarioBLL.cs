using DAL;
using Models;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class GrupoUsuarioBLL
    {

        public void Inserir(GrupoUsuario _grupousuario)
        {
            GrupoUsuarioDAL grupousuarioDAL = new GrupoUsuarioDAL();
            grupousuarioDAL.Inserir(_grupousuario);
        }
        public void Alterar(GrupoUsuario _grupousuario)
        {

            ValidarDados( _grupousuario);
            GrupoUsuarioDAL grupousuarioDAL = new GrupoUsuarioDAL();
            grupousuarioDAL.Alterar( _grupousuario);
        }
        private void ValidarDados(GrupoUsuario _grupousuario)
        {
            if (_grupousuario.NomeGrupo.Length <= 3)
                throw new Exception("A senha deve ter mais de 3 caracteres.");

        }

        public List<GrupoUsuario> BuscarTodos()
        {
            return new GrupoUsuarioDAL().BuscarTodos();
        }
        public GrupoUsuario BuscarPorId(int _id)
        {
            return new GrupoUsuarioDAL().BuscarPorId(_id);
        }
       public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomegrupo)
        {
            return new GrupoUsuarioDAL().BuscarPorNomeGrupo(_nomegrupo);
        }
    }
}
