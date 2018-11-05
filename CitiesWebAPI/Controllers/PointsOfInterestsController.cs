using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitiesWebAPI.Models;

namespace CitiesWebAPI.Controllers
{
    public class PointsOfInterestsController : Controller
    {
        private readonly CitiesWebAPIContext _context;

        public PointsOfInterestsController(CitiesWebAPIContext context)
        {
            _context = context;
        }

        // GET: PointsOfInterests
        public async Task<IActionResult> Index()
        {
            return View(await _context.PointsOfInterest.ToListAsync());
        }

        // GET: PointsOfInterests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsOfInterest = await _context.PointsOfInterest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointsOfInterest == null)
            {
                return NotFound();
            }

            return View(pointsOfInterest);
        }

        // GET: PointsOfInterests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PointsOfInterests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PointsOfInterest pointsOfInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointsOfInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pointsOfInterest);
        }

        // GET: PointsOfInterests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsOfInterest = await _context.PointsOfInterest.FindAsync(id);
            if (pointsOfInterest == null)
            {
                return NotFound();
            }
            return View(pointsOfInterest);
        }

        // POST: PointsOfInterests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] PointsOfInterest pointsOfInterest)
        {
            if (id != pointsOfInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointsOfInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointsOfInterestExists(pointsOfInterest.Id))
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
            return View(pointsOfInterest);
        }

        // GET: PointsOfInterests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsOfInterest = await _context.PointsOfInterest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pointsOfInterest == null)
            {
                return NotFound();
            }

            return View(pointsOfInterest);
        }

        // POST: PointsOfInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pointsOfInterest = await _context.PointsOfInterest.FindAsync(id);
            _context.PointsOfInterest.Remove(pointsOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointsOfInterestExists(int id)
        {
            return _context.PointsOfInterest.Any(e => e.Id == id);
        }
    }
}
