using Xitaso_Webapplikation_DB.Data;
using Xitaso_Webapplikation_DB.Models;
using Xitaso_Webapplikation_DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Xitaso_Webapplikation_DB.Controllers
{
    public class ProjektController : Controller
    {
        public Projekt projekt1 = new Projekt();
        public Projekt projekt2 = new Projekt();
        public Analyse analyse1 = new Analyse();
        public Analyse analyse2 = new Analyse();
        public Analyse analyse3 = new Analyse();
        List<Projekt> projects;
        #region createExampleModels definition

        public void createExampleModels()
        {
            analyse1.Id = 1;
            analyse1.name = "analyse1";
            analyse1.comment = "Kommentar von Analyse 1";
            DateTime thisDay = DateTime.Now;
            analyse1.lastChanged = thisDay;
            analyse2.name = "analyse2";
            analyse2.comment = "Kommentar von Analyse 2";
            analyse3.name = "analyse3";


            projekt1.Id = 1;
            projekt1.name = "Kunde1";
            projekt1.projectDescription = "Dies ist die Projektbeschreibung von Kunde1";
            projekt1.analysis = new List<Analyse>
            {
                analyse1,
                analyse2
            };
            projekt2.Id = 2;
            projekt2.name = "Kunde2";
            projekt2.projectDescription = "Dies ist die Projektbeschreibung von Kunde2";
            projekt2.analysis = new List<Analyse>
            {
                analyse1,
                analyse2,
                analyse3
            };

            projects = new List<Projekt>
            {
                projekt1,
                projekt2
            };


        }
        #endregion
        private readonly ApplicationDbContext _db;

        public ProjektController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            createExampleModels();
            List<Analyse> analysisListTemp = new List<Analyse>();
            List<Analysekategorie> analysiscategoryListTemp = new List<Analysekategorie>();
            List<Frage> questionListTemp = new List<Frage>();
            List<Analysekategorie> analyseskategoriesList = _db.Analysekategorien.ToList();
            List<Analyse> analysesList = _db.Analysen.ToList();
            List<Projekt> projectList = _db.Projekte.ToList();
            List<Frage> questionList = _db.Fragen.ToList();
            foreach (Projekt project in projectList)
            {
                foreach (Analyse analyses in analysesList)
                {
                    if (project.Id == analyses.projectId)
                    {
                        foreach (Analysekategorie analysiscategory in analyseskategoriesList)
                        {
                            if (analyses.Id == analysiscategory.Id)
                            {
                                foreach (Frage question in questionList)
                                {
                                    if (analysiscategory.Id == question.analyseKategorieId)
                                    {
                                        questionListTemp.Add(question);
                                    }
                                }
                                analysiscategory.questions = questionListTemp;
                                questionListTemp.Clear();
                                analysiscategoryListTemp.Add(analysiscategory);
                            }   
                        }
                        analyses.analysekategories = analysiscategoryListTemp;
                        analysiscategoryListTemp.Clear();
                        analysisListTemp.Add(analyses);
                    }
                }
                project.analysis = analysisListTemp;
                analysisListTemp.Clear();
            }
            
            
            
            return View(new ProjektDashboardViewModel(projectList));
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
        public IActionResult EditProject(int id)
        {
            var project = _db.Projekte.SingleOrDefault(c => c.Id == id);
            if (project == null)
                //abbruch
            //_db.Projekte.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST-Create
        public IActionResult CreateProject(Projekt obj)
        {
            DateTime thisDay = DateTime.Today;
            obj.StartTime = thisDay;
            _db.Projekte.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xitaso_Webapplikation.Models;
using Xitaso_Webapplikation.ViewModels;
namespace Xitaso_Webapplikation.Controllers
{
    public class ProjektController : Controller
    {
        public Projekt projekt1 = new Projekt();
        public Projekt projekt2 = new Projekt();
        public Analyse analyse1 = new Analyse();
        public Analyse analyse2 = new Analyse();
        public Analyse analyse3 = new Analyse();
        List<Projekt> projects;

        #region createExampleModels definition

        public void createExampleModels()
        {
            analyse1.Id = 1;
            analyse1.name = "analyse1";
            analyse1.comment = "Kommentar von Analyse 1";
            analyse2.name = "analyse2";
            analyse2.comment = "Kommentar von Analyse 2";
            analyse3.name = "analyse3";

            projekt1.Id = 1;
            projekt1.name = "Kunde1";
            projekt1.projectDescription = "Dies ist die Projektbeschreibung von Kunde1";
            projekt1.analysis = new List<Analyse>
            {
                analyse1,
                analyse2
            };
            projekt2.Id = 2;
            projekt2.name = "Kunde2";
            projekt2.projectDescription = "Dies ist die Projektbeschreibung von Kunde2";
            projekt2.analysis = new List<Analyse>
            {
                analyse1,
                analyse2,
                analyse3
            };

            projects = new List<Projekt>
            {
                projekt1,
                projekt2
            };

            
        }
        #endregion
        public ActionResult Index()
        {
            createExampleModels();
            return View(new ProjektDashboardViewModel(projects));
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(Projekt projekt)
        {
            //Code um neue Projekte anzulegen und in die Datenbank einzufügen
            return RedirectToAction("Index", "Analyse");
        }
    }
}
 */