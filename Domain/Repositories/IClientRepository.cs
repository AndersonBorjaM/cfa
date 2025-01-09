using Domain.Base;
using Domain.DTO;

namespace Domain.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client> GetByIdAsync(int code);

        Task<Client> GetByDocumentAndDocumentTypeAsync(long document, string documentType);

        Task<Client> CreateClientSpAsync(Client client);
    }
}
