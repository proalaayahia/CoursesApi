namespace CoursesApi.Application.Common.Interfaces;

public interface IRepository<TSource,TDestination> where TDestination : class where TSource : class
{
    Task AddAsync(TDestination source);
    void Update(TDestination source);
    Task<TDestination> GetByIdAsync(int id);
    Task<IEnumerable<TDestination>> GetAllAsync();
    Task RemoveAsync(int id);
}
