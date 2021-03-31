using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace ControleDespesa4
{
    class ConsultDB
    {
        
        public string msglog;
        public IniciaDB db;
        public string tabela;
        public List<string> listadesp = new List<string>();
		
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
					string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + " - " + (dataresult.Rows[i]["data_mov_despesa"].ToString() + " - " + dataresult.Rows[i]["valor_des"].ToString() + " - " + dataresult.Rows[i]["desc_despesa"].ToString());
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC3 MOdulo de Consulta - Com sucesso 3 ";
				}
				return listadesp;

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
				var Sql = ($"Select * from Mov_despesa where data_mov_despesa = '{dtdesp}'");
				var dataresult = db.ConsultaSQL(Sql);

				for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + " - " + (dataresult.Rows[i]["data_mov_despesa"].ToString() + " - " + dataresult.Rows[i]["valor_des"].ToString() + " - " + dataresult.Rows[i]["desc_despesa"].ToString());
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC5 MOdulo de Consulta - Com sucesso 5";
				}
				return listadesp;

			}
			catch
			{
				Console.WriteLine("Erro ao consultar Despesa 6");
				msglog = " #BDC6 MOdulo de Consulta - Erro despesa 6";
				
			}
			return listadesp;
		}

		public List<string> ConultaMovDepesa(int tipdesp)
		{
			var Sql = ($"Select * from Mov_Despesa where Id_mv_despesa = {tipdesp}");
			var dataresult = db.ConsultaSQL(Sql);

			try
			{
				for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + " - " + (dataresult.Rows[i]["data_mov_despesa"].ToString() + " - " + dataresult.Rows[i]["valor_des"].ToString() + " - " + dataresult.Rows[i]["desc_despesa"].ToString());
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC7 MOdulo de Consulta - Com sucesso 7";
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
			var Sql = ($"select * from Mov_Despesa where desc_despesa like '%{descdespesa}%'");
			var dataresult = db.ConsultaSQL(Sql);
			try
			{
				for (int i = 0; i<= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = (dataresult.Rows[i]["Id_mv_despesa"].ToString()) + " - " + (dataresult.Rows[i]["data_mov_despesa"].ToString()) + " - " +(dataresult.Rows[i]["valor_des"].ToString()) + " - " + (dataresult.Rows[i]["desc_despesa"].ToString());
					listadesp.Add(conteudo);
					msglog = " #BDC9 MOdulo de Consulta - Com sucesso 9";
					
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
					msglog = " #BDC16 MOdulo de INclusão - Inciado com sucesso 16 ";
				}
				return listadesp;
			}
			catch 
			{
				Console.WriteLine("Erro ao fazer a Inclusão 17");
				msglog = " #BDC17 MOdulo de Inclusão - Erro despesa 15 ";
			}
			return listadesp;
		}

		public List<string> ConsultaDespesa(int id)
		{
			var Sql = ($"Select * from Despesa where iddespesa = {id}");
			var dataresult = db.ConsultaSQL(Sql);
			try
			{
				for (int i = 0; i <= dataresult.Rows.Count - 1; i++)
				{
					string conteudo = dataresult.Rows[i]["iddespesa"].ToString() + " - " + dataresult.Rows[i]["nomedespesa"].ToString();
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC18 MOdulo de INclusão - Inciado com sucesso 18 ";
				}
				return listadesp;
			}
			catch
			{
				Console.WriteLine("Erro ao fazer a Inclusão 19");
				msglog = " #BDC19 MOdulo de Inclusão - Erro despesa 19 ";
			}
			return listadesp;
		}
		public List<string> ConsultaDespesa(string descdespesa)
		{
			var Sql = ($"Select * from Despesa where nomedespesa = '{descdespesa}'");
			var dataresult = db.ConsultaSQL(Sql);
			try
			{
				for (int i = 0; i <= dataresult.Rows.Count - 1; i ++)
				{
					string conteudo = dataresult.Rows[i]["iddespesa"].ToString() + " - " + dataresult.Rows[i]["nomedespesa"].ToString();
					listadesp.Add(conteudo);
					Console.WriteLine(conteudo);
					msglog = " #BDC20 MOdulo de INclusão - Inciado com sucesso 20 ";
				}
				return listadesp;
			}
			catch
			{
				Console.WriteLine("Erro ao fazer a Inclusão 20");
				msglog = " #BDC20 MOdulo de Inclusão - Erro despesa 20 ";
			}
			return listadesp;
		}
	}
}
