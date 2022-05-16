using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMarathon.Models;

namespace WebMarathon.Controllers
{
    public class WorldMonumentController : Controller
    {

        private readonly ApplicationDbContext _db;

        public WorldMonumentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult MonumentIndex()
        {
            IEnumerable<WorldMonument> objList = _db.WorldMonuments;

            return View(objList);
        }
    }
}
