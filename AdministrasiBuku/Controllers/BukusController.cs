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
    /// <summary>
    /// controller buku
    /// </summary>
    public class BukusController : Controller
    {
        private readonly DbAdmBukuContext _context;

        /// <summary>
        /// context yang akan di tampilkan pada laman web
        /// </summary>
        /// <param name="context">yg nantinya di panggil setelah menampilkan layout di .cshtml</param>
        public BukusController(DbAdmBukuContext context)
        {
            _context = context;
        }

        /// <summary>
        /// mendapatkan data buku
        /// </summary>
        /// <returns>menampilkan data buku sesuai database</returns>
        // GET: Bukus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Buku.ToListAsync());
        }

        /// <summary>
        /// detail buku
        /// </summary>
        /// <param name="id">berdasarkan id buku atau primary key</param>
        /// <returns>detail setiap buku sesuai database</returns>
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

        /// <summary>
        /// Menambahkan data buku
        /// </summary>
        /// <returns></returns>
        // GET: Bukus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bukus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

            /// <summary>
            /// validasi setelah menambahkan data buku
            /// </summary>
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

        /// <summary>
        /// edit data buku
        /// </summary>
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

        /// <summary>
        /// validasi data yang di edit
        /// </summary>
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

        /// <summary>
        /// menghapus buku
        /// </summary>
        /// <param name="id">hapus buku berdasarkan id atau primaray key</param>
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

        /// <summary>
        /// validasi hapus buku
        /// </summary>
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
