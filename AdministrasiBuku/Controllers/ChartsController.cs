﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministrasiBuku.Controllers
{
    /// <summary>
    /// controller chart
    /// </summary>
    public class ChartsController : Controller
    {
        /// <summary>
        /// mendapatkan data dari tabel buku, kemudian menampilkannya dalam bentuk chart menggunakan javascript
        /// </summary>
        /// <returns></returns>
        // GET: Charts
        public ActionResult Index()
        {
            return View();
        }

        // GET: Charts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Charts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Charts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Charts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Charts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Charts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Charts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}