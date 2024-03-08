using Questao5.Domain.Entities;

namespace Questao5.Services.Interfaces
{
    public interface IContaCorrenteService
    {
        Task<ContaCorrente> ValidaContaCorrente(string idContaCorrente);
        Task<ContaCorrente> SaldoConta(string idContaCorrente);
    }
}