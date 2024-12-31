using BookStore.Models.Domain;
using BookStore.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class GenreController : Controller
{
    private readonly IMainUnit _MainUnit;
    public GenreController(IMainUnit unit)
    {
        _MainUnit = unit;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Genres = await _MainUnit.Genres.GetAllAsync();
        return View(Genres);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Genre model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }
        bool result = await _MainUnit.Genres.AddAsync(model);
        if(result)
        {
            TempData["Message"] = "Seccessful Process";
            return RedirectToAction(nameof(GetAll));
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int Id)
    {
        var model = await _MainUnit.Genres.GetByIdAsync(Id);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Genre model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }
        bool result = await _MainUnit.Genres.UpdateAsync(model);
        if(result)
        {
            TempData["Message"] = "Seccessful Process";
            return RedirectToAction(nameof(GetAll));
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int Id)
    {
        await _MainUnit.Genres.DeleteAsync(Id);
        return RedirectToAction("GetAll");
    }
}