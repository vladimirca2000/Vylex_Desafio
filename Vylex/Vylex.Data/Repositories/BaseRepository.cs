﻿using Microsoft.EntityFrameworkCore;
using Vylex.Data.Context;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;

namespace Vylex.Data.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly ContextBase _context;
    private DbSet<T> _dataset;

    public BaseRepository(ContextBase context)
    {
        _context = context;
        _dataset = _context.Set<T>();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (result == null)
                return false;

            _dataset.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _dataset.AnyAsync(P => P.Id.Equals(id));
    }

    public async Task<T> InsertAsync(T item)
    {
        try
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            _dataset.Add(item);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return item;
    }

    public async Task<T> SelectAsync(Guid id)
    {
        try
        {
            return await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<T>> SelectAllAsync()
    {
        try
        {
            return await _dataset.ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<T> UpdateAsync(T item)
    {
        try
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
            if (result == null)
                return null;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return item;
    }
}
