using Domain.DTO;
using Domain.Repositories;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Database;

namespace Repository.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<Client?> GetByIdAsync(int code)
            => await _table.Include(x => x.Addresses).Include(x => x.Phones).FirstOrDefaultAsync(x => x.ClientId == code);
        public async Task<Client?> GetByDocumentAndDocumentTypeAsync(long document, string documentType)
            => await _table.Include(x => x.Addresses).Include(x => x.Phones)
            .FirstOrDefaultAsync(x => x.Document == document && x.DocumentType == documentType);

        public async Task<IEnumerable<FilterAddressClientResponse>> GetAddressAndFullNameClientAsync()
        {
            try
            {
                return _applicationContext.Database.SqlQueryRaw<FilterAddressClientResponse>("EXEC [dbo].[SP_GetAddressClient]").AsEnumerable();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error al llamar el procedimiento almacenado.");
            }
        }

    }
}
