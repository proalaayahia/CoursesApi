using AutoMapper;
using CoursesApi.Application.Common.Interfaces;
using CoursesApi.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Application.Common.Concrete;

public class Repository<TSource, TDestination> : IRepository<TSource, TDestination> where TSource :class where TDestination:class
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public Repository(IApplicationDbContext context,IMapper mapper)
    {
        _context=context;
        _mapper=mapper;
    }
    public async Task AddAsync(TDestination destination)
    {
        var source=_mapper.Map<TSource>(destination);
        await _context.Set<TSource>().AddAsync(source);
    }

    public async Task<IEnumerable<TDestination>> GetAllAsync()
    {
        var data=await _context.Set<TSource>().ToListAsync();
        var destination=_mapper.Map<IEnumerable<TDestination>>(data);
        return destination;
    }

    public async Task<TDestination> GetByIdAsync(int id)
    {
        var data=await _context.Set<TSource>().FindAsync(id);
        var destination=_mapper.Map<TDestination>(data);
        return destination;
    }

    public async Task RemoveAsync(int id)
    {
        var data=await _context.Set<TSource>().FindAsync(id);
         _context.Set<TSource>().Remove(data!);
    }

    public void Update(TDestination destination)
    {
        var source=_mapper.Map<TSource>(destination);
        _context.Set<TSource>().Update(source);
    }
}