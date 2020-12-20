using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreelanceTech.Data;
using FreelanceTech.Models;
using FreelanceTech.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Shared.Web.MvcExtensions;

namespace FreelanceTech.Controllers
{
    public class FreelancersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FreelancersController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Register()
        {
            return View();
        }
        // GET: Freelancers

        public async Task<IActionResult> Index()
        {
            return View(await _context.Freelancer.ToListAsync());
        }

        // GET: Freelancers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelancer = await _context.Freelancer
                .FirstOrDefaultAsync(m => m.freelancerId == id);
            if (freelancer == null)
            {
                return NotFound();
            }

            return View(freelancer);
        }

        // GET: Freelancers/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Freelancers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateFreelancerViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(viewmodel);
                Freelancer freelancer = new Freelancer();

                
                freelancer.freelancerId = this.User.GetUserId();
                freelancer.englishProficiency = (int)viewmodel.englishProficiency;
                freelancer.hourlyRate = Convert.ToDouble(viewmodel.hourlyRate);
                freelancer.photo = uniqueFileName;
                freelancer.title = viewmodel.title;
                freelancer.status = (int)Constants.status.Active;
                freelancer.phoneNumber = viewmodel.phoneNumber;
                freelancer.professionalOverview = viewmodel.professionalOverview;

                Language lang = new Language();
                lang.userId = this.User.GetUserId();
                lang.language = (int)viewmodel.language;

                Address address = new Address();
                address.region = viewmodel.region;
                address.city = viewmodel.city;
                address.woreda = viewmodel.woreda;
                address.houseNumber = Convert.ToInt32(viewmodel.houseNumber.ToString());
                address.pobox = Convert.ToInt32(viewmodel.pobox.ToString());
                address.userId = this.User.GetUserId();

                Expertise expertise = new Expertise();
                expertise.skill = (int)viewmodel.skill;
                expertise.category = (int)viewmodel.category;

                Experience experience = new Experience();
                experience.companyName = viewmodel.companyName;
                experience.title = viewmodel.expTitle;
                experience.description = viewmodel.description;
                experience.freelancerId = this.User.GetUserId();
                experience.location = viewmodel.location;
                experience.startDate = viewmodel.startDate;
                experience.endDate = viewmodel.endDate;


               _context.Add(freelancer);
                await _context.SaveChangesAsync();

               _context.Add(address);
                await _context.SaveChangesAsync();

                _context.Add(expertise);
                await _context.SaveChangesAsync();

                _context.Add(experience);
                await _context.SaveChangesAsync();

                _context.Add(lang);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        private string ProcessUploadedFile(CreateFreelancerViewModel model)
        {
            string uniqueFileName = null;
            if (model.photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        // GET: Freelancers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelancer = await _context.Freelancer.FindAsync(id);
            if (freelancer == null)
            {
                return NotFound();
            }
            return View(freelancer);
        }

        // POST: Freelancers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("freelancerId,phoneNumber,education,id,englishProficiency,hourlyRate,title,professionalOverview,photo,legaID,rate,score,status")] Freelancer freelancer)
        {
            if (id != freelancer.freelancerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freelancer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreelancerExists(freelancer.freelancerId))
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
            return View(freelancer);
        }

        // GET: Freelancers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freelancer = await _context.Freelancer
                .FirstOrDefaultAsync(m => m.freelancerId == id);
            if (freelancer == null)
            {
                return NotFound();
            }

            return View(freelancer);
        }

        // POST: Freelancers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var freelancer = await _context.Freelancer.FindAsync(id);
            _context.Freelancer.Remove(freelancer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreelancerExists(string id)
        {
            return _context.Freelancer.Any(e => e.freelancerId == id);
        }
    }
}
