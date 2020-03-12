using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        readonly Conta conta;

        public Cliente(string nome, string CPF, Conta conta)
        {
            this.Nome = nome;
            this.CPF = CPF;
            this.conta = conta;
        }
    }
}
