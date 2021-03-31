using System;
using System.Collections.Generic;
using System.Linq;
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
                var Sql = ($"insert into Mov_Despesa values ({iddesp}, '{dtdesp}', {vldesp}, '{descdesp}')");
                db.OpercaoSQL(Sql);
                mslog = " #BDC12 MOdulo de Inclusão - Inciado com sucesso 12 ";
                Console.WriteLine("Cadastro de Movimentação de despesa feito com sucesso");
            }
            catch
            {
                Console.WriteLine("DEU ERROO NO LANCAMENTO");
                mslog = " #BDC13 MOdulo de Inclusão - Erro inclusão 13";
            }
        }
        public void IncluirDespesa(string nomedesp)
        {
            try
            {
                var Sql = ($"insert into Despesa values ('{nomedesp}')");
                db.OpercaoSQL(Sql);
                mslog = " #BDC21 MOdulo de Inclusão Despesa - Inciado com sucesso 21 ";
                Console.WriteLine("Cadastro de Despesa feito com sucesso 21");
            }
            catch
            {
                mslog = " #BDC22 MOdulo de Inclusão Despesa - com erro 22";
                Console.WriteLine("Cadastro de Despesa  com erro 22");
            }

        }
    }
}
