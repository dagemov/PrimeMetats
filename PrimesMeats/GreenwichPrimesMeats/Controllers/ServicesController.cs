using GreenwichPrimesMeats.Data;
using GreenwichPrimesMeats.Data.Entities;
using GreenwichPrimesMeats.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenwichPrimesMeats.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataContext _context;

        public ServicesController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> RegisterService()
        {
            Service service = new()
            {
                ServiceUsers = new List<ServiceUser>(),
                DateTimeCreation = DateTime.Now,
                Type = ServiceStatus.Peding,

            };
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterService(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "This Services is Alreday exist");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return View(service);
        }
    }
}
