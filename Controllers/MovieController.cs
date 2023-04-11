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

    public IActionResult Edit(string code){
        var model = MovieService.Get(code);
        return View(model);
    }

    [HttpPost]
    //cambie Edit por Index
    public IActionResult Index(string code){ //aca deberia llamar al servicio de Editar usando el modelo Movie... el MovieService Edit ponele
      // var movieToEdit = MovieService.Get(code);
      //  MovieService.Edit(movieToEdit);
      
        if (!ModelState.IsValid)
        {
           return View("Edit");
        }
        else{
        //var movieToEdit = MovieService.Get(code);
        MovieService.Edit(code);
        return RedirectToAction("Index");
        }
    }

    public IActionResult Delete(string code){
        MovieService.Delete(code);
        
        return RedirectToAction("Index");
    }
}