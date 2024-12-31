
using BookStore.Models;
using BookStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repos.Implemention;

public class BookService : GenricRepo<Book>
{
    private readonly AppDbContext _db;
    public BookService(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public async override Task<IEnumerable<Book>> GetAllAsync()
    {
       IEnumerable<Book> Books = await _db.Books
        .Include(b => b.Author)
        .Include(b => b.Publisher)
        .Include(b => b.Genre)
        .ToListAsync();

        return Books;
    }
}