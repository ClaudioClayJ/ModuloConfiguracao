﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario(Nome,NomeUsuario,Email,CPF,Ativo,Senha)
                                    VALUES(@Nome,@NomeUsuario,@Email,@CPF,@Ativo,@Senha)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw; new Exception("ocorreu erro ao tentar inserir um usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Usuario> BuscarTodos()
        {
            throw new NotImplementedException();
        }
        public List<Usuario> BuscarPorNomeUsuario(string _nomeUsuario)
        {
            throw new NotImplementedException();
        }
        public List<Usuario> BuscarPorId(int _id)
        {
            throw new NotImplementedException();
        }

    public void Alterar(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "UPDATE Usuario SET Nome = @Nome, NomeUsuario = @NomeUsuario, Email = @Email, CPF = @CPF, Ativo = @Ativo, Senha =@Senha WHERE Id= @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@Id", _usuario.Id);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw; new Exception("ocorreu um erro ao tentar alterar o usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Excluir(int _id)
        {

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Usuario WHERE Id=@Id";
                cmd.CommandType = System.Data.CommandType.Text;
              
                cmd.Parameters.AddWithValue("@Id", _id);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw; new Exception("ocorreu erro ao tentar excluir o usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
