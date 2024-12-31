using BookStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public required DbSet<Author> Authors { get; set; }
    public required DbSet<Book> Books { get; set; }
    public required DbSet<Genre> Genres { get; set; }
    public required DbSet<Publisher> Publishers { get; set; }
}