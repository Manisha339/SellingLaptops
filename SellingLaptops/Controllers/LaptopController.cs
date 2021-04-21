using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using Models;

namespace SellingLaptops.Controllers
{
    public class LaptopController : Controller
    {
        private readonly DataLayer.AppContext _context;

        public LaptopController(DataLayer.AppContext context)
        {
            _context = context;
        }

        // GET: Laptop
        public async Task<IActionResult> Index()
        {
            return View("_Index",await _context.LaptopModel.ToListAsync());
        }

        // GET: Laptop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopModel = await _context.LaptopModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laptopModel == null)
            {
                return NotFound();
            }

            return View(laptopModel);
        }

        // GET: Laptop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductName,ImgUrl,Price,Description")] LaptopModel laptopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laptopModel);
        }

        // GET: Laptop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopModel = await _context.LaptopModel.FindAsync(id);
            if (laptopModel == null)
            {
                return NotFound();
            }
            return View(laptopModel);
        }

        // POST: Laptop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductName,ImgUrl,Price,Description")] LaptopModel laptopModel)
        {
            if (id != laptopModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopModelExists(laptopModel.ID))
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
            return View(laptopModel);
        }

        // GET: Laptop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptopModel = await _context.LaptopModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laptopModel == null)
            {
                return NotFound();
            }

            return View(laptopModel);
        }

        // POST: Laptop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptopModel = await _context.LaptopModel.FindAsync(id);
            _context.LaptopModel.Remove(laptopModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopModelExists(int id)
        {
            return _context.LaptopModel.Any(e => e.ID == id);
        }
    }
}
