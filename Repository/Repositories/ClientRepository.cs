using Domain.DTO;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Database;

namespace Repository.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<Client> GetByIdAsync(int code)
            => await _table.FirstOrDefaultAsync(x => x.ClientId == code);
        public async Task<Client> GetByDocumentAndDocumentTypeAsync(long document, string documentType)
            => await _table.FirstOrDefaultAsync(x => x.Document == document && x.DocumentType == documentType);

        public async Task<Client> CreateClientSpAsync(Client client)
        {
            try
            {
                return this._applicationContext.Database.SqlQueryRaw<Client>("").ToList().FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
