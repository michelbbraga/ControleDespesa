using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ControleDespesa4
{
    public class Despesa
    {
        public decimal vl_despesa;
        public string nome_despesa;
        public string descricao_despesa;
        public DateTime data_despesa;
        public bool recorencia;
        public string tip_recorrencia;
        public int periodo_recorr;
        public int codigo_desp;

        ConsultDB fazconsulta = new ConsultDB("Mov_despesa");
        IncluirDB incluimvdesp = new IncluirDB("Mov_despesa");
        

        public void Lacadespesa(int idopmenu)
        {
            if (idopmenu == 1)
            {
                Console.WriteLine("Bem Vindo ao Lançamento de despesas !!!!");

                Console.Write("Informe o codigo do tipo de despesa:  ");
                codigo_desp = int.Parse(Console.ReadLine());

                Console.Write("Informe o a data da despesa:  ");
                data_despesa = DateTime.Parse(Console.ReadLine());

                Console.Write("Informe o valor da despesa:  ");
                vl_despesa = decimal.Parse(Console.ReadLine());

                Console.Write("Informe o valor a descrição da despesa:  ");
                descricao_despesa = Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("Bem Vindo ao Administração de despesas !!!!");

                Console.Write("Informe o valor a descrição da despesa:  ");
                descricao_despesa = Console.ReadLine();
            }

            if (idopmenu == 1)
            {
                incluimvdesp.IncluirMovDespsa(codigo_desp, data_despesa, vl_despesa, descricao_despesa);
            }
            if (idopmenu == 7)
            {
                incluimvdesp.IncluirDespesa(descricao_despesa);
            }
            

        }

        public void Consultar(int idopmenu)
        {
            Console.WriteLine("Bem vindo a consulta, o que deseja consultar");
            if (idopmenu == 2)
            {
                Console.WriteLine(" 1 - Todos lançamentos \n 2 - Por data \n 3 - Por tipo \n 4 - Por descrição");
            }
            else 
            {
                Console.WriteLine(" 1 - Todos lançamentos  \n 3 - Por tipo \n 4 - Por descrição");
            }
            
            int opconsultdesp = int.Parse(Console.ReadLine());

            switch (opconsultdesp)
            {
                case 1:
                    //chamar a consulta ao banco 
                    if (idopmenu == 2)
                    {
                        fazconsulta.ConultaMovDepesa();
                    }
                    else 
                    {
                        fazconsulta.ConsultaDespesa(); 
                    }
                    
                    break;
                case 2:
                    //chamar a consulta ao banco
                    Console.WriteLine("Cosnulta 2");
                    Console.Write("Digite a data que deseja filtrar: ");
                    DateTime dtlanc = DateTime.Parse(Console.ReadLine());
                    fazconsulta.ConultaMovDepesa(dtlanc);

                    break;
                case 3:
                    //chamar a consulta ao banco
                    Console.WriteLine("Cosnulta 3");
                    Console.Write("Digite o codigo do tipo que  deseja filtrar: ");
                    int idtipo = int.Parse(Console.ReadLine());
                    if (idopmenu == 2)
                    {
                        fazconsulta.ConultaMovDepesa(idtipo);
                    }
                    else
                    {
                        fazconsulta.ConsultaDespesa(idtipo);
                    }
                    break;
                case 4:
                    Console.WriteLine("Consulta 4");
                    Console.Write("Digite a descrição que  deseja filtrar: ");
                    string descdesp = Console.ReadLine();
                    if (idopmenu == 2)
                    {
                        fazconsulta.ConultaMovDepesa(descdesp);
                    }
                    else
                    {
                        fazconsulta.ConsultaDespesa(descdesp);
                    }
                        
                    break;

            }
        }

        public void Excluidepesa(int idopmenu)
        {
            string idcasecoluna = "";

            if (idopmenu == 3 )
            {
                Console.WriteLine("Bem Vindo a Exclusão");
                Console.Write(" O que deseja excluir ");
                Consultar(2);  // 2 sao consultas referentes a tab de Movimentacao de despesa
                Console.Write(" Informe o indice da coluna que quer excluir (1,2,3,4) ");
                int indicoluna = int.Parse(Console.ReadLine());
                Console.Write(" Informe qual conteudo do campo a ser excluido:  ");
                string campconteudo = Console.ReadLine();

                switch (indicoluna)
                {
                    case 1:
                        idcasecoluna = "Id_mv_despesa";
                        break;
                    case 2:
                        idcasecoluna = "data_mov_despesa";
                        break;
                    case 3:
                        idcasecoluna = "valor_des";
                        break;
                    case 4:
                        idcasecoluna = "desc_despesa";
                        break;
                }
                ExcluirDB excluimovdespDB = new ExcluirDB("Mov_despesa", idcasecoluna, campconteudo);
                Console.WriteLine("Digite ENTER para finalizar");
                Console.ReadKey();
            }
            if (idopmenu == 9)
            {

                Console.WriteLine("Bem Vindo a Exclusão");
                Console.Write(" O que deseja excluir verifique os registros:  ");
                Consultar(1);  
                Console.Write(" Informe o indice da coluna que quer excluir (1 ou 2) ");
                int indicoluna = int.Parse(Console.ReadLine());
                Console.Write(" Informe qual conteudo do campo a ser excluido:  ");
                string campconteudo = Console.ReadLine();

                switch (indicoluna)
                {
                    case 1:
                        idcasecoluna = "Iddespesa";
                        break;
                    case 2:
                        idcasecoluna = "nomedespesa";
                        break;
                }
                ExcluirDB excluidespDB = new ExcluirDB("Despesa", idcasecoluna, campconteudo);
                Console.WriteLine("Digite ENTER para finalizar");
                Console.ReadKey();
            }

        }
         
    }

}
