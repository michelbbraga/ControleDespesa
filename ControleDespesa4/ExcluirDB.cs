using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDespesa4
{
    class ExcluirDB : IniciaDB
    {
        // Tentativa de fazer a operação com o banco usando herança e não fazendo uma instacia do BD
        public string mslog;
        
        public ExcluirDB(string Tabela, string Campo, string Condicao)
        {
            try
            {
                
                var Sql = ($"Delete {Tabela} where {Campo} = @Condicao");
                OpercaoSQL(Sql, Condicao);
                mslog = " #BDC14 MOdulo de Exclucao - Inciado com sucesso 14 ";

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fazer a exclusão");
                mslog = " #BDC15 MOdulo de Exclucao - Erro ao excluir 15 ";

            }
        }


    }
}
