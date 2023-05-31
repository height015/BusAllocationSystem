using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using XGrid.Contract;
using XGrid.Domain.Object.Data;

namespace XGrid.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _appDbContext;

    public Repository(AppDbContext requestDbContext)
    {
        _appDbContext = requestDbContext;
    }
    public IQueryable<T> Table => _appDbContext.Set<T>();

    public IQueryable<T> TableNoTracking => _appDbContext.Set<T>().AsNoTracking();

    public string Delete(int Id)
    {
        string message = string.Empty;
        try
        {
            var entity = _appDbContext.Set<T>().Find(Id);
            _appDbContext.Set<T>().Remove(entity);
            _appDbContext.SaveChanges();
        }
        catch (Exception ex)
        {

        }
        return message;

    }

    public async Task<IEnumerable<T>> FetchAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _appDbContext.Set<T>().Where(expression);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }



    public async Task<T> InsertAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IList<T>> InsertListAsync(IEnumerable<T> entities)
    {
        try
        {
            await _appDbContext.Set<T>().AddRangeAsync(entities);
            await _appDbContext.SaveChangesAsync();
            return entities.ToList();

        }
        catch (Exception)
        {
            return Enumerable.Empty<T>().ToList();
        }

    }
    public async Task<T> UpdateAsync(T entity)
    {
        try
        {
            _appDbContext.Set<T>().Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
        catch
        {
            throw;
        }
    }

}

