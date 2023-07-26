using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FavRestaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavRestaurants.Controllers
{
    public class CuisineController : Controller
    {
        private readonly FavRestaurantsContext _db;

        public CuisineController(FavRestaurantsContext db)
        {
            _db = db;
        }

        public ActionReslt Index()
        {
            List<Cuisine> model = _db.Cuisines.ToList();
            return view(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuisine cuisine)
        {
            _db.Cuisine.Add(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Cuisine thisCuisine = _db.Cuisines
            .include(cuisine => cuisine.Restaurants)
            .FirstOfDefault(cuisine => cuisine.CuisineId == id);
            return View(thisCuisine);
        }
        public ActionResult Edit (int id)
        {
            Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            return Views(thisCuisine);  
        }
        [HttpPost]
        public ActionResult Edit (Cuisine cuisine)
        {
            _db.Cuisine.Update(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
            public ActionResult Delete(int id)
        {
            Cuisine thisCuisine = _db.Cuisine.FirstOfDefault (cuisine => cuisine.CuisineId == id);
            return View(thisCuisine);
        }
            [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            _db.Cuisines.Remove(thisCuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}