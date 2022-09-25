using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaASP.Models;

namespace BibliotecaASP.Controllers
{
    public class LibrosController : Controller
    {
        // GET: Libros
        public ActionResult Index()
        {
            List<libros> libros = new List<libros>();
            using (bibliotecaEntities biblioteca = new bibliotecaEntities())
            {
                libros = biblioteca.libros.ToList<libros>();

            }
            return View(libros);
        }

        // GET: Libros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            return View(new libros());
        }

        // POST: Libros/Create
        [HttpPost]
        public ActionResult Create(libros libros)
        {
            using (bibliotecaEntities biblioteca = new bibliotecaEntities())
            {
                biblioteca.libros.Add(libros); // Esto es mas o menos como un prepare
                biblioteca.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int id)
        {
            libros libros = new libros();
            using(bibliotecaEntities bibilioteca = new bibliotecaEntities())
            {
                libros = bibilioteca.libros.Where(x => x.id == id).FirstOrDefault();
            }
            return View(libros);
        }

        // POST: Libros/Edit/5
        [HttpPost]
        public ActionResult Edit(libros libros)
        {
            using(bibliotecaEntities biblioteca = new bibliotecaEntities())
            {
                biblioteca.Entry(libros).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                biblioteca.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int id)
        {
            libros libros = new libros();
            using (bibliotecaEntities bibilioteca = new bibliotecaEntities())
            {
                libros = bibilioteca.libros.Where(x => x.id == id).FirstOrDefault();
            }
            return View(libros);
            
        }

        // POST: Libros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using(bibliotecaEntities biblioteca = new bibliotecaEntities())
            {
                libros libros = biblioteca.libros.Where(x => x.id == id).FirstOrDefault();
                biblioteca.libros.Remove(libros);
                biblioteca.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
