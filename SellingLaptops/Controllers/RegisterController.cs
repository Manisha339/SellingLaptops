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
    public class RegisterController : Controller
    {
        private readonly DataLayer.AppContext _context;

        public RegisterController(DataLayer.AppContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegisterModel.ToListAsync());
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerModel = await _context.RegisterModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (registerModel == null)
            {
                return NotFound();
            }

            return View(registerModel);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Password,ConfirmPassword,Address,Phone")] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerModel = await _context.RegisterModel.FindAsync(id);
            if (registerModel == null)
            {
                return NotFound();
            }
            return View(registerModel);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Email,Password,ConfirmPassword,Address,Phone")] RegisterModel registerModel)
        {
            if (id != registerModel.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterModelExists(registerModel.Name))
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
            return View(registerModel);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerModel = await _context.RegisterModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (registerModel == null)
            {
                return NotFound();
            }

            return View(registerModel);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var registerModel = await _context.RegisterModel.FindAsync(id);
            _context.RegisterModel.Remove(registerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterModelExists(string id)
        {
            return _context.RegisterModel.Any(e => e.Name == id);
        }
    }
}
