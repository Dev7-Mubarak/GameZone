using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameZone.Data;
using GameZone.Models;

namespace GameZone.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class RestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Owner/Rests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rests.Include(r => r.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Owner/Rests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rests == null)
            {
                return NotFound();
            }

            var rest = await _context.Rests
                .Include(r => r.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rest == null)
            {
                return NotFound();
            }

            return View(rest);
        }

        // GET: Owner/Rests/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Owner/Rests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Dscraption,Image,Addrees,OwnerId")] Rest rest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id", rest.OwnerId);
            return View(rest);
        }

        // GET: Owner/Rests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rests == null)
            {
                return NotFound();
            }

            var rest = await _context.Rests.FindAsync(id);
            if (rest == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id", rest.OwnerId);
            return View(rest);
        }

        // POST: Owner/Rests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Dscraption,Image,Addrees,OwnerId")] Rest rest)
        {
            if (id != rest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestExists(rest.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id", rest.OwnerId);
            return View(rest);
        }

        // GET: Owner/Rests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rests == null)
            {
                return NotFound();
            }

            var rest = await _context.Rests
                .Include(r => r.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rest == null)
            {
                return NotFound();
            }

            return View(rest);
        }

        // POST: Owner/Rests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rests'  is null.");
            }
            var rest = await _context.Rests.FindAsync(id);
            if (rest != null)
            {
                _context.Rests.Remove(rest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestExists(int id)
        {
          return (_context.Rests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
