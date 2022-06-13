using EchezInventory.Data;
using EchezInventory.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EchezInventory.Controllers
{
    public class CorporateEmailsController : Controller 
    {
        private readonly DataContext _context;

        public CorporateEmailsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CorporateEmails.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CorporateEmail corporateEmail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corporateEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(corporateEmail);
        }
    }
}
