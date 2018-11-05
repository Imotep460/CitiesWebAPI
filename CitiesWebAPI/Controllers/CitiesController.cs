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
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly CitiesWebAPIContext _context;

        public CitiesController(CitiesWebAPIContext context)
        {
            _context = context;
        }

        // GET: All cities
        public ActionResult<List<Cities>> GetAll()
        {
            return _context.Cities.ToList();
        }

        [HttpGet("{id}", Name = "GetCity")]
        public ActionResult<Cities> GetById(int id)
        {
            var item = _context.Cities.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        public IActionResult Create([FromBody] Cities item)
        {
            _context.Cities.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCity", new { id = item.Id }, item);
        }

        // GET: Cities/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cities = await _context.Cities.FindAsync(id);
        //    if (cities == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cities);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] City cities)
        //{
        //    if (id != cities.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cities);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CitiesExists(cities.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cities);
        //}

        //// GET: Cities/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cities = await _context.Cities
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cities == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cities);
        //}

        //// POST: Cities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cities = await _context.Cities.FindAsync(id);
        //    _context.Cities.Remove(cities);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CitiesExists(int id)
        //{
        //    return _context.Cities.Any(e => e.Id == id);
        //}
    }
}
