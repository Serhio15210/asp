using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class ContactsController: Controller
{
    public IActionResult Index()
    {
        ViewBag.ActivePage = "contacts";
        return View();
    }

    [HttpPost]
    public IActionResult Check(Contact contact)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success", contact);
        }
        return View("Index");
    }
    public IActionResult Success(Contact contact)
    {
        ViewData["Name"] = contact.Name;
        ViewData["Email"] = contact.Email;
        return View("Success");
    }
}