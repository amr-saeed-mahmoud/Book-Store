using BookStore.Models.Domain;
using BookStore.Repos.Abstract;
using BookStore.Repos.Implemention;

namespace BookStore.UnitOfWork.Abstract;


public interface IMainUnit : IDisposable
{
    IGenricRepo<Author> Authors {get;}
    BookService Books {get;}
    IGenricRepo<Genre> Genres {get;}
    IGenricRepo<Publisher> Publishers {get;}

}

