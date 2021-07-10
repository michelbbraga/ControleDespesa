using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Microsoft.SqlServer.Server;
using System.Threading;
using System.Xml.Serialization;

namespace ControleDespesa4
{
    public class ConsultDB
    {
		public string msglog;
        public IniciaDB db;
        public string tabela;
        public List<string> listadesp = new List<string>();
		public List<Imp_despesa> listadesp2 = new List<Imp_despesa>();
		

		public ConsultDB()
		{ 
		}
		public ConsultDB(string Tabela)
        {
			try
			{
				db = new IniciaDB();
				tabela = Tabela;
				msglog = " #BDC1 MOdulo de Consulta - Inciado com sucesso 1";

			}
			catch
			{
				Console.WriteLine("Erro na consulta");
				msglog = " #BDC2 MOdulo de Consulta - Erro despesa 2 ";
			}

		}

		public List<string> ConultaMovDepesa()
		{

			try
			{

				var Sql = ("Select * from Mov_despesa");
				var dataresult = db.ConsultaSQL(Sql);

				for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + "," + (dataresult.Rows[i]["data_mov_despesa"].ToString() + "," + dataresult.Rows[i]["valor_des"].ToString() + "," + dataresult.Rows[i]["desc_despesa"].ToString());
					listadesp.Add(conteudo);
					//id_mv_desp = dataresult.Rows[i]["Id_mv_despesa"].ToString();
					//id_desp = dataresult.Rows[i]["data_mov_despesa"].ToString();
					//data_despe = dataresult.Rows[i]["data_mov_despesa"].ToString();
					//valor_desp = dataresult.Rows[i]["valor_des"].ToString();
					//desc_desp = dataresult.Rows[i]["desc_despesa"].ToString();
					//new ModeloXML
					//{
					//	Codigo_desp = dataresult.Rows[i]["data_mov_despesa"].ToString(),
					//	Data_despesa = dataresult.Rows[i]["data_mov_despesa"].ToString(),
					//	Vl_despesa = dataresult.Rows[i]["data_mov_despesa"].ToString(),
					//	Descricao_desp = dataresult.Rows[i]["desc_despesa"].ToString()

					//};

					//listadesp2 = new List<Imp_despesa>();
					listadesp2.Add(new Imp_despesa()
					{
						Codigo_desp = dataresult.Rows[i]["Id_mv_despesa"].ToString(),
						Data_despesa = dataresult.Rows[i]["data_mov_despesa"].ToString(),
						Vl_despesa = dataresult.Rows[i]["valor_des"].ToString(),
						Descricao_desp = dataresult.Rows[i]["desc_despesa"].ToString()
					});

					Console.WriteLine(conteudo);
					msglog = " #BDC3 MOdulo de Consulta - Com sucesso 3 ";
					
				}

			}
			catch
			{
				Console.WriteLine("Erro ao consultar Despesa 4");
				msglog = " #BDC4 MOdulo de Consulta - Erro  4";
				
			}
			return listadesp;


		}

