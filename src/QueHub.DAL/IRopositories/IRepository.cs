namespace QueHub.DAL.IRepositories;

public interface IRepository<T> where T : class
{
    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);

    T Get(long id);

    IQueryable<T> GetAll();

    void SaveChanges();
}
