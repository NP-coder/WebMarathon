using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebMarathon.Models;

namespace WebMarathon.Controllers
{
    public class TravelController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;

        public TravelController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IEnumerable<Travel> GetTravels()
        {
            //для виводу створених заявок поточного користувача
            //var travels = (from travel in _db.Travels
            //             join monument in _db.WorldMonuments on travel.MonumentId equals monument.Id
            //             join users in _db.Users.Where(u => u.Id == _userManager.GetUserId(HttpContext.User)) on travel.UserId equals users.Id
            //             select new Travel
            //             {
            //                 Id = travel.Id,
            //                 UserId = travel.UserId,
            //                 MonumentId = travel.MonumentId,
            //                 Date = travel.Date,
            //                 Status = travel.Status
            //             }
            //             ).ToList();

            var travels = (from travel in _db.Travels
                           join monument in _db.WorldMonuments on travel.MonumentId equals monument.Id
                           join users in _db.Users on travel.UserId equals users.Id
                           select new Travel
                           {
                               Id = travel.Id,
                               UserId = travel.UserId,
                               MonumentId = travel.MonumentId,
                               Date = travel.Date,
                               Status = travel.Status
                           }
                         ).ToList();

            return travels;
        }

        public IActionResult TravelIndex()
        {
            IEnumerable<Travel> objList = GetTravels();
            foreach (var obj in objList)
            {
                obj.Monument = _db.WorldMonuments.FirstOrDefault(u => u.Id == obj.MonumentId);
                obj.User = _db.Users.FirstOrDefault(u => u.Id == obj.UserId);
            }
            return View(objList);
        }

        // GET-Create
        public IActionResult TravelCreate()
        {
            IEnumerable<SelectListItem> TravelDropDown = _db.WorldMonuments.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.TravelDropDown = TravelDropDown;

            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TravelCreate(Travel model)
        {

            var travel = new Travel
            {
                UserId = _userManager.GetUserId(HttpContext.User),
                MonumentId = model.MonumentId,
                Date = model.Date,
                Status = model.Status,
            };

            _db.Travels.Add(travel);
            _db.SaveChanges();
            return RedirectToAction("TravelIndex");
        }
        // GET Update
        public IActionResult TravelUpdate(int? id)
        {
            IEnumerable<SelectListItem> TravelDropDown = _db.WorldMonuments.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.TravelDropDown = TravelDropDown;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var travel = _db.Travels.Find(id);
            if (travel == null)
            {
                return NotFound();
            }
            return View(travel);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TravelUpdate(Travel model)
        {
            model.UserId = _userManager.GetUserId(HttpContext.User);
            _db.Travels.Update(model);
            _db.SaveChanges();
            return RedirectToAction("TravelIndex");
        }

    }
}
