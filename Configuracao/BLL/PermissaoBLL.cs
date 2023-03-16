using DAL;
using Models;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class PermissaoBLL
    {

        public void Inserir(Permissao _permissao)
        {
            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Inserir(_permissao);
        }
        public void Alterar(Permissao _permissao)
        {

            ValidarDados(_permissao);
            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Alterar(_permissao);
        }
        private void ValidarDados(Permissao _permissao)
        {
            if (_permissao.Descrissao.Length <= 3)
                throw new Exception("A descriçao deve ter mais de 3 caracteres.");

        }

        public List<Permissao> BuscarTodos()
        {
            return new PermissaoDAL().BuscarTodos();
        }
        public List<Permissao> BuscarPorId(int _id)
        {
            return new PermissaoDAL().BuscarPorId(_id);
        }
        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            return new PermissaoDAL().BuscarPorDescricao(_descricao);
        }
    }
}
