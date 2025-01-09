using Domain.Base;
using Domain.DTO;
using Domain.Response;

namespace Domain.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client> GetByIdAsync(int code);

        Task<Client> GetByDocumentAndDocumentTypeAsync(long document, string documentType);

        Task<IEnumerable<FilterAddressClientResponse>> GetAddressAndFullNameClientAsync();
    }
}
