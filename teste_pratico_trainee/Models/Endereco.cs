using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace teste_pratico_trainee.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Id_tipo { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public static Endereco Selecionar_Id(int id)
        {
            Endereco Endereco = new Endereco();

            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);

            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_endereco_lista_id", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("$id", id);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    MySqlDataReader dr = sql.ExecuteReader();

                    while (dr.Read())
                    {
                        Endereco = new Endereco();

                        if (dr["id"] != DBNull.Value)
                            Endereco.Id = Convert.ToInt32(dr["id"]);

                        if (dr["tipo_id"] != DBNull.Value)
                            Endereco.Id_tipo = Convert.ToInt32(dr["tipo_id"]);

                        if (dr["logradouro"] != DBNull.Value)
                            Endereco.Logradouro = Convert.ToString(dr["logradouro"]);

                        if (dr["numero"] != DBNull.Value)
                            Endereco.Numero = Convert.ToInt32(dr["numero"]);

                        if (dr["bairro"] != DBNull.Value)
                            Endereco.Bairro = Convert.ToString(dr["bairro"]);

                        if (dr["complemento"] != DBNull.Value)
                            Endereco.Complemento = Convert.ToString(dr["complemento"]);

                        if (dr["cidade"] != DBNull.Value)
                            Endereco.Cidade = Convert.ToString(dr["cidade"]);

                        if (dr["uf"] != DBNull.Value)
                            Endereco.UF = Convert.ToString(dr["uf"]);

                        if (dr["cep"] != DBNull.Value)
                            Endereco.CEP = Convert.ToString(dr["cep"]);

                    }
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                //throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }

            return Endereco;
        }
        public static List<Endereco> Selecionar_ClienteId(int Cliente_id)
        {
            List<Endereco> ListaEndereco = new List<Endereco>();
            Endereco Endereco;
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);

            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_endereco_selecionar_cliente_id", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("$cliente_id", Cliente_id);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    MySqlDataReader dr = sql.ExecuteReader();

                    while (dr.Read())
                    {
                        Endereco = new Endereco();
                       
                        if (dr["id"] != DBNull.Value)
                            Endereco.Id = Convert.ToInt32(dr["id"]);

                        if (dr["tipo_id"] != DBNull.Value)
                            Endereco.Id_tipo = Convert.ToInt32(dr["tipo_id"]);

                        if (dr["logradouro"] != DBNull.Value)
                            Endereco.Logradouro = Convert.ToString(dr["logradouro"]);

                        if (dr["numero"] != DBNull.Value)
                            Endereco.Numero = Convert.ToInt32(dr["numero"]);

                        if (dr["bairro"] != DBNull.Value)
                            Endereco.Bairro = Convert.ToString(dr["bairro"]);

                        if (dr["complemento"] != DBNull.Value)
                            Endereco.Complemento = Convert.ToString(dr["complemento"]);

                        if (dr["cidade"] != DBNull.Value)
                            Endereco.Cidade = Convert.ToString(dr["cidade"]);

                        if (dr["uf"] != DBNull.Value)
                            Endereco.UF = Convert.ToString(dr["uf"]);

                        if (dr["cep"] != DBNull.Value)
                            Endereco.CEP = Convert.ToString(dr["cep"]);

                        ListaEndereco.Add(Endereco);
                    }
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                //throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }

            return ListaEndereco;
        }
        public static int Inserir(Endereco Endereco, Cliente Cliente)
        {
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            int IdEndereco = default;
            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_endereco_insert", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    sql.Parameters.AddWithValue("$tipo_id", Endereco.Id_tipo);
                    sql.Parameters.AddWithValue("$cliente_id", Cliente.Id);
                    sql.Parameters.AddWithValue("$logradouro", Endereco.Logradouro);
                    sql.Parameters.AddWithValue("$numero", Endereco.Numero);
                    sql.Parameters.AddWithValue("$bairro", Endereco.Bairro);
                    sql.Parameters.AddWithValue("$complemento", Endereco.Complemento);
                    sql.Parameters.AddWithValue("$cidade", Endereco.Cidade);
                    sql.Parameters.AddWithValue("$uf", Endereco.UF);
                    sql.Parameters.AddWithValue("$cep", Endereco.CEP);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();
                    IdEndereco = Convert.ToInt32(sql.ExecuteScalar());
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
            return IdEndereco;
        }

        public void Editar(Endereco Endereco, Cliente Cliente)
        {

            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_endereco_editar_id", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    sql.Parameters.AddWithValue("$id", Endereco.Id);
                    sql.Parameters.AddWithValue("$tipo_id", Endereco.Id_tipo);
                    sql.Parameters.AddWithValue("$cliente_id", Cliente.Id);
                    sql.Parameters.AddWithValue("$logradouro", Endereco.Logradouro);
                    sql.Parameters.AddWithValue("$numero", Endereco.Numero);
                    sql.Parameters.AddWithValue("$bairro", Endereco.Bairro);
                    sql.Parameters.AddWithValue("$complemento", Endereco.Complemento);
                    sql.Parameters.AddWithValue("$cidade", Endereco.Cidade);
                    sql.Parameters.AddWithValue("$uf", Endereco.UF);
                    sql.Parameters.AddWithValue("$cep", Endereco.CEP);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();
                    sql.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                //throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
        }
        public void Delete(Endereco Endereco)
        {
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_endereco_delete", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    sql.Parameters.AddWithValue("$id", Endereco.Id);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    sql.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
        }
    }
}