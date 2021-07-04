using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ControleDespesa4
{
    public class IncluirDB
    {
        public string mslog;
        public IniciaDB db;
        public string tabela;

        public IncluirDB(string Tabela)
        {
            try 
            {
                db = new IniciaDB();
                mslog = " #BDC10 MOdulo de Inclusão - Inciado com sucesso 10 "; 
            }

            catch
            {
                Console.WriteLine("Erro na consulta");
                mslog = " #BDC11 MOdulo de Inclusão - Erro inclusão 11";
            }
        }

        public void IncluirMovDespsa(int iddesp, DateTime dtdesp, decimal vldesp, string descdesp)
        {
            try
            {
                db = new IniciaDB();
                var strcon = db.sconexao;
                var Sql = "insert into Mov_Despesa values(@iddesp, @dtdesp, @vld , @descdesp)";
                using (SqlConnection conxao = new SqlConnection(strcon))
                {
                    conxao.Open();

                    using (var comando = new SqlCommand(Sql, conxao))
                    {
                        //var Sql = ($"insert into Mov_Despesa values ({iddesp}, '{dtdesp}', {vldesp}, '{descdesp}')");
                        //SqlCommand comando = new SqlCommand(Sql, conxao);

                        comando.Parameters.Add(new SqlParameter("@iddesp", iddesp));
                        comando.Parameters.Add(new SqlParameter("@dtdesp", dtdesp));
                        comando.Parameters.Add(new SqlParameter("@vld", vldesp));
                        comando.Parameters.Add(new SqlParameter("@descdesp", descdesp));
                        mslog = " #BDC12 MOdulo de Inclusão - Inciado com sucesso 12 ";
                        Console.WriteLine("Cadastro de Movimentação de despesa feito com sucesso");
                        comando.ExecuteNonQuery();


                    }


                }
                //var Sql = ($"insert into Mov_Despesa values ({iddesp}, '{dtdesp}', {vldesp}, '{descdesp}')");                

                //db.OpercaoSQL(Sql);
            }
            catch
            {
                Console.WriteLine("DEU ERROO NO LANCAMENTO");
                mslog = " #BDC13 MOdulo de Inclusão - Erro inclusão 13";
            }

        }

        
        public void IncluirDespesa(string nomedesp)
        {
            db = new IniciaDB();
            var strcon = db.sconexao;
            using (SqlConnection conexao = new SqlConnection(strcon))
            {
                conexao.Open();
                string Sql = "insert into Despesa values (@nomedesp)";
                using (var comando = new SqlCommand(Sql, conexao))
                {
                    comando.Parameters.Add(new SqlParameter("@nomedesp", nomedesp));
                    comando.ExecuteNonQuery();
                }
            }
                //try
                //{
                //    //var Sql = ($"insert into Despesa values ('{nomedesp}')");
                //    db.OpercaoSQL(Sql);
                //    mslog = " #BDC21 MOdulo de Inclusão Despesa - Inciado com sucesso 21 ";
                //    Console.WriteLine("Cadastro de Despesa feito com sucesso 21");
                //}
                //catch
                //{
                //    mslog = " #BDC22 MOdulo de Inclusão Despesa - com erro 22";
                //    Console.WriteLine("Cadastro de Despesa  com erro 22");
                //}

        }
        public void IncluirReceita(string descreceita)
        {
            try
            {
                db = new IniciaDB();
                var stcron = db.sconexao;
                using (SqlConnection conexao = new SqlConnection(stcron))
                {
                    conexao.Open();
                    string Sql = "insert into Receita values(@descreceita)";
                    using (var comando = new SqlCommand(Sql, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@descreceita", descreceita));
                        comando.ExecuteNonQuery();
                    }
                }
            }

                //try
                //{
                //   // var Sql = ($"insert into Receita values('{descreceita}')");
                //    db.OpercaoSQL(Sql);
                //    mslog = " #BDC23 MOdulo de Inclusão Despesa - Inciado com sucesso  ";
                //    Console.WriteLine("Cadastro de Despesa feito com sucesso 23 ");
                //}
             catch
            {
                mslog = " #BDC24 MOdulo de Inclusão Despesa - Inciado com sucesso  ";
                Console.WriteLine("Cadastro de Despesa feito com sucesso 24 ");
            }



        }
        public void IncluirMovReceita(int idmovreceita, DateTime dtreceita, decimal valorreceita, string descreceita)
        {
            try
            {
                var stcron = db.sconexao;
                using (SqlConnection conexao = new SqlConnection(stcron))
                {
                    conexao.Open();
                    string Sql = "insert into Mov_Receita values (@idmovreceita,@dtreceita, @valorreceita,@descreceita)";
                    using (var comando = new SqlCommand(Sql, conexao))
                    {
                        comando.Parameters.Add(new SqlParameter("@idmovreceita", idmovreceita));
                        comando.Parameters.Add(new SqlParameter("@dtreceita", dtreceita));
                        comando.Parameters.Add(new SqlParameter("@valorreceita", valorreceita));
                        comando.Parameters.Add(new SqlParameter("@descreceita", descreceita));
                        comando.ExecuteNonQuery();
                    }
                }
            }
                //try
                //{
                //    var Sql = ($"insert into Mov_Receita values ({idmovreceita}, '{dtreceita}', {valorreceita}, '{descreceita}')");
                //    db.OpercaoSQL(Sql);
                //    mslog = " #BDC MOdulo de Inclusão Despesa - Inciado com sucesso  ";
                //    Console.WriteLine("Cadastro de Despesa feito com sucesso ");

                
                catch
                {
                   mslog = "";
                   Console.WriteLine("Cadastro de Despesa  com erro ");
                }

        }
    }
}
