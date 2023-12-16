using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Common;
using MusicApp.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Persistence.Implementations.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<T> CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity == null) throw new Application.Exceptions.NotFoundException(nameof(T), id);
        
        _dbContext.Set<T>().Remove(entity);
    }

    //public async Task<T> UpdateAsync(Guid id, T entity)
    //{
    //    var existingEntity = await _dbContext.Set<T>().FindAsync(id);

    //    if (existingEntity == null)
    //    {
    //        throw new Application.Exceptions.NotFoundException(nameof(T), id);
    //    }

    //    _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

    //    _dbContext.Entry(existingEntity).State = EntityState.Modified;

    //    return existingEntity;
    //}

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        var existingEntity = await _dbContext.Set<T>().FindAsync(id);

        if (existingEntity == null)
        {
            throw new Application.Exceptions.NotFoundException(nameof(T), id);
        }

        _dbContext.Attach(entity);

        _dbContext.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.AsNoTracking().ToListAsync();
    }
    public async Task<T> GetByIdWithIncludesAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}
