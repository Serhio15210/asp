using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Xml;
namespace WebApplication2.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public HomeController(
        // ILogger<HomeController> logger
            IWebHostEnvironment webHostEnvironment
        )
    {
        // _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        ViewBag.ActivePage = "home";
        var trips = new List<TripTable>();

        // Путь к папке wwwroot
        var wwwRootPath = _webHostEnvironment.WebRootPath;

        // Путь к вашему XML-файлу в папке wwwroot
        var xmlFilePath = Path.Combine(wwwRootPath, "App_Data", "home_data.xml");

        // Чтение данных из XML
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFilePath);

        // Извлечение данных из XML и добавление в список
        foreach (XmlNode node in xmlDoc.SelectNodes("/homeData/tripData/item"))
        {
            var trip = new TripTable
            {
                From = node.SelectSingleNode("from").InnerText,
                To = node.SelectSingleNode("to").InnerText,
                Amount = int.Parse(node.SelectSingleNode("amount").InnerText),
                Price = int.Parse(node.SelectSingleNode("price").InnerText)
            };

            trips.Add(trip);
        }

        return View(trips);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    
}