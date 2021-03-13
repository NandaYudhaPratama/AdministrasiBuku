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
    /// controller petugas
    /// </summary>
    public class PetugasController : Controller
    {
        private readonly DbAdmBukuContext _context;

        public PetugasController(DbAdmBukuContext context)
        {
            _context = context;
        }
        /// <summary>
        /// mendapatkan data dari petugas
        /// </summary>
        /// <returns></returns>
        // GET: Petugas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Petugas.ToListAsync());
        }
        /// <summary>
        /// isi dari tabel petugas
        /// </summary>
        /// <param name="id"> berdasarkan id petugas atau primary key</param>
        /// <returns></returns>
        // GET: Petugas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petugas = await _context.Petugas
                .FirstOrDefaultAsync(m => m.IdPetugas == id);
            if (petugas == null)
            {
                return NotFound();
            }

            return View(petugas);
        }

        /// <summary>
        /// input data petugas
        /// </summary>
        /// <returns></returns>
        // GET: Petugas/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// validasi
        /// </summary>
        /// <returns></returns>
        // POST: Petugas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPetugas,Username,Password")] Petugas petugas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petugas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petugas);
        }

        /// <summary>
        /// edit data petugas
        /// </summary>
        // GET: Petugas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petugas = await _context.Petugas.FindAsync(id);
            if (petugas == null)
            {
                return NotFound();
            }
            return View(petugas);
        }

        // POST: Petugas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// validasi
        /// </summary>
        /// <param name="id"> berdasarkan id petugas atau primary key</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPetugas,Username,Password")] Petugas petugas)
        {
            if (id != petugas.IdPetugas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petugas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetugasExists(petugas.IdPetugas))
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
            return View(petugas);
        }
        /// <summary>
        /// hapus data petugas
        /// </summary>
        /// <param name="id">berdasarkan id petugas atau primary key</param>
        /// <returns></returns>
        // GET: Petugas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petugas = await _context.Petugas
                .FirstOrDefaultAsync(m => m.IdPetugas == id);
            if (petugas == null)
            {
                return NotFound();
            }

            return View(petugas);
        }

        /// <summary>
        /// validasi
        /// </summary>
        // POST: Petugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petugas = await _context.Petugas.FindAsync(id);
            _context.Petugas.Remove(petugas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetugasExists(int id)
        {
            return _context.Petugas.Any(e => e.IdPetugas == id);
        }
    }
}
