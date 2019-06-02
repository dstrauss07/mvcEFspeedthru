using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedThruLibrary;

namespace mvcEFspeedthru.Controllers
{
    public class SedanController : Controller
    {
        private readonly IRepository<Sedan> _sedanRepo;

        public SedanController(IRepository<Sedan> sedanRepo)
        {
            _sedanRepo = sedanRepo;
        }
        // GET: Sedan
        public ActionResult Index()
        {
            return View(_sedanRepo.ListAll());
        }

        // GET: Sedan/Details/5
        public ActionResult Details(int id)
        {
            return View(_sedanRepo.GetById(id));
        }

        // GET: Sedan/Create
        public ActionResult Create()
        {
            return View(new Sedan());
        }

        // POST: Sedan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sedan newSedan, IFormCollection collection)
        {
      
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newSedan);
                }

                _sedanRepo.NewCar(newSedan);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               //todo log exception
            }
            return View(newSedan);
        }

        // GET: Sedan/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_sedanRepo.GetById(id));
        }

        // POST: Sedan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sedan editedSedan, IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(editedSedan);
            }
            try
            {
                _sedanRepo.EditCar(editedSedan);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
              //todo log exception
            }
            return View(editedSedan);
        }

        // GET: Sedan/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_sedanRepo.GetById(id));
        }

        // POST: Sedan/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _sedanRepo.DeleteCar(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               //todo log exception
            }
            return View(_sedanRepo.GetById(id));
        }
    }
}