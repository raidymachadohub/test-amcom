namespace Questao1
{
    class ContaBancaria {
        public int conta  { get; set; }
        public string titular { get; set; }
        public double depositoInicial { get; set; }
        private double saldo { get; set; }
        public double Deposito(double quantia) => saldo += quantia;
        public double SaldoAtualizado() => saldo;
        public double Saque(double saque) =>  saldo = saldo - saque;
        public double SaldoComTaxa() => saldo -= 3.50;
        public ContaBancaria(int conta, string titular, double depositoInicial = 0)
        {
            this.conta = conta;
            this.titular = titular;
            this.depositoInicial = depositoInicial;
            this.saldo = depositoInicial;
        }

    }
}
