using BookStore.Models.Domain;
using BookStore.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookStore.Controllers;

public class BookController : Controller
{
    private readonly IMainUnit _MainUnit;
    public BookController(IMainUnit mainUnit)
    {
        _MainUnit = mainUnit;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Books = await _MainUnit.Books.GetAllAsync();
        return View(Books);
    }

    private async Task CreateDropdownList(int GenreId, int PublisherId, int AuthorId)
    {
        var Genres = await _MainUnit.Genres.GetAllAsync();
        var Publishers = await _MainUnit.Publishers.GetAllAsync();
        var Authors = await _MainUnit.Authors.GetAllAsync();

        SelectList GenreList = new SelectList(Genres, "Id", "Name", GenreId);
        SelectList PublisherList = new SelectList(Publishers, "Id", "PublisherName", PublisherId);
        SelectList AuthorList = new SelectList(Authors, "Id", "AuthorName", AuthorId);

        ViewBag.Genres = GenreList;
        ViewBag.Publishers = PublisherList; 
        ViewBag.Authors = AuthorList;
    }


    [HttpGet]
    public async Task<IActionResult> Add()
    {
        Book model = new Book();
        await CreateDropdownList(0,0,0);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Book model)
    {
        if(!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Add));
        }
        bool result = await _MainUnit.Books.AddAsync(model);
        if(result)
        {
            TempData["msg"] = "Successful Process";
            return RedirectToAction(nameof(GetAll));
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int Id)
    {
        var model = await _MainUnit.Books.GetByIdAsync(Id);
        if(model != null)
        {
            await CreateDropdownList(model.GenreId, model.PublisherId, model.AuthorId);
            return View(model);
        }
        return RedirectToAction(nameof(GetAll));
    }

    [HttpPost]
    public async Task<IActionResult> Update(Book model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }
        bool result = await _MainUnit.Books.UpdateAsync(model);
        if(result)
        {
            TempData["msg"] = "Seccessful Process";
            return RedirectToAction(nameof(GetAll));
        }
        return View(model);
    }

    public async Task<IActionResult> Delete(int Id)
    {
        await _MainUnit.Books.DeleteAsync(Id);
        return RedirectToAction(nameof(GetAll)); 
    }
}