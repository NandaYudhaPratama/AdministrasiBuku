using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdministrasiBuku.Models;

namespace AdministrasiBuku.Controllers
{
    public class BukusController : Controller
    {
        private readonly DbAdmBukuContext _context;

        public BukusController(DbAdmBukuContext context)
        {
            _context = context;
        }

        // GET: Bukus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Buku.ToListAsync());
        }

        // GET: Bukus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Buku
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (buku == null)
            {
                return NotFound();
            }

            return View(buku);
        }

        // GET: Bukus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bukus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Isbn,JudulBuku,Pengarang,Penerbit,TahunTerbit,Jumlah")] Buku buku)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buku);
        }

        // GET: Bukus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Buku.FindAsync(id);
            if (buku == null)
            {
                return NotFound();
            }
            return View(buku);
        }

        // POST: Bukus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Isbn,JudulBuku,Pengarang,Penerbit,TahunTerbit,Jumlah")] Buku buku)
        {
            if (id != buku.Isbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BukuExists(buku.Isbn))
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
            return View(buku);
        }

        // GET: Bukus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Buku
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (buku == null)
            {
                return NotFound();
            }

            return View(buku);
        }

        // POST: Bukus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var buku = await _context.Buku.FindAsync(id);
            _context.Buku.Remove(buku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BukuExists(string id)
        {
            return _context.Buku.Any(e => e.Isbn == id);
        }
    }
}
