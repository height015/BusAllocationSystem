
namespace XGrid.Domain.Contract;

public interface IRepository<T> where T : class 
{
    Task<T> GetByIdAsync(int id);

    Task<T> InsertAsync(T entity);

    Task<IList<T>> InsertListAsync(IEnumerable<T> entities);

    Task<T> UpdateAsync(T entity);

    Task<IEnumerable<T>> FetchAsync();

    string Delete(int Id);

    IQueryable<T> Table { get; }

    IQueryable<T> TableNoTracking { get; }
}

