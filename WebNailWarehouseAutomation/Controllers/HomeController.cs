using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Diagnostics;
using WebNailWarehouseAutomation.Models;

namespace WebNailWarehouseAutomation.Controllers
{
    public class HomeController : Controller
    {
        NailContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, NailContext context)
        {
            db = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Log.Information("The warehouse browser is open");
            return View(await db.Nails.ToListAsync());
        }
        
        public IActionResult Create()
        {
            Log.Information("Start adding a {Type} object.", nameof(Nail));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Nail nail)
        {
            if (ModelState.IsValid)
            {
                db.Nails.Add(nail);
                await db.SaveChangesAsync();
                Log.Information("Ending the addition of an object. It has {@Nail}", nail);
                return RedirectToAction("Index");
            }
            Log.Information("Failed to create an object. It has {@Nail}", nail);
            return View("Create", nail);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            Log.Information("start of deleting object with id = {@Id}", id);
            if (id is not null)
            {
                Nail nail = new Nail { id = id.Value };
                db.Entry(nail).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                Log.Information("object {@Nail} successfully deleted", nail);
                return RedirectToAction("Index");
            }
            Log.Error("Error deleting an object with id = {@Id}", id);
            return NotFound();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            Log.Information("start of changing object with id = {@Id}", id);
            if (id is not null)
            {
                Nail? nail = await
                    db.Nails.FirstOrDefaultAsync(p=>p.id == id);
                if (nail is not null)
                {
                    return View("Edit", nail);
                }
            }
            Log.Error("Error changing an object with id = {@Id}", id);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Nail nail)
        {
            db.Nails.Update(nail);
            await db.SaveChangesAsync();
            Log.Information("End of changing of object. It now has {@Nail}", nail);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
