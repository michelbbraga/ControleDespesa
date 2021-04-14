using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControleDespesa4
{
    public class IniciaDB
    {
        //variaveis de conexão onde armazenamos o endereço do banco e acesso
        public string sconexao;            // string com o endereço do banco
        public SqlConnection fazconexao;  //varivael da biblioteca para conexao

        //metodo construtor da classe
        public IniciaDB()
        {
            try
            {
                sconexao = ""; // inserir caminho da conexão com o banco; // inserir caminho da conexão com o banco;
                fazconexao = new SqlConnection(sconexao);
                fazconexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // metodo que fara os envios de comando sql e retornara o resultado da consulta
        public DataTable ConsultaSQL(string Sql)
        {
            // cria variavel com estrutura de tabela (coluna x linhas)
            DataTable dt = new DataTable();
            try
            {
                var comandoquery = new SqlCommand(Sql, fazconexao);
                comandoquery.CommandTimeout = 0;
                // variavel que guarda o resultado da consulta
                var leitor = comandoquery.ExecuteReader();
                dt.Load(leitor);  //o conteudo do comando  sql vem para este local


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return dt;

        }

        // Metodo que irá fazer operação de insert, update e delete no bd
        public string OpercaoSQL(string Sql)
        {
            try
            {
                var opcomando = new SqlCommand(Sql, fazconexao);
                opcomando.CommandTimeout = 0;
                var enviaopcmd = opcomando.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                ;
            }
        }

        public void Close()
        {
            fazconexao.Close();
        }



    }
}

