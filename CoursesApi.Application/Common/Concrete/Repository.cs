using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Application.Common.Concrete;

public class Repository<TSource> : IRepository<TSource> where TSource :class
{
    private readonly IApplicationDbContext _context;
    public Repository(IApplicationDbContext context)
    {
        _context=context;
    }
    public async Task AddAsync(TSource source)
    {
        await _context.Set<TSource>().AddAsync(source);
    }

    public async Task<IEnumerable<TSource>> GetAllAsync()
    {
        var data=await _context.Set<TSource>().ToListAsync();
        return data;
    }

    public async Task<TSource> GetByIdAsync(int id)
    {
        var data=await _context.Set<TSource>().FindAsync(id);
        return  data!;
    }

    public async Task RemoveAsync(int id)
    {
        var entity = await GetByIdAsync(id);
         _context.Set<TSource>().Remove(entity!);
    }

    public void Update(TSource source)
    {
        _context.Set<TSource>().Update(source);
    }
}