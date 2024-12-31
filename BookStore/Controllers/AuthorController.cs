using BookStore.Models.Domain;
using BookStore.Repos.Abstract;
using BookStore.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class AuthorController : Controller
{
    private readonly IMainUnit _MainUnit;

    public AuthorController(IMainUnit mainUnit)
    {
        _MainUnit = mainUnit;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Authors = await _MainUnit.Authors.GetAllAsync();
        return View(Authors);
    }

    [HttpGet]
    public IActionResult Add()
    {
        Author model = new Author();
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(Author model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        bool result = await _MainUnit.Authors.AddAsync(model);
        if(result)
        {
            TempData["Message"] = "Successful Process";
            return RedirectToAction(nameof(GetAll));
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int Id)
    {
        Author? model = await _MainUnit.Authors.GetByIdAsync(Id);
        if(model == null)
        {
            TempData["Message"] = "author not exists.";
            return View();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Author model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        bool result = await _MainUnit.Authors.UpdateAsync(model);
        if(result)
        {
            TempData["Message"] = "Successful Process";
            return RedirectToAction(nameof(GetAll));
        }
        return View(model);
    }
    
    public async Task<IActionResult> Delete(int Id)
    {
        await _MainUnit.Authors.DeleteAsync(Id);
        return RedirectToAction(nameof(GetAll));
    }
}