using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BarbeariaMVC.Models;

namespace BarbeariaMVC.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

  
}
