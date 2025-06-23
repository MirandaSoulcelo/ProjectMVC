using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ProjectMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;



    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index2()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    
}
