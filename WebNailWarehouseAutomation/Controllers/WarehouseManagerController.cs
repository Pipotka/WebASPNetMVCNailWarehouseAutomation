using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebNailWarehouseAutomation.Models;
using WebNailWarehouseAutomation.Models.ClassEnums;
using WebNailWarehouseAutomation.Helpers;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebNailWarehouseAutomation.Controllers
{
    public class WarehouseManagerController : Controller
    {
        public IActionResult Index() //Add Nails page
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(Nail nail)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View("Index");
        }
    }
}
