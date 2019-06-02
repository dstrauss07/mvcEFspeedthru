using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedThruLibrary;

namespace mvcEFspeedthru.Controllers
{
    public class TruckController : Controller
    {
        private readonly IRepository<Truck> _truckRepo;

        public TruckController(IRepository<Truck> truckRepo)
        {
            _truckRepo = truckRepo;
        }

        // GET: Truck
        public ActionResult Index()
        {
            return View(_truckRepo.ListAll());
        }

        // GET: Truck/Details/5
        public ActionResult Details(int id)
        {
            return View(_truckRepo.GetById(id));
        }

        // GET: Truck/Create
        public ActionResult Create()
        {
            return View(new Truck());
        }

        // POST: Truck/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Truck newTruck, IFormCollection collection)
        {
            try
            {
               if(!ModelState.IsValid)
                {
                    return View(newTruck);
                }

                _truckRepo.NewCar(newTruck);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //todo log the exception
            }
            return View(newTruck);
        }

        // GET: Truck/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Truck/Edit/5
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

        // GET: Truck/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_truckRepo.GetById(id));
        }

        // POST: Truck/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _truckRepo.DeleteCar(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //todo log the exception
                }
            return View(_truckRepo.GetById(id));
        }
    }
}