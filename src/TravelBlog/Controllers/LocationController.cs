using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;
using System;



namespace TravelBlog.Controllers
{
    public class LocationController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisLocation= db.Locations.FirstOrDefault(loc => loc.LocationId == id);

            return View(thisLocation);
        }

        public IActionResult Create()
       {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var thisLoc = db.Locations.FirstOrDefault(loc => loc.LocationId == id);
            return View(thisLoc);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLoc = db.Locations.FirstOrDefault(loc => loc.LocationId == id);
            db.Locations.Remove(thisLoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisLoc = db.Locations.FirstOrDefault(loc => loc.LocationId == id);
            return View(thisLoc);
        }

        [HttpPost]
        public IActionResult Edit(Experience locerience)
        {
            db.Entry(locerience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
