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
    public class FreelancerUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FreelancerUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FreelancerUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FreelancerUser.ToListAsync());
        }

        // GET: FreelancerUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelancerUser = await _context.FreelancerUser
                .FirstOrDefaultAsync(m => m.id == id);
            if (freelancerUser == null)
            {
                return NotFound();
            }

            return View(freelancerUser);
        }

        // GET: FreelancerUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FreelancerUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,First_Name,Last_Name,Email,Phone_Number,Expertise_Level,Education,Experience,Language,Hourly_Rate,Title,Professional_Overview,Photo,Address,Government_ID,Rate,Qualification_Status")] Models.Freelancer freelancerUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freelancerUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freelancerUser);
        }

        // GET: FreelancerUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelancerUser = await _context.FreelancerUser.FindAsync(id);
            if (freelancerUser == null)
            {
                return NotFound();
            }
            return View(freelancerUser);
        }

        // POST: FreelancerUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,First_Name,Last_Name,Email,Phone_Number,Expertise_Level,Education,Experience,Language,Hourly_Rate,Title,Professional_Overview,Photo,Address,Government_ID,Rate,Qualification_Status")] Models.Freelancer freelancerUser)
        {
            if (id != freelancerUser.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freelancerUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreelancerUserExists(freelancerUser.id))
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
            return View(freelancerUser);
        }

        // GET: FreelancerUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelancerUser = await _context.FreelancerUser
                .FirstOrDefaultAsync(m => m.id == id);
            if (freelancerUser == null)
            {
                return NotFound();
            }

            return View(freelancerUser);
        }

        // POST: FreelancerUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freelancerUser = await _context.FreelancerUser.FindAsync(id);
            _context.FreelancerUser.Remove(freelancerUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreelancerUserExists(int id)
        {
            return _context.FreelancerUser.Any(e => e.id == id);
        }
    }
}
