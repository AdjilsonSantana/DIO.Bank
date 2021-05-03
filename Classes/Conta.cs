using System;

namespace DIO.Bank
{
    public class Conta
    {
        // Atributos da conta
        private TipoConta TipoConta {get; set;}
        private string Nome {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}


        // Construtor 

        public Conta (TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        // Metodos

        public bool Debitar (double valorDebito)
        {
            //validacão de saldo suficiente 
            if (this.Saldo - valorDebito < (this.Credito * -1))
            {
                Console.WriteLine ("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorDebito;

            Console.WriteLine("Valor do débito: {0}, saldo actual da conta {1} é {2}",valorDebito, this.Nome, this.Saldo);

            return true;
        }

        public void Depositar (double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Valor do depósito: {0}, o saldo actual da conta {1} é de {2}", valorDeposito, this.Nome, this.Saldo);

        }

        public void Transferir (double valorTransferencia, Conta contaDestino)
        {
            if (this.Debitar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito ;
            return retorno;
        } 

    }
}