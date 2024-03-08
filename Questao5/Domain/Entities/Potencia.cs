using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("idempotencia")]
    public class Potencia
    {
        [Column("chave_idempotencia")]
        public string IdPotencia { get; set; }
        
        [Column("requisicao")]
        public string Requisicao { get; set; }
        
        [Column("resultado")]
        public string Resultado { get; set; }

        public Potencia(string idPotencia, string requisicao, string resultado)
        {
            IdPotencia = idPotencia;
            Requisicao = requisicao;
            Resultado = resultado;
        }
    }
}