using Microsoft.EntityFrameworkCore;
using QueHub.DAL.Constexts;
using QueHub.DAL.IRepositories;

namespace QueHub.DAL.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly QueHubDbContext dbContext;

    private readonly DbSet<T> table;

    public Repository(QueHubDbContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public void Create(T entity)
    {
        table.Add(entity);
    }

    public void Delete(T entity)
    {
        table.Remove(entity);
    }

    public T Get(long id)
    {
        return table.Find(id);
    }

    public IQueryable<T> GetAll()
    {
        return table.AsNoTracking();
    }

    public void Update(T entity)
    {
        dbContext.Entry<T>(entity).State = EntityState.Modified;
    }

    public void SaveChanges()
    {
        dbContext.SaveChanges();
    }
}
