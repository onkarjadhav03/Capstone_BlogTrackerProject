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
    public class BloginfoController : Controller
    {
        private readonly CapstoneDbContext _context;

        public BloginfoController(CapstoneDbContext context)
        {
            _context = context;
        }

        // GET: Bloginfo
        public async Task<IActionResult> Index()
        {
            var capstoneDbContext = _context.Bloginfos.Include(b => b.EmpemailNavigation);
            return View(await capstoneDbContext.ToListAsync());
        }
        public async Task<IActionResult> HomeDisplay()
        {
            var capstoneDbContext = _context.Bloginfos.Include(b => b.EmpemailNavigation);
            return View(await capstoneDbContext.ToListAsync());
        }

        // GET: Bloginfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bloginfos == null)
            {
                return NotFound();
            }

            var bloginfo = await _context.Bloginfos
                .Include(b => b.EmpemailNavigation)
                .FirstOrDefaultAsync(m => m.Blogid == id);
            if (bloginfo == null)
            {
                return NotFound();
            }

            return View(bloginfo);
        }

        // GET: Bloginfo/Create
        public IActionResult Create()
        {
            ViewData["Empemail"] = new SelectList(_context.Employeeinfos, "Emailid", "Emailid");
            return View();
        }

        // POST: Bloginfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Blogid,Title,Subject,DateOfCreation,Blogurl,Empemail")] Bloginfo bloginfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloginfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Empemail"] = new SelectList(_context.Employeeinfos, "Emailid", "Emailid", bloginfo.Empemail);
            return View(bloginfo);
        }

        // GET: Bloginfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bloginfos == null)
            {
                return NotFound();
            }

            var bloginfo = await _context.Bloginfos.FindAsync(id);
            if (bloginfo == null)
            {
                return NotFound();
            }
            ViewData["Empemail"] = new SelectList(_context.Employeeinfos, "Emailid", "Emailid", bloginfo.Empemail);
            return View(bloginfo);
        }

        // POST: Bloginfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Blogid,Title,Subject,DateOfCreation,Blogurl,Empemail")] Bloginfo bloginfo)
        {
            if (id != bloginfo.Blogid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloginfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloginfoExists(bloginfo.Blogid))
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
            ViewData["Empemail"] = new SelectList(_context.Employeeinfos, "Emailid", "Emailid", bloginfo.Empemail);
            return View(bloginfo);
        }

        // GET: Bloginfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bloginfos == null)
            {
                return NotFound();
            }

            var bloginfo = await _context.Bloginfos
                .Include(b => b.EmpemailNavigation)
                .FirstOrDefaultAsync(m => m.Blogid == id);
            if (bloginfo == null)
            {
                return NotFound();
            }

            return View(bloginfo);
        }

        // POST: Bloginfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bloginfos == null)
            {
                return Problem("Entity set 'CapstoneDbContext.Bloginfos'  is null.");
            }
            var bloginfo = await _context.Bloginfos.FindAsync(id);
            if (bloginfo != null)
            {
                _context.Bloginfos.Remove(bloginfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloginfoExists(int id)
        {
          return (_context.Bloginfos?.Any(e => e.Blogid == id)).GetValueOrDefault();
        }
    }
}
