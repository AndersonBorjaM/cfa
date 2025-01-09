using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface IBaseRepository <EntityDTO> where EntityDTO : class
    {
        Task<EntityDTO> CreateAsync(EntityDTO entity);
        Task<EntityDTO> UpdateAsync(EntityDTO entity);
        Task<bool> DeleteAsync(EntityDTO entity);
        Task<IQueryable<EntityDTO>> GetAllAsync();
    }
}
