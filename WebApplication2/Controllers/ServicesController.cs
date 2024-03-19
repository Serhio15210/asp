using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Xml;
namespace WebApplication2.Controllers;
 

public class ServicesController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ServicesController(
        IWebHostEnvironment webHostEnvironment
    )
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Index()
    {
        ViewBag.ActivePage = "services";
        return View();
    }
}