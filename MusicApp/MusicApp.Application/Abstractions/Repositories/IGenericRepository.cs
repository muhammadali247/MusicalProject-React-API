using MusicApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);

    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<T> GetByIdWithIncludesAsync(Guid id, params Expression<Func<T, object>>[] includes);
}
