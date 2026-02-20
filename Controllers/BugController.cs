using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTrackingSystem.Data;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Controllers
{
    public class BugController : Controller
    {
        private readonly AppDbContext _context;

        public BugController(AppDbContext context)
        {
            _context = context;
        }

        // ---------------- LIST ----------------
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            return View(await _context.Bugs.ToListAsync());
        }

        // ---------------- CREATE ----------------
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bug bug)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                bug.CreatedDate = DateTime.Now;
                _context.Add(bug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bug);
        }

        // ---------------- EDIT ----------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Index");

            if (id == null) return NotFound();

            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null) return NotFound();

            return View(bug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bug bug)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Index");

            if (id != bug.BugId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(bug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bug);
        }
    }
}
