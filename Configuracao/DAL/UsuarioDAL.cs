using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario, string _confirmarSenha)
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
                throw new Exception("ocorreu um erro ao tentar inserir um usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Usuario> BuscarTodos()
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while(rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);
                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuarios no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Usuario> BuscarPorNomeUsuario(string _nomeUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario WHERE NomeUsuario = @NomeUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o nome de usuario no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorId(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if(rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o usuario pelo Id no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

    public void Alterar(Usuario _usuario, string _confirmarSenha)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "UPDATE Usuario SET Nome = @Nome, NomeUsuario = @NomeUsuario, Email = @Email, CPF = @CPF, Ativo = @Ativo, Senha = @Senha WHERE Id = @Id";
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
                throw new Exception("ocorreu um erro ao tentar alterar o usuario no banco de dados: ", ex);
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
                throw new Exception("ocorreu um erro ao tentar excluir o usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public Usuario BuscarPorCPF(string _cpf)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario WHERE CPF = @CPF";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CPF", _cpf);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o CPF do usuario no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorNome(string _nome)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario WHERE Nome = @Nome";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _nome);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o Nome do usuario no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public bool UsuarioPertenceAoGrupo(int _idUsuario, int _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT 1 FROM UsuarioGrupoUsuario WHERE CodUsuario AND CodGrupoUsuario = @CodGrupoUsuario";
                                  
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CodUsuario", _idUsuario);
                cmd.Parameters.AddWithValue("@CodGrupoUsuario", _idGrupoUsuario);
                cn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao verificar a existencia de um grupo de um usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void AdicionarGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO UsuarioGrupoUsuario(CodUsuario,CodGrupoUsuario)
                                    VALUES(@CodUsuario,@CodGrupoUsuario)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CodUsuario", _idUsuario);
                cmd.Parameters.AddWithValue("@CodGrupoUsuario", _idGrupoUsuario);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao tentar vincular um grupo a um usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void RemoverGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM UsuarioGrupoUsuario WHERE CodUsuario = @CodUsuario AND CodGrupoUsuario = @CodGrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CodUsuario", _idUsuario);
                cmd.Parameters.AddWithValue("@CodGrupoUsuario", _idGrupoUsuario);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao tentar excluir o usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
