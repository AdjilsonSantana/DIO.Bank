using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        // Armazenar os dados da conta momentariamente
        static List<Conta> listContas = new List<Conta>();

        // Função principal
        static void Main(string[] args)
        {

            string opcaoUser = ObterOpcaoUser();

            while (opcaoUser.ToUpper() != "X")
            {
                switch (opcaoUser)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2": 
                        AdicionarConta();
                        break;
                    case "3": 
                        Transferir();
                        break;
                    case "4":
                        Levantar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUser = ObterOpcaoUser();
            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços.");
            Console.WriteLine("@ BancoDIO 2021");
            Console.WriteLine();

        }

        // Métodos

        private static void Transferir()
        {
            Console.WriteLine("Insira o número da sua Conta: ");
            int inNumeroConta = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}", listContas[inNumeroConta]);

            Console.WriteLine("Insira o número da conta destino: ");
            int inContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor a transferir: ");
            double inValorATransferir = double.Parse(Console.ReadLine());

            listContas[inNumeroConta].Transferir(inValorATransferir, listContas[inContaDestino]);

        }
        private static void Depositar()
        {
            Console.WriteLine("Insira o número da conta: ");
            int inNumeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor a depositar: ");
            double inValorADepositar = double.Parse(Console.ReadLine());

            listContas[inNumeroConta].Depositar(inValorADepositar);
        }

        private static void Levantar()
        {
            Console.WriteLine("Insira o número da conta: ");
            int inNumeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor a levantar: ");
            double inValorALevantar = double.Parse(Console.ReadLine());

            listContas[inNumeroConta].Debitar(inValorALevantar);
        }

        private static void ListarContas()
        {
             Console.WriteLine("Lista de Contas");

             if (listContas.Count == 0)
             {
                 Console.WriteLine("Nenhuma Conta registada");
                 return;
             }
             
             for (int i = 0; i < listContas.Count; i++)
             {
                 Conta conta = listContas[i];
                 Console.Write("#{0} - ", i);
                 Console.WriteLine(conta);
             }            
        }

        private static void AdicionarConta()
        {
            Console.WriteLine("Prima 1 para Conta Física ou 2 para Conta Jurídica: ");
            int inTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome da Conta: ");
            string inNomeConta = Console.ReadLine();

            Console.WriteLine("Valor de saldo: ");
            double inSaldoConta = double.Parse(Console.ReadLine());

            Console.WriteLine ("Valor de crédito: ");
            double inCreditoConta = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta) inTipoConta,
                                        nome: inNomeConta,
                                        saldo: inSaldoConta,
                                        credito: inCreditoConta );
            
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine(" == Banco DIO Exercício ==");
            Console.WriteLine("Informa a opção pretendida: ");

            Console.WriteLine("1- Lista de contas");
            Console.WriteLine("2- Adicionar nova conta");
            Console.WriteLine("3- Efectuar Transferência");
            Console.WriteLine("4- Levantar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar ecrã");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
        }
    }
}
