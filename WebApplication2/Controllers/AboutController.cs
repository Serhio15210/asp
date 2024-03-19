using System.Xml;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Diagnostics;
namespace WebApplication2.Controllers;



public class AboutController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AboutController(
        IWebHostEnvironment webHostEnvironment
    )
    {
        _webHostEnvironment = webHostEnvironment;
    }
    [HttpGet]
    public IActionResult Index(string selectedTrip)
    {
        ViewBag.ActivePage = "about";
        var wwwRootPath = _webHostEnvironment.WebRootPath;
        var xmlFilePath = Path.Combine(wwwRootPath, "App_Data", "about.xml");
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFilePath);
        
        var trips = new List<AboutTrip>();
        
        foreach (XmlNode node in xmlDoc.SelectNodes("/aboutTrips/item"))
        {
            var trip = new AboutTrip
            {
                Name = node.SelectSingleNode("name").InnerText,
                Text = node.SelectSingleNode("text").InnerText,
                Image = node.SelectSingleNode("image").InnerText,
            };
        
            trips.Add(trip);
        }

        return View(trips);
    }
    [HttpGet]
    public IActionResult GetSelectedTrip(string selectedTrip)
    {
        
        var wwwRootPath = _webHostEnvironment.WebRootPath;
        var xmlFilePath = Path.Combine(wwwRootPath, "App_Data", "about.xml");
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFilePath);
         
            var selectedTripElement = xmlDoc.DocumentElement
                .SelectSingleNode($"/aboutTrips/item[name='{selectedTrip}']");

            if (selectedTripElement != null)
            {
                var selectedTripModel = new AboutTrip
                {
                    Name = selectedTripElement.SelectSingleNode("name").InnerText,
                    Text = selectedTripElement.SelectSingleNode("text").InnerText,
                    Image = selectedTripElement.SelectSingleNode("image").InnerText
                };

                // Виведення у відладковій консолі (опційно)
                Debug.WriteLine($"Selected Trip: {selectedTripModel.Name}");

                return PartialView("_SelectedTripDetailsPartial", selectedTripModel);
            }
            
        return PartialView("_SelectedTripDetailsPartial", null);
    }
}

