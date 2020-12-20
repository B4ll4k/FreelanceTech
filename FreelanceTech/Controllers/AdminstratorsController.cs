using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreelanceTech.Data;
using FreelanceTech.Models;

namespace FreelanceTech.Controllers
{
    public class AdminstratorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminstratorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adminstrators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adminstrator.ToListAsync());
        }

        // GET: Adminstrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminstrator = await _context.Adminstrator
                .FirstOrDefaultAsync(m => m.id == id);
            if (adminstrator == null)
            {
                return NotFound();
            }

            return View(adminstrator);
        }

        // GET: Adminstrators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adminstrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,First_Name,Last_Name,Email,Phone_Number")] Adminstrator adminstrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminstrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminstrator);
        }

        // GET: Adminstrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminstrator = await _context.Adminstrator.FindAsync(id);
            if (adminstrator == null)
            {
                return NotFound();
            }
            return View(adminstrator);
        }

        // POST: Adminstrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,First_Name,Last_Name,Email,Phone_Number")] Adminstrator adminstrator)
        {
            if (id != adminstrator.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminstrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminstratorExists(adminstrator.id))
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
            return View(adminstrator);
        }

        // GET: Adminstrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminstrator = await _context.Adminstrator
                .FirstOrDefaultAsync(m => m.id == id);
            if (adminstrator == null)
            {
                return NotFound();
            }

            return View(adminstrator);
        }

        // POST: Adminstrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminstrator = await _context.Adminstrator.FindAsync(id);
            _context.Adminstrator.Remove(adminstrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminstratorExists(int id)
        {
            return _context.Adminstrator.Any(e => e.id == id);
        }
    }
}
