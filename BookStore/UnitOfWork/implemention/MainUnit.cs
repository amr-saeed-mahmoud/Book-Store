
using BookStore.Models;
using BookStore.Models.Domain;
using BookStore.Repos.Abstract;
using BookStore.Repos.Implemention;
using BookStore.UnitOfWork.Abstract;

namespace BookStore.UnitOfWork.Implemention;

public class MainUnit : IMainUnit
{

    private readonly AppDbContext _db;

    public MainUnit(AppDbContext db)
    {
        _db = db;
        Authors = new GenricRepo<Author>(_db);
        Books = new BookService(_db);
        Genres = new GenricRepo<Genre>(_db);
        Publishers = new GenricRepo<Publisher>(_db);
    }

    public IGenricRepo<Author> Authors {get; private set;}

    public BookService Books {get; private set;}

    public IGenricRepo<Genre> Genres {get; private set;}

    public IGenricRepo<Publisher> Publishers {get; private set;}

    public void Dispose()
    {
        _db.Dispose();
    }
}