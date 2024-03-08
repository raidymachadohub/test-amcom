using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Repository.Interface
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> ValidaContaCorrente(string idContaCorrente);
        Task<ContaCorrente> SaldoConta(string idContaCorrente);
    }
}