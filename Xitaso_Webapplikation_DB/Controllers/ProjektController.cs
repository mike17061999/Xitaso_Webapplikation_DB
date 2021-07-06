using Xitaso_Webapplikation.Data;
using Xitaso_Webapplikation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Xitaso_Webapplikation.Controllers
{
    public class ProjektController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjektController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Projekt> objList = _db.Projekte;
            return View(objList);
        }

        public IActionResult Edit()
        {
            return View();
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST-Create
        public IActionResult Create(Projekt obj)
        {
            _db.Projekte.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}