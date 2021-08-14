using System;
using Microsoft.AspNetCore.Mvc;
using CrudApp.Data;
using System.Collections.Generic;
using CrudApp.Models;
using System.Linq;

namespace CrudApp.Controllers
{
    public class LibrosController : Controller
    {

        private readonly AppDbContext _context;

        public LibrosController(AppDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libros.ToList();
            return View(listaLibros);
        }


        //Get
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro newLibro)
        {

            //Validar el modelo
            if (ModelState.IsValid)
            {
                _context.Add(newLibro);
                _context.SaveChanges();
                TempData["alerta"] = "El libro se guardo correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libros.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro newLibro)
        {

            //Validar el modelo
            if (ModelState.IsValid)
            {
                _context.Update(newLibro);
                _context.SaveChanges();
                TempData["alerta"] = "El libro se edito correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libros.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var libro = _context.Libros.Find(id);

            if (libro == null)
            {
                return NotFound();
            }
            //Validar el modelo
            if (ModelState.IsValid)
            {
                _context.Remove(libro);
                _context.SaveChanges();
                TempData["alerta"] = "El libro se elimino correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}