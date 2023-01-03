using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalAssetsMVC.Data;
using FinalAssetsMVC1.Models;

namespace FinalAssetsMVC.Controllers
{
    public class AssetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assets sorted by purchase Date
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Asset.Include(a => a.Item).Include(a => a.Office);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assets sorted by purchase Date Descending
        public async Task<IActionResult> Index_desc()
        {
            var applicationDbContext = _context.Asset.Include(a => a.Item).Include(a => a.Office);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assets sorted by Office
        public async Task<IActionResult> Index_sortedByOffice()
        {
            var applicationDbContext = _context.Asset.Include(a => a.Item).Include(a => a.Office);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assets sorted by Office Descending
        public async Task<IActionResult> Index_sortedByOfficeDesc()
        {
            var applicationDbContext = _context.Asset.Include(a => a.Item).Include(a => a.Office);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asset == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.Item)
                .Include(a => a.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Model");
            ViewData["OfficeId"] = new SelectList(_context.Set<Office>(), "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PurchaseDate,ItemId,OfficeId")] Asset asset)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", asset.ItemId);
            //ViewData["OfficeId"] = new SelectList(_context.Set<Office>(), "Id", "Id", asset.OfficeId);
            //return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asset == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Model", asset.ItemId);
            ViewData["OfficeId"] = new SelectList(_context.Set<Office>(), "Id", "Name", asset.OfficeId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PurchaseDate,ItemId,OfficeId")] Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(asset);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!AssetExists(asset.Id))
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
            //ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Model", asset.ItemId);
            //ViewData["OfficeId"] = new SelectList(_context.Set<Office>(), "Id", "Name", asset.OfficeId);
            //return View(asset);

            _context.Update(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asset == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.Item)
                .Include(a => a.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asset == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Asset'  is null.");
            }
            var asset = await _context.Asset.FindAsync(id);
            if (asset != null)
            {
                _context.Asset.Remove(asset);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(int id)
        {
          return _context.Asset.Any(e => e.Id == id);
        }
    }
}
