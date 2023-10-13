namespace Parking.Contracts;

public class BaseService<T>: IBaseService<T> where T : ITEntity
{
    
    public Task<T> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> ReadAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> ReadAllAsync()
    {
        throw new NotImplementedException();
    }
}