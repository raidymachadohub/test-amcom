using System.ComponentModel;

namespace Questao5.Domain.Enum
{
    public enum TipoMovimento
    {
        [Description("C")] CREDITO = 1,
        [Description("D")] DEBITO = 2,
    }
}