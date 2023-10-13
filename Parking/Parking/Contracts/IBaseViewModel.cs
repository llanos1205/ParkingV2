namespace Parking.Contracts;

public interface IBaseViewModel<T> where T : ITEntity
{
    //interface for a generic viewmodel
    Task CreateAsync();
    Task ReadAsync(string id);
    Task UpdateAsync();
    Task DeleteAsync(string id);
    Task<IEnumerable<T>> ReadAllAsync();
}