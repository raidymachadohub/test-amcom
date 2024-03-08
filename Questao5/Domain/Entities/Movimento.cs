using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Questao5.Domain.Entities
{
    [Table("movimento")]
    public class Movimento
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idmovimento")]
        public string? IdMovimento { get; set; }
        [Column("idcontacorrente")]
        public string IdContaCorrente { get; set; }
        [Column("datamovimento")]
        public string DataMovimento { get; set; }
        [Column("tipomovimento")]
        public string TipoMovimento { get; set; }
        [Column("valor")]
        public double Valor { get; set; }


        public Movimento(string idMovimento, string idContaCorrente, string dataMovimento, string tipoMovimento, double valor)
        {
            IdMovimento = idMovimento;
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }
    }
}