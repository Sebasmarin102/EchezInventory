using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EchezInventory.Data;
using EchezInventory.Data.Entities;

namespace EchezInventory.Controllers
{
    public class UserEmailAndPasswordsController : Controller
    {
        private readonly DataContext _context;

        public UserEmailAndPasswordsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.UserEmailAndPasswords != null ? 
                          View(await _context.UserEmailAndPasswords.ToListAsync()) :
                          Problem("Entity set 'DataContext.UserEmailAndPasswords'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserEmailAndPasswords == null)
            {
                return NotFound();
            }

            var userEmailAndPassword = await _context.UserEmailAndPasswords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEmailAndPassword == null)
            {
                return NotFound();
            }

            return View(userEmailAndPassword);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Email,Password,ExtensionNumber,ExtensionPassword,Location")] UserEmailAndPassword userEmailAndPassword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEmailAndPassword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userEmailAndPassword);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserEmailAndPasswords == null)
            {
                return NotFound();
            }

            var userEmailAndPassword = await _context.UserEmailAndPasswords.FindAsync(id);
            if (userEmailAndPassword == null)
            {
                return NotFound();
            }
            return View(userEmailAndPassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Email,Password,ExtensionNumber,ExtensionPassword,Location")] UserEmailAndPassword userEmailAndPassword)
        {
            if (id != userEmailAndPassword.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEmailAndPassword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEmailAndPasswordExists(userEmailAndPassword.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userEmailAndPassword);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserEmailAndPasswords == null)
            {
                return NotFound();
            }

            var userEmailAndPassword = await _context.UserEmailAndPasswords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEmailAndPassword == null)
            {
                return NotFound();
            }

            return View(userEmailAndPassword);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserEmailAndPasswords == null)
            {
                return Problem("Entity set 'DataContext.UserEmailAndPasswords'  is null.");
            }
            var userEmailAndPassword = await _context.UserEmailAndPasswords.FindAsync(id);
            if (userEmailAndPassword != null)
            {
                _context.UserEmailAndPasswords.Remove(userEmailAndPassword);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEmailAndPasswordExists(int id)
        {
          return (_context.UserEmailAndPasswords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
