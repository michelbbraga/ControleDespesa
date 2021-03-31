using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDespesa4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuap = true;

            do
            {
                Console.WriteLine("BEM VINDO AO MENU PRINCIPAL, SISTEMA DE CONTROLE DE DESPESA");
                Console.WriteLine($"Operações com despesa: \n 1 - Lançar \n 2 - Consultar \n 3 - Excluir");
                Console.WriteLine($"Operações com Receita: \n 4 - Lançar \n 5 - Consultar \n 6 - Excluir");
                Console.WriteLine($"Operações de Administracao: \n 7 - Cadastrar novo tipo de despesa " +
                                  $"\n 8 - Consultar tipo de Despesa \n 9 - Excluir tipo de despesa" +
                                  $"\n 10 - Cadastrar novo tipo de receita \n 11 - Conultar tipo de receita \n 12 - Excluir tipo de receita");
                int opmenu = int.Parse(Console.ReadLine());

                Despesa operadesp = new Despesa();
                switch (opmenu)
                {
                    case 1:
                        operadesp.Lacadespesa(opmenu);
                        break;
                    case 2:
                        operadesp.Consultar(opmenu);
                        Console.ReadLine();
                        break;
                    case 3:
                        operadesp.Excluidepesa(opmenu);
                        break;
                    case 7:
                        operadesp.Lacadespesa(opmenu);
                        break;
                    case 8:
                        operadesp.Consultar(opmenu);
                        break;
                    case 9:
                        operadesp.Excluidepesa(opmenu);
                        break;
                    default:
                        Console.WriteLine("Opção invalida !!!");
                        break;
                }
                Console.WriteLine("Deseja continuar o lançamentos S ou N");
                string prosseguir = Console.ReadLine().ToUpper();
                
                if (prosseguir == "S")
                {
                    continuap = true;
                }
                else if (prosseguir == "N")
                {
                    continuap = false;
                }
                else
                    Console.WriteLine("Opção invalida, sistema voltara para o Inicio");
                    
            } while (continuap == true);
        }       
    }
}
