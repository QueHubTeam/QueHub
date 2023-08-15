﻿using System.Linq.Expressions;

namespace QueHub.DAL.IRepositories;

public interface IRepository<T> where T : class
{
    ValueTask<T> AddAsync(T entity);

    ValueTask<T> UpdateAsync(T entity);

    ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression);

    ValueTask<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null);

    IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracking = true);

    ValueTask SaveAsync();
}
