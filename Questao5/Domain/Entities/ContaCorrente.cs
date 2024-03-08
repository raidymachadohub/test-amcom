using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("contacorrente")]
    public class ContaCorrente
    {
        [Column("idcontacorrente")]
        public string IdContaCorrente { get; set; }
        [Column("numero")]
        public int Numero { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }

        [NotMapped]
        public double SaldoAtual { get; set; }

        public ContaCorrente(string idContaCorrente, int numero, string nome, bool ativo)
        {
            IdContaCorrente = idContaCorrente;
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
        }
    }
}