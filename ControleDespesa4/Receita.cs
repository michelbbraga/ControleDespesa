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


        IncluirDB incluirrec = new IncluirDB("Receita");
        IncluirDB incluimvrec = new IncluirDB("Mov_Receita");
        ConsultDB fazconsulta = new ConsultDB("Receita");

        public void Lancarreceitas(int idopmenu)

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
        public void Consultar(int idopmenu)
        {
            Console.WriteLine("Bem vindo a consulta de Receita, o que deseja consultar");
            if (idopmenu == 5)
            {
                Console.WriteLine(" 1 - Todos lançamentos \n 2 - Por data \n 3 - Por tipo \n 4 - Por descrição");
            }
            if (idopmenu == 11)
            {
                Console.WriteLine(" 1 - Todos lançamentos  \n 3 - Por tipo \n 4 - Por descrição");
            }

            int opconsultdesp = int.Parse(Console.ReadLine());

            switch (opconsultdesp)
            {
                case 1:
                    //chamar a consulta ao banco 
                    if (idopmenu == 5)
                    {
                        //fazconsulta.ConultaMovDepesa();
                        fazconsulta.ConsultaMovReceita();
                    }
                    if (idopmenu == 11)
                    {
                        fazconsulta.ConsultaReceita();
                    }

                    break;
                case 2:
                    //chamar a consulta ao banco
                    Console.WriteLine("Cosnulta 2");
                    Console.Write("Digite a data que deseja filtrar: ");
                    DateTime dtlanc = DateTime.Parse(Console.ReadLine());
                    fazconsulta.ConsultaMovReceita(dtlanc);

                    break;
                case 3:
                    //chamar a consulta ao banco
                    Console.WriteLine("Cosnulta 3");
                    Console.Write("Digite o codigo do tipo que  deseja filtrar: ");
                    int idtipo = int.Parse(Console.ReadLine());
                    if (idopmenu == 5)
                    {
                        fazconsulta.ConsultaMovReceita(idtipo);
                    }
                    if (idopmenu == 11)
                    {
                        fazconsulta.ConsultaReceita(idtipo);
                    }
                    break;
                case 4:
                    Console.WriteLine("Consulta 4");
                    Console.Write("Digite a descrição que  deseja filtrar: ");
                    string receita = Console.ReadLine();
                    if (idopmenu == 5)
                    {
                        fazconsulta.ConsultaMovReceita(receita);
                    }
                    if (idopmenu == 11)
                    {
                        fazconsulta.ConsultaReceita(receita);
                    }
                    break;

            }
        }
        public void ExcluiReceita(int idopmenu)
        {
            string idcasecoluna = "";

            if (idopmenu == 6)
            {
                Console.WriteLine("Bem Vindo a Exclusão");
                Console.Write(" O que deseja excluir ");
                Consultar(5);  // 2 sao consultas referentes a tab de Movimentacao de Receita
                Console.Write(" Informe o indice da coluna que quer excluir (1,2,3,4) ");
                int indicoluna = int.Parse(Console.ReadLine());
                Console.Write(" Informe qual conteudo do campo a ser excluido:  ");
                string campconteudo = Console.ReadLine();

                switch (indicoluna)
                {
                    case 1:
                        idcasecoluna = "Id_mv_receita";
                        break;
                    case 2:
                        idcasecoluna = "data_mov_receita";
                        break;
                    case 3:
                        idcasecoluna = "valor_rec";
                        break;
                    case 4:
                        idcasecoluna = "desc_receita";
                        break;
                }
                ExcluirDB excluimovdespDB = new ExcluirDB("Mov_Receita", idcasecoluna, campconteudo);
                Console.WriteLine("Digite ENTER para finalizar");
                Console.ReadKey();
            }
            if (idopmenu == 12)
            {

                Console.WriteLine("Bem Vindo a Exclusão");
                Console.Write(" O que deseja excluir verifique os registros:  ");
                Consultar(11);
                Console.Write(" Informe o indice da coluna que quer excluir (1 ou 2) ");
                int indicoluna = int.Parse(Console.ReadLine());
                Console.Write(" Informe qual conteudo do campo a ser excluido:  ");
                string campconteudo = Console.ReadLine();

                switch (indicoluna)
                {
                    case 1:
                        idcasecoluna = "Idreceita";
                        break;
                    case 2:
                        idcasecoluna = "nomereceta";
                        break;
                }
                ExcluirDB excluidespDB = new ExcluirDB("Receita", idcasecoluna, campconteudo);
                Console.WriteLine("Digite ENTER para finalizar");
                Console.ReadKey();
            }

        }

    }
}
