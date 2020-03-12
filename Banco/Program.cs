using System;
using System.Collections.Generic;
using System.IO;

namespace Banco
{
    class Program {
        
        TextReader scan = Console.In;
        List<Conta> lista = new List<Conta>();
        int i;
        int j;
        int esc;
        string nome;
        string CPF;
        float valor;
        Conta c1, c2;
        



        public void Cadastro()
        {
            Console.WriteLine("> Qual o nome do cliente a ser cadastrado?");
            nome = scan.ReadLine();
            
            do
            {
                esc = 0;

                Console.WriteLine("> Qual o CPF do novo cliente?");
                CPF = scan.ReadLine();
                foreach (Conta item in lista)
                {
                    if (CPF.Equals(item.cliente.CPF))
                    {
                        Console.WriteLine("CPF ja cadastrado !!! Insira novamente.");
                        esc++;
                    }
                }
            } while (esc > 0);

            Conta conta = new Conta();
            
            Cliente cliente = new Cliente(nome, CPF, conta);
            conta.cliente = cliente;
            lista.Add(conta);
                
            Console.WriteLine("Conta criada! Bem vindo " + nome + "!");
            Console.WriteLine("Número da conta: " + conta.Numero);
            conta.VerificarSaldo();
        }


        public void Operações()
        {
            esc = 0;
            Console.WriteLine("Qual o nome do cliente?");
            nome = scan.ReadLine();
            foreach(Conta item in lista)
            {
                if (nome.Equals(item.cliente.Nome))
                {
                    Console.WriteLine("Bem Vindo, " + nome + ".");
                    Console.WriteLine("CPF cadastrado " + item.cliente.CPF);
                    Console.WriteLine("Número da conta: " + item.Numero);
                    Console.WriteLine("O que deseja fazer?");
                    c1 = item;
                    esc++;
                }
            }

            if (esc == 0)
                Console.WriteLine("Cliente não encontrado");
            else
            {

                do
                {
                    Console.WriteLine("> Checar saldo (1)");
                    Console.WriteLine("> Depositar (2)");
                    Console.WriteLine("> Sacar (3)");
                    Console.WriteLine("> Transferir (4)");
                    Console.WriteLine("> Sair da conta (0)");

                    j = Convert.ToInt32(scan.ReadLine());

                    switch (j)
                    {
                        case 1:
                            c1.VerificarSaldo();
                            break;
                        case 2:
                            this.Deposito(c1);
                            break;
                        case 3:
                            this.Saque(c1);
                            break;
                        case 4:
                            this.Transferencia(c1);
                            break;
                        case 0:

                            break;
                        default:
                            Console.WriteLine("Nenhuma operação selecionada.");
                            break;
                    }
                } while (j > 0);
                

            }
        }

        public void Deposito(Conta c)
        {
            Console.WriteLine("Qual o valor a depositar?");
            valor = Convert.ToSingle(scan.ReadLine());
            c.Depositar(valor);
            Console.WriteLine("Depósito realizado.");
            c.VerificarSaldo();
        }

        public void Saque(Conta c)
        {
            Console.WriteLine("Quanto deseja sacar?");
            valor = Convert.ToSingle(scan.ReadLine());
            if (c.Saldo < valor)
            {
                Console.WriteLine("Saldo insuficiente em conta.");
            }
            else
            {
                c.Sacar(valor);
                Console.WriteLine("Saque efetuado.");
                c.VerificarSaldo();
            }
        }

        public void Transferencia(Conta c)
        {
            switch (lista.Count)
            {
                case 1:
                    Console.WriteLine("Ainda não existem outras contas no sistema para trasferência.");
                    break;
                default:
                    Console.WriteLine("Para quem deseja transferir?");
                    nome = scan.ReadLine();
                    esc = 0;
                    foreach (Conta item in lista)
                    {
                        if (nome.Equals(item.cliente.Nome))
                        {
                            c2 = item;
                            esc++;
                        }
                    }

                    if (esc == 0)
                    {
                        Console.WriteLine("Cliente não encontrado");
                        Transferencia(c);
                    }
                    else
                    {
                        Console.WriteLine("Quanto deseja transferir?");
                        valor = Convert.ToSingle(scan.ReadLine());
                        if (c.Saldo < valor)
                        {
                            Console.WriteLine("Saldo insuficiente em conta.");
                        }
                        else
                        {
                            c.Transferir(valor, c2);
                            Console.WriteLine("Transferência efetuada.");
                            c.VerificarSaldo();
                            c2.VerificarSaldo();
                        }
                    }

                    break;
            }
                
           
        }


        static void Main()
        {
            Program p = new Program();

            
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("> Digite 1 para criar conta");
                Console.WriteLine("> Digite 2 para fazer operações");
                Console.WriteLine("> Digite 0 para encerrar");
                p.i = Convert.ToInt32(p.scan.ReadLine());
                if (p.i == 1)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("CADASTRO DE CLIENTES");
                    Console.WriteLine("------------------------------------------");
                    p.Cadastro();
                }
                else if (p.i == 2)
                {
                    if (p.lista.Count == 0)
                    {
                        Console.WriteLine("!!!Nenhum cliente cadastrado ainda!!!"); 
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("ABRINDO CAIXA ELETRÔNICO");
                        Console.WriteLine("------------------------------------------");
                        p.Operações();
                    }
                        
                }
                else if (p.i == 0)
                {
                    Console.WriteLine("Sistema encerrando . . .");
                }
                else
                {
                    Console.WriteLine("!!! Digite um valor valido !!!");
                }
            } while (p.i > 0);
            
        }
    }
}
