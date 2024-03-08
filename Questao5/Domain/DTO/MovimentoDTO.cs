using Newtonsoft.Json;

namespace Questao5.Domain.DTO
{
    public class MovimentoDTO
    {
        public string? IdMovimento { get; set; }
      
        [JsonProperty(Required = Required.Always)]
        public string IdContaCorrente { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string DataMovimento { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string TipoMovimento { get; set; }
        [JsonProperty(Required = Required.Always)]
        public double Valor { get; set; }

        [JsonConstructor]
        public MovimentoDTO(string? idMovimento, string idContaCorrente, string dataMovimento, string tipoMovimento, double valor)
        {
            IdMovimento = idMovimento;
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }
    }
}