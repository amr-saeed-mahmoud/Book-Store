using BookStore.Models.Domain;
using BookStore.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class PublisherController : Controller
{
    private readonly IMainUnit _MainUnit;

    public PublisherController(IMainUnit mainUnit)
    {
        _MainUnit = mainUnit;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Publisher = await _MainUnit.Publishers.GetAllAsync();
        return View(Publisher);
    }

    [HttpGet]
    public IActionResult Add()
    {
        Publisher model = new Publisher();
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(Publisher model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        bool result = await _MainUnit.Publishers.AddAsync(model);
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
        Publisher? model = await _MainUnit.Publishers.GetByIdAsync(Id);
        if(model == null)
        {
            TempData["Message"] = "author not exists.";
            return View();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Publisher model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        bool result = await _MainUnit.Publishers.UpdateAsync(model);
        if(result)
        {
            TempData["Message"] = "Successful Process";
            return RedirectToAction(nameof(GetAll));
        }
        return View(model);
    }
    
    public async Task<IActionResult> Delete(int Id)
    {
        await _MainUnit.Publishers.DeleteAsync(Id);
        return RedirectToAction(nameof(GetAll));
    }
}