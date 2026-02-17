using Microsoft.AspNetCore.Mvc;
using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using BugTrackingSystem.Filters;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem.Controllers
{
    [SessionAuthFilter]
    public class BugController : Controller
    {
        private readonly AppDbContext _context;

        public BugController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Bug/Index
        public async Task<IActionResult> Index()
        {
            var bugs = await _context.Bugs.OrderByDescending(b => b.CreatedDate).ToListAsync();
            return View(bugs);
        }

        // GET: Bug/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bug/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bug bug)
        {
            if (ModelState.IsValid)
            {
                bug.CreatedDate = DateTime.Now;
                bug.Status = "Open";
                _context.Bugs.Add(bug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bug);
        }

        // GET: Bug/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }
            return View(bug);
        }

        // POST: Bug/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bug bug)
        {
            if (id != bug.BugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bug.UpdatedDate = DateTime.Now;
                    _context.Update(bug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugExists(bug.BugId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bug);
        }

        private bool BugExists(int id)
        {
            return _context.Bugs.Any(e => e.BugId == id);
        }
    }
}
