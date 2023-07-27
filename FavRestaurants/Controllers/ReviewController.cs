using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FavRestaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavRestaurants.Controllers
{
    public class ReviewController : Controller
    {
        private readonly FavRestaurantsContext _db;

        public ReviewController(FavRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Review> model = _db.Reviews.Include(review => review.Restaurant).ToList();
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review review)
        {
            if (review.RestaurantId == 0)
            {
                return RedirectToAction("Create");
            }
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Review thisReview = _db.Reviews.Include(review => review.Restaurant).FirstOrDefault(review => review.ReviewId == id);
            return View(thisReview);
        }
        public ActionResult Edit(int id)
        {
            Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantsId", "Name");
            return View(thisReview);
        }
        [HttpPost]
        public ActionResult Edit(Review review)
        {
            _db.Reviews.Update(review);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
            _db.Reviews.Remove(thisReview);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}