using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalAssetsMVC.Data;
using FinalAssetsMVC1.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalAssetsMVC.Controllers
{
    [Authorize]
    public class OfficesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Offices
        public async Task<IActionResult> Index()
        {
              return View(await _context.Office.ToListAsync());
        }

        // GET: Offices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Office == null)
            {
                return NotFound();
            }

            var office = await _context.Office
                .FirstOrDefaultAsync(m => m.Id == id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // GET: Offices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Currency,Rate")] Office office)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(office);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(office);
        }

        // GET: Offices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Office == null)
            {
                return NotFound();
            }

            var office = await _context.Office.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }

        // POST: Offices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Currency,Rate")] Office office)
        {
            if (id != office.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(office);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!OfficeExists(office.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            _context.Update(office);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(office);
        }

        // GET: Offices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Office == null)
            {
                return NotFound();
            }

            var office = await _context.Office
                .FirstOrDefaultAsync(m => m.Id == id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // POST: Offices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Office == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Office'  is null.");
            }
            var office = await _context.Office.FindAsync(id);
            if (office != null)
            {
                _context.Office.Remove(office);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeExists(int id)
        {
          return _context.Office.Any(e => e.Id == id);
        }
    }
}
