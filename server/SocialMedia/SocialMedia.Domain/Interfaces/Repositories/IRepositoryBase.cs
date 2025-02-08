using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> FindByIdAsync(int id);
        Task<List<T>> FindAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
