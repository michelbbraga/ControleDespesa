using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDespesa4
{
    class Receita
    {
        public decimal vl_receita;
        public string nome_receita;
        public string descricao_receita;
        public DateTime data_receita;
        public bool recorencia;
        public string tip_recorrencia;
        public int periodo_recorr;
        public int codigo_receita;

        public void LancarReceitas(int idopmenu)

        {
            if (idopmenu == 4)
            {
                Console.WriteLine("Bem Vindo ao Lançamento de Receitas !!!!");

                Console.Write("Informe o codigo do tipo de Receita:  ");
                codigo_receita = int.Parse(Console.ReadLine());

                Console.Write("Informe o a data da Receita:  ");
                data_receita = DateTime.Parse(Console.ReadLine());

                Console.Write("Informe o valor da Receita:  ");
                vl_receita = decimal.Parse(Console.ReadLine());

                Console.Write("Informe o valor a descrição da Receita:  ");
                descricao_receita = Console.ReadLine();
            }
            if (idopmenu == 10)
            {
                Console.WriteLine("Bem Vindo ao Administração de Receita !!!!");

                Console.Write("Informe o valor a descrição da Receita:  ");
                descricao_receita = Console.ReadLine();
            }
        }
    }
}
