using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogTrackerProject.Models;

namespace BlogTrackerProject.Controllers
{
    public class EmployeeinfoController : Controller
    {
        private readonly CapstoneDbContext _context;

        public EmployeeinfoController(CapstoneDbContext context)
        {
            _context = context;
        }

        // GET: Employeeinfo
        public async Task<IActionResult> Index()
        {
              return _context.Employeeinfos != null ? 
                          View(await _context.Employeeinfos.ToListAsync()) :
                          Problem("Entity set 'CapstoneDbContext.Employeeinfos'  is null.");
        }

        // GET: Employeeinfo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Employeeinfos == null)
            {
                return NotFound();
            }

            var employeeinfo = await _context.Employeeinfos
                .FirstOrDefaultAsync(m => m.Emailid == id);
            if (employeeinfo == null)
            {
                return NotFound();
            }

            return View(employeeinfo);
        }

        // GET: Employeeinfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employeeinfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Emailid,Name,Doj,Passcode")] Employeeinfo employeeinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeinfo);
        }

        // GET: Employeeinfo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Employeeinfos == null)
            {
                return NotFound();
            }

            var employeeinfo = await _context.Employeeinfos.FindAsync(id);
            if (employeeinfo == null)
            {
                return NotFound();
            }
            return View(employeeinfo);
        }

        // POST: Employeeinfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Emailid,Name,Doj,Passcode")] Employeeinfo employeeinfo)
        {
            if (id != employeeinfo.Emailid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeinfoExists(employeeinfo.Emailid))
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
            return View(employeeinfo);
        }

        // GET: Employeeinfo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Employeeinfos == null)
            {
                return NotFound();
            }

            var employeeinfo = await _context.Employeeinfos
                .FirstOrDefaultAsync(m => m.Emailid == id);
            if (employeeinfo == null)
            {
                return NotFound();
            }

            return View(employeeinfo);
        }

        // POST: Employeeinfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Employeeinfos == null)
            {
                return Problem("Entity set 'CapstoneDbContext.Employeeinfos'  is null.");
            }
            var employeeinfo = await _context.Employeeinfos.FindAsync(id);
            if (employeeinfo != null)
            {
                _context.Employeeinfos.Remove(employeeinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeinfoExists(string id)
        {
          return (_context.Employeeinfos?.Any(e => e.Emailid == id)).GetValueOrDefault();
        }
    }
}