		public List<string> ConultaMovDepesa(DateTime dtdesp)
		{
			try
			{
				var strcon = db.sconexao;
				var Sql = "Select * from Mov_despesa where data_mov_despesa = @dtdesp";
				using (SqlConnection conexao = new SqlConnection(strcon))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@dtdesp", dtdesp));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						//comandoquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + " - " + (dataresult.Rows[i]["data_mov_despesa"].ToString() + " - " + dataresult.Rows[i]["valor_des"].ToString() + " - " + dataresult.Rows[i]["desc_despesa"].ToString());
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);

							msglog = " #BDC5 MOdulo de Consulta - Com sucesso 5";
						}
					}
				}
				return listadesp;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}			
		}

		public List<string> ConultaMovDepesa(int tipdesp)
		{
			var strcon = db.sconexao;
			var Sql = "Select * from Mov_Despesa where Id_mv_despesa = @tipdesp";
			//var dataresult = db.ConsultaSQL(Sql);

			try
			{
				using (SqlConnection conexao = new SqlConnection(strcon))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@tipdesp", tipdesp));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i < dataresult.Rows.Count - 1; i ++)
						{
							string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + " - " + (dataresult.Rows[i]["data_mov_despesa"].ToString() + " - " + dataresult.Rows[i]["valor_des"].ToString() + " - " + dataresult.Rows[i]["desc_despesa"].ToString());
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);

							msglog = " #BDC6 MOdulo de Consulta - Com sucesso 6";

						}
					}
				}
				return listadesp;
			}
			catch
			{
				Console.WriteLine("Erro de Consulta Despesa 7");
				msglog = " #BDC8 MOdulo de Consulta - Erro despesa 7";

			}
			return listadesp;
		}
		public List<string> ConultaMovDepesa(string descdespesa)
		{
			var Sql = "select * from Mov_Despesa where desc_despesa like @descdespesa";
			try
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@descdespesa", descdespesa));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + " - " + (dataresult.Rows[i]["data_mov_despesa"].ToString()) + " - " + (dataresult.Rows[i]["valor_des"].ToString()) + " - " + (dataresult.Rows[i]["desc_despesa"].ToString());
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC9 MOdulo de Consulta - Com sucesso 9";

						}
					}
				}
				return listadesp;
			}
			catch
			{
				Console.WriteLine("Erro de Consulta Despesa 4");
				msglog = " #BDC9 MOdulo de Consulta - Erro despesa 9";
				
			}
			return listadesp;


		}

		public List<string> ConsultaDespesa()
		{
			var Sql = "Select * from Despesa";
			var dataresult = db.ConsultaSQL(Sql);
			try
			{
				for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = dataresult.Rows[i]["iddespesa"].ToString() + " - " + dataresult.Rows[i]["nomedespesa"].ToString();
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC16 MOdulo de Consulta - Inciado com sucesso 16 ";
				}
				return listadesp;
			}
			catch 
			{
				Console.WriteLine("Erro ao fazer a Consulta 17");
				msglog = " #BDC17 MOdulo de Consulta - Erro despesa 15 ";
			}
			return listadesp;
		}

		public List<string> ConsultaDespesa(int id)
		{
			var Sql = ("Select * from Despesa where iddespesa = @id");			
			try
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao) )
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@id", id));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = dataresult.Rows[i]["iddespesa"].ToString() + " - " + dataresult.Rows[i]["nomedespesa"].ToString();
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC18 MOdulo de Consulta - Inciado com sucesso 18 ";
						}

					}
				}

				return listadesp;
			}
			catch
			{
				Console.WriteLine("Erro ao fazer a Consulta 19");
				msglog = " #BDC19 MOdulo de Consulta - Erro despesa 19 ";
			}
			return listadesp;
		}
		public List<string> ConsultaDespesa(string descdespesa)
		{
			var Sql = ("Select * from Despesa where nomedespesa like @descdespesa");			
			try
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@descdespesa", descdespesa));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = dataresult.Rows[i]["iddespesa"].ToString() + " - " + dataresult.Rows[i]["nomedespesa"].ToString();
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC20 MOdulo de Consulta - Inciado com sucesso 20 ";
						}
					}
				}

				return listadesp;
			}
			catch
			{
				Console.WriteLine("Erro ao fazer a Consulta 20");
				msglog = " #BDC20 MOdulo de Consulta - Erro despesa 20 ";
			}
			return listadesp;
		}

		public List<string> ConsultaMovReceita()
		{
			var Sql = ("Select * from Mov_Receita");
			var dataresult = db.ConsultaSQL(Sql);
			try
			{
				for (int i = 0 ; i <= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = dataresult.Rows[i]["Idmovreceita"].ToString() + " - " + dataresult.Rows[i]["Id_mv_receita"].ToString() + " - " + dataresult.Rows[i]["data_mov_receita"].ToString() + " - " + dataresult.Rows[i]["valor_rec"].ToString() + " - " + dataresult.Rows[i]["desc_receita"].ToString();
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC24 MOdulo de Consulta - Inciado com sucesso 24 ";
				}
				return listadesp;
			}
			catch
			{
				Console.WriteLine();
				msglog = " #BDC24 MOdulo de Consulta - Inciado com sucesso 24 ";
			}
			return listadesp;
		}
		public List<string> ConsultaMovReceita(DateTime dtreceita)
		{
			var Sql = ("select * from Mov_Receita where data_mov_receita = @dtreceita");
			try 
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@dtreceita", dtreceita));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = dataresult.Rows[i]["Idmovreceita"].ToString() + " - " + dataresult.Rows[i]["Id_mv_receita"].ToString() + " - " + dataresult.Rows[i]["data_mov_receita"].ToString() + " - " + dataresult.Rows[i]["valor_rec"].ToString() + " - " + dataresult.Rows[i]["desc_receita"].ToString();
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC24 MOdulo de Consulta - Inciado com sucesso 24 ";
						}

					}
				}
				return listadesp;
			}
			catch
			{
				Console.WriteLine("Erro ao fazer a Consulta 25");
				msglog = " #BDC20 MOdulo de Consulta - Erro despesa 25 ";
			}
			return listadesp;
		}

		public List<string> ConsultaMovReceita(int tipreceita)
		{
			var Sql = ($"select * from Mov_Receita where Id_mv_receita = @tipreceita ");
			
			try
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@tipreceita", tipreceita));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = dataresult.Rows[i]["Idmovreceita"].ToString() + " - " + dataresult.Rows[i]["Id_mv_receita"].ToString() + " - " + dataresult.Rows[i]["data_mov_receita"].ToString() + " - " + dataresult.Rows[i]["valor_rec"].ToString() + " - " + dataresult.Rows[i]["desc_receita"].ToString();
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC26 MOdulo de Consulta - Inciado com sucesso 26 ";
						}
						return listadesp;
					}
				}
			}
						
			catch
			{
				Console.WriteLine("Erro ao fazer a Conslulta 27");
				msglog = " #BDC27 MOdulo de Consulta - Erro despesa 27";
			}
			return listadesp;
		}
		public List<string> ConsultaMovReceita(string nomereceita)
		{
			var Sql = ($"select * from Mov_Receita where desc_receita like @nomereceita");
			
			try
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@nomereceita", nomereceita));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader(); ;
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = dataresult.Rows[i]["Idmovreceita"].ToString() + " - " + dataresult.Rows[i]["Id_mv_receita"].ToString() + " - " + dataresult.Rows[i]["data_mov_receita"].ToString() + " - " + dataresult.Rows[i]["valor_rec"].ToString() + " - " + dataresult.Rows[i]["desc_receita"].ToString();
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC26 MOdulo de Consulta - Inciado com sucesso 26 ";
						}
						return listadesp;
					}
				}

			}

			catch
			{
				Console.WriteLine("Erro ao fazer a Inclusão 27");
				msglog = " #BDC27 MOdulo de Consulta - Erro despesa 27";
			}
			return listadesp;
		}
		public List<string> ConsultaReceita()
		{
			var Sql = ("Select * from Receita");
			var dataresult = db.ConsultaSQL(Sql);
			try
			{
				for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = dataresult.Rows[i]["Idreceita"].ToString() + " - " + dataresult.Rows[i]["nomereceta"].ToString();
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC28 MOdulo de Consulta - Inciado com sucesso 28 ";
				}
				return listadesp;
			}
			catch
			{
				Console.WriteLine();
				msglog = " #BDC28 MOdulo de Consulta - Inciado com sucesso 28 ";
			}
			return listadesp;
		}
		public List<string> ConsultaReceita(int receita)
		{
			var Sql = "select * from Receita where Idreceita = @receita";
			
			try 
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@receita", receita));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = dataresult.Rows[i]["Idreceita"].ToString() + " - " + dataresult.Rows[i]["nomereceta"].ToString();
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC28 MOdulo de Consulta - Inciado com sucesso 28 ";

						}
						return listadesp;
					}	
				}
			}

			catch
			{
				Console.WriteLine("Erro ao fazer a Consulta 27");
				msglog = " #BDC27 MOdulo de Consulta - Erro despesa 27";
			}
			return listadesp;

		}
		public List<string> ConsultaReceita(string receita)
		{
			var Sql = "select * from receita where nomereceta like @receita";			
			try
			{
				using (SqlConnection conexao = new SqlConnection(db.sconexao))
				{
					conexao.Open();
					using (SqlCommand comandquery = new SqlCommand(Sql, conexao))
					{
						comandquery.Parameters.Add(new SqlParameter("@receita", receita));
						comandquery.CommandTimeout = 0;
						DataTable dataresult = new DataTable();
						var leitor = comandquery.ExecuteReader();
						dataresult.Load(leitor);
						for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
						{
							string conteudo = dataresult.Rows[i]["Idreceita"].ToString() + " - " + dataresult.Rows[i]["nomereceta"].ToString();
							listadesp.Add(conteudo);
							Console.WriteLine(conteudo);
							msglog = " #BDC28 MOdulo de Consulta - Inciado com sucesso 28 ";

						}
						return listadesp;
					}
				}
			}

			catch
			{
				Console.WriteLine("Erro ao fazer a Inclusão 29");
				msglog = " #BDC29 MOdulo de Consulta - Erro despesa 29";
			}
			return listadesp;
		}
	}
}
