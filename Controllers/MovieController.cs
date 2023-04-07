using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Clase4.Models;
using Clase4.Services;

namespace Clase4.Controllers;

public class MovieController : Controller
{
    

    public MovieController()
    {
       
    }

    public IActionResult Index()
    {
        var model = new List<Movie>();
        model = MovieService.GetAll();
        return View(model);
    }

    public IActionResult Detail(string code)
    {
        var model = MovieService.Get(code); //llama al servicio get
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie){
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        MovieService.Add(movie);

        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(string code){
        MovieService.Delete(code);
        
        return RedirectToAction("Index");
    }
}