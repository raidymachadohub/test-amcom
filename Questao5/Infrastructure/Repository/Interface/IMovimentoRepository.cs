using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Repository.Interface
{
    public interface IMovimentoRepository
    {
        Task<Movimento> AddMovimento(Movimento movimento);
        Task<IEnumerable<Movimento>> SomaMovimento(string idCorrente);
    }
}