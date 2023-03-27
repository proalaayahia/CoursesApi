namespace CoursesApi.Application.Common.Interfaces;

public interface IRepository<TSource> where TSource : class
{
    Task AddAsync(TSource source);
    void Update(TSource source);
    Task<TSource> GetByIdAsync(int id);
    Task<IEnumerable<TSource>> GetAllAsync();
    Task RemoveAsync(int id);
}
