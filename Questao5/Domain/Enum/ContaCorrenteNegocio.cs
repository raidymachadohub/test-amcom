using System.ComponentModel;

namespace Questao5.Domain.Enum
{
    public enum ContaCorrenteNegocio
    {
        [Description("Conta corrente inválida")]
        INVALID_ACCOUNT = 1,

        [Description("Conta corrente inativa")]
        INACTIVE_ACCOUNT = 2,

        [Description("Valor recebido inválido")]
        INVALID_VALUE = 3,
        
        [Description("Tipo de depósito inválido")]
        INVALID_TYPE = 4,
        OK = 5
    }
}