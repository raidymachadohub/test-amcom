using Questao5.Domain.Entities;

namespace Questao5.Services.Interfaces
{
    public interface IMovimentoService
    {
        Task<Movimento> InsereMovimento(Movimento movimento);
        Task<IEnumerable<Movimento>> SomaMovimento(string idCorrente);
    }
}