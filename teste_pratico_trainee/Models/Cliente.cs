using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace teste_pratico_trainee.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Endereco Endereco { get; set; } = new Endereco();

        public static List<Cliente> Selecionar()
        {
            List<Cliente> ListaCliente = new List<Cliente>();
            Cliente Cliente;
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);


            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_cliente_selecionar", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    MySqlDataReader dr = sql.ExecuteReader();

                    while (dr.Read())
                    {
                        Cliente = new Cliente();

                        if (dr["id"] != DBNull.Value)
                            Cliente.Id = Convert.ToInt32(dr["id"]);

                        if (dr["nome"] != DBNull.Value)
                            Cliente.Nome = Convert.ToString(dr["nome"]);

                        if (dr["sexo"] != DBNull.Value)
                            Cliente.Sexo = Convert.ToString(dr["sexo"]);

                        if (dr["datanascimento"] != DBNull.Value)
                            Cliente.DataNascimento = Convert.ToDateTime(dr["datanascimento"]);

                        if (dr["estadocivil"] != DBNull.Value)
                            Cliente.EstadoCivil = Convert.ToString(dr["estadocivil"]);

                        if (dr["cpf"] != DBNull.Value)
                            Cliente.CPF = Convert.ToString(dr["cpf"]);

                        if (dr["rg"] != DBNull.Value)
                            Cliente.RG = Convert.ToString(dr["rg"]);

                        ListaCliente.Add(Cliente);
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

            return ListaCliente;
        }

        public static Cliente Selecionar(int Cliente_id)
        {
            Cliente Cliente = new Cliente();
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);


            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_cliente_selecionar_id", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("$cliente_id", Cliente_id);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    MySqlDataReader dr = sql.ExecuteReader();

                    while (dr.Read())
                    {                      

                        if (dr["id"] != DBNull.Value)
                            Cliente.Id = Convert.ToInt32(dr["id"]);

                        if (dr["nome"] != DBNull.Value)
                            Cliente.Nome = Convert.ToString(dr["nome"]);

                        if (dr["sexo"] != DBNull.Value)
                            Cliente.Sexo = Convert.ToString(dr["sexo"]);

                        if (dr["datanascimento"] != DBNull.Value)
                            Cliente.DataNascimento = Convert.ToDateTime(dr["datanascimento"]);

                        if (dr["estadocivil"] != DBNull.Value)
                            Cliente.EstadoCivil = Convert.ToString(dr["estadocivil"]);

                        if (dr["cpf"] != DBNull.Value)
                            Cliente.CPF = Convert.ToString(dr["cpf"]);

                        if (dr["rg"] != DBNull.Value)
                            Cliente.RG = Convert.ToString(dr["rg"]);
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

            return Cliente;
        }
        public static List<Cliente> Filtro(Cliente Cliente)
        {
            List<Cliente> ListaCliente = new List<Cliente>();           
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);

            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_cliente_filtro", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    sql.Parameters.AddWithValue("$nome", Cliente.Nome);
                    sql.Parameters.AddWithValue("$sexo", Cliente.Sexo);
                    sql.Parameters.AddWithValue("$estadocivil", Cliente.EstadoCivil);
                    sql.Parameters.AddWithValue("$cpf", Cliente.CPF);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    MySqlDataReader dr = sql.ExecuteReader();

                    while (dr.Read())
                    {
                        Cliente = new Cliente();

                        if (dr["id"] != DBNull.Value)
                            Cliente.Id = Convert.ToInt32(dr["id"]);

                        if (dr["nome"] != DBNull.Value)
                            Cliente.Nome = Convert.ToString(dr["nome"]);

                        if (dr["sexo"] != DBNull.Value)
                            Cliente.Sexo = Convert.ToString(dr["sexo"]);

                        if (dr["datanascimento"] != DBNull.Value)
                            Cliente.DataNascimento = Convert.ToDateTime(dr["datanascimento"]);

                        if (dr["estadocivil"] != DBNull.Value)
                            Cliente.EstadoCivil = Convert.ToString(dr["estadocivil"]);

                        if (dr["cpf"] != DBNull.Value)
                            Cliente.CPF = Convert.ToString(dr["cpf"]);

                        if (dr["rg"] != DBNull.Value)
                            Cliente.RG = Convert.ToString(dr["rg"]);

                        ListaCliente.Add(Cliente);
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

            return ListaCliente;
        }
        public static int Inserir(Cliente Cliente)
        {
            int IdCliente = default;
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_cliente_insert", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    sql.Parameters.AddWithValue("$nome", Cliente.Nome);
                    sql.Parameters.AddWithValue("$sexo", Cliente.Sexo);
                    sql.Parameters.AddWithValue("$datanascimento", Cliente.DataNascimento);
                    sql.Parameters.AddWithValue("$estadocivil", Cliente.EstadoCivil);
                    sql.Parameters.AddWithValue("$cpf", Cliente.CPF);
                    sql.Parameters.AddWithValue("$rg", Cliente.RG);


                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    IdCliente = Convert.ToInt32(sql.ExecuteScalar());
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
            return IdCliente;
        }
        public void Editar(Cliente Cliente)
        {            
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_cliente_editar_id", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    sql.Parameters.AddWithValue("$cliente_id", Cliente.Id);
                    sql.Parameters.AddWithValue("$nome", Cliente.Nome);
                    sql.Parameters.AddWithValue("$sexo", Cliente.Sexo);
                    sql.Parameters.AddWithValue("$datanascimento", Cliente.DataNascimento);
                    sql.Parameters.AddWithValue("$estadocivil", Cliente.EstadoCivil);
                    sql.Parameters.AddWithValue("$cpf", Cliente.CPF);
                    sql.Parameters.AddWithValue("$rg", Cliente.RG);


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

        public void Delete(Cliente Cliente)
        {
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            try
            {
                using (MySqlCommand sql = new MySqlCommand("prc_cliente_delete", conexao))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;

                    sql.Parameters.AddWithValue("$id", Cliente.Id);

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