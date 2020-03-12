using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    class Conta
    {
        Random randNum = new Random();
        public float Saldo { get; set; }
        public int Numero { get; set; }
        public Cliente cliente { get; set; }

        public Conta()
        {
            this.Numero = randNum.Next(8999)+1000;
            this.Saldo = 0;
        }


        public void VerificarSaldo()
        {
            Console.WriteLine("Saldo do cliente "+this.cliente.Nome+" é R$ " + this.Saldo);
        }

        public void Depositar(float valor)
        {
            this.Saldo += valor;
        }

        public void Sacar(float valor)
        {
            this.Saldo -= valor;
        }

        public void Transferir(float valor, Conta c)
        {
            this.Sacar(valor);
            c.Depositar(valor);
        }
    }
}
