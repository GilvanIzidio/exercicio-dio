using System;
using System.Collections.Generic;

namespace DIOBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            String opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                    break;
                    
                    case "2":
                        InserirConta();
                    break;

                    case "3":
                        Transferir();
                    break;

                    case "4":
                        Sacar();
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

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos Servicos. ");
            Console.ReadLine();

         }

        private static void Transferir()
        {
           Console.WriteLine("Digite o numero da conta de Origem: ");
           int indiceContaOrigem = int.Parse(Console.ReadLine());

           Console.WriteLine("Digite o numero da Conta de destino: ");
           int indiceContaDestino = int.Parse(Console.ReadLine());

           Console.WriteLine("Digite o valor a ser transferido: ");
           double valorTransferencia = double.Parse(Console.ReadLine());

           listContas[indiceContaOrigem].Transferir(valorTransferencia,listContas[indiceContaDestino]);
            
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.WriteLine(" Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.Write("Digite 1 para Conta Fisica ou 2 para conta PJ: * ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas: ");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada: ");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
         {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu Dispor!!!");
            Console.WriteLine("Informe a Opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferencia");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;

        }

    }
}
