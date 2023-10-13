namespace Parking.Contracts;

public interface IBaseService<T> where T : ITEntity
{
    Task<T> CreateAsync(T entity);
    Task<T> ReadAsync(string id);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string id);
    Task<IEnumerable<T>> ReadAllAsync();
}