using Questao5.Domain.Enum;

namespace Questao5.FlowControls
{
    public static class SimpleResult
    {
        public static Error Success()
        {
            return new()
            {
                Descricao = "",
                Negocio = ContaCorrenteNegocio.OK,
                Status = false
            };
        }

        public static Error Fail(ContaCorrenteNegocio correnteNegocio, string descricao)
        {
            return new()
            {
                Descricao = descricao,
                Negocio = correnteNegocio,
                Status = false
            };
        }
    }

    public class Error
    {
        public string? Descricao { get; set; }
        public ContaCorrenteNegocio Negocio { get; set; }
        public bool Status { get; set; }
    }
}