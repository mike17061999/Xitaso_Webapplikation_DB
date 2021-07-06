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
    public class AnalyseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AnalyseController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            //IEnumerable<Analyse> objList = _db.Analysen;
            //return View(objList);
            return View();
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
        public IActionResult Create(Analyse obj)
        {
            _db.Analysen.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}