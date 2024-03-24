using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Services.PublisherService;

public class PublisherService : IPublisherService
{
    private readonly LibraryContext _context;

    public PublisherService(LibraryContext context)
    {
        _context = context;
    }

    public async Task<Publisher> CreatePublisherAsync(Publisher publisher)
    {
        _context.Publishers.Add(publisher);
        await _context.SaveChangesAsync();
        return publisher;
    }

    public async Task<Publisher?> GetPublisherAsync(int id)
    {
        return await _context.Publishers.FindAsync(id);
    }

    public async Task<Publisher?> GetPublisherByNameAsync(string name)
    {
        return await _context.Publishers.FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<Publisher> UpdatePublisherAsync(Publisher publisher)
    {
        _context.Entry(publisher).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return publisher;
    }

    public async Task DeletePublisherAsync(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher != null)
        {
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
    }
}