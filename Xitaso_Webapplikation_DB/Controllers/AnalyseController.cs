using Xitaso_Webapplikation_DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Xitaso_Webapplikation_DB.Models;
using Newtonsoft.Json;
using Xitaso_Webapplikation_DB.ViewModels;

namespace Xitaso_Webapplikation_DB.Controllers
{
    public class AnalyseController : Controller
    {
        public Analyse analyse = new Analyse();

        Dictionary<string, double> istData = new Dictionary<string, double>();
        Dictionary<string, double> sollData = new Dictionary<string, double>();

        public Analysekategorie analysekategorie1 = new Analysekategorie();
        public Analysekategorie analysekategorie2 = new Analysekategorie();
        public Analysekategorie analysekategorie3 = new Analysekategorie();

        public Frage frage1 = new Frage();
        public Frage frage2 = new Frage();
        public Frage frage3 = new Frage();
        public Frage frage4 = new Frage();
        public Frage frage5 = new Frage();
        public Frage frage6 = new Frage();
        public Frage frage7 = new Frage();

        #region createExampleModels definition
        Analyse analyse1 = new Analyse();
        public void createExampleModels()
        {

            frage1.name = "Name von Frage 1 der wirklich lang ist und deswegen vielleicht über mehrere Zeilen geht. So sieht das dann aus";
            frage2.name = "Name von Frage 2";
            frage3.name = "Name von Frage 3";
            frage4.name = "Name von Frage 4";
            frage5.name = "Name von Frage 5";
            frage6.name = "Name von Frage 6";
            frage7.name = "Name von Frage 7";

            frage1.Id = 1;
            frage2.Id = 2;
            frage3.Id = 3;
            frage4.Id = 4;
            frage5.Id = 5;
            frage6.Id = 6;
            frage7.Id = 7;

            frage1.SollBewertung = 2;
            frage2.SollBewertung = 3;
            frage3.SollBewertung = 4;
            frage4.SollBewertung = 5;
            frage5.SollBewertung = 4;
            frage6.SollBewertung = 3;
            frage7.SollBewertung = 2;

            frage1.istBewertung = 1;
            frage2.istBewertung = 5;
            frage3.istBewertung = 4;
            frage4.istBewertung = 5;
            frage5.istBewertung = 2;
            frage6.istBewertung = 1;
            frage7.istBewertung = 3;

            analysekategorie1.name = "Name von Analysekategorie 1";
            analysekategorie2.name = "Name von Analysekategorie 2";
            analysekategorie3.name = "Name von Analysekategorie 3";

            analysekategorie1.questions = new List<Frage>
            {
                frage1,
                frage5
            };
            analysekategorie2.questions = new List<Frage>
            {
                frage2,
                frage7
            };
            analysekategorie3.questions = new List<Frage>
            {
                frage3,
                frage4,
                frage6
            };

            analyse1.analysekategories = new List<Analysekategorie>
            {
                analysekategorie1,
                analysekategorie2,
                analysekategorie3
            };
            analyse1.name = "testanalyse";
            analyse1.comment = "Dies ist ein Testkommentar";
            
        }
        #endregion
        private readonly ApplicationDbContext _db;
        public AnalyseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index(int id)
        {
            //analyse = _db.Analysen.Where(a => a.Id == id) as Analyse;
            analyse = _db.Analysen.Where(a => a.Id == id).FirstOrDefault();
            var list = _db.Analysekategorien.Where(a => a.analyseId == analyse.Id).ToList();
            analyse.analysekategories = list;
            foreach (Analysekategorie analysiscategory in analyse.analysekategories)
            {
                var list2 = _db.Fragen.Where(a => analysiscategory.Id == a.Id).ToList();
                analysiscategory.questions = new List<Frage>(list2);
            }

            createExampleModels();
            
            diagramData();
            string jsonIst = JsonConvert.SerializeObject(istData, Formatting.Indented);
            string jsonSoll = JsonConvert.SerializeObject(sollData, Formatting.Indented);


            return View(new AnalyseViewModel(istData, sollData, analyse, jsonIst, jsonSoll));

        }
        public ActionResult Create()
        {
            List<Projekt> projectList = _db.Projekte.ToList();

            return View(new CreateAnalyseViewModel(projectList));
        }
        [HttpPost]
        public ActionResult Post(Analyse anlyse)
        {
            //Code um neue Analyse in die Datenbank einzufügen
            analyse1.name = anlyse.name;
            return RedirectToAction("Index", "Analyse");

        }


        /////////////////
        //Diagram Daten//
        /////////////////

        public void diagramData()
        { 
            Dictionary<string, double> istDataJSON = new Dictionary<string, double>();
            Dictionary<string, double> sollDataJSON = new Dictionary<string, double>();

            for (int i = 0; i < analyse.analysekategories.Count(); i++)
            {
                string categoryName = analyse.analysekategories[i].name;
                List<int> istValuesList = new List<int>();
                List<int> sollValuesList = new List<int>();

                //Loop für Ist-Bewertung
                for (int j = 0; j < analyse.analysekategories[i].questions.Count(); j++)
                {
                    istValuesList.Add(analyse.analysekategories[i].questions[j].istBewertung);
                }

                //Loop für Soll-Bewertung
                for (int j = 0; j < analyse.analysekategories[i].questions.Count(); j++)
                {
                    sollValuesList.Add(analyse.analysekategories[i].questions[j].SollBewertung);
                }

                double istMean = istValuesList.Average();
                double sollMean = sollValuesList.Average();

                istData.Add(categoryName, istMean);
                sollData.Add(categoryName, sollMean);

            }

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //// POST-Create
        //public IActionResult CreateAnalysis(CreateAnalyseViewModel obj)
        //{
        //    Analyse analyse = new Analyse();
        //    analyse.name = obj.Analyse.name;
        //    analyse.comment = obj.Analyse.comment;
        //    analyse.projectId = obj.Analyse.projectId;
        //    _db.Analysen.Add(analyse);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index", "Projekt");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST-Create
        public IActionResult CreateAnalysis(Analyse analyse)
        {
            _db.Analysen.Add(analyse);
            _db.SaveChanges();
            Analysekategorie analysekategorie1 = new Analysekategorie();
            analysekategorie1.name = "Erwartungskonformität";
            analysekategorie1.analyseId = analyse.Id;
            
            Analysekategorie analysekategorie2 = new Analysekategorie();
            analysekategorie2.name = "Individualisierbarkeit";
            analysekategorie2.analyseId = analyse.Id;

            Analysekategorie analysekategorie3 = new Analysekategorie();
            analysekategorie3.name = "Fehlertoleranz";
            analysekategorie3.analyseId = analyse.Id;

            
            _db.Analysekategorien.Add(analysekategorie1);
            _db.Analysekategorien.Add(analysekategorie2);
            _db.Analysekategorien.Add(analysekategorie3);
            _db.SaveChanges();
            //var list = (from u in _db.Analysekategorien
            //            select new Analysekategorie
            //            {
            //                analyseId = u.analyseId,
            //            }).ToList();
            Analysekategorie analysekategorie8 = new Analysekategorie();
            analysekategorie8 = _db.Analysekategorien.Where(a => a.analyseId == analyse.Id && a.name == "Erwartungskonformität").FirstOrDefault();
            Frage frage1 = new Frage();
            frage1.name = "Das System erleichtert die Orientierung durch eine einheitliche Gestaltung";
            frage1.analyseKategorieId = analysekategorie8.Id;
            Frage frage2 = new Frage();
            frage2.name = "Das System lässt den Nutzer nicht im Unklaren darüber, ob eine Eingabe erfolgreich war oder nicht";
            frage2.analyseKategorieId = analysekategorie8.Id;
            Analysekategorie analysekategorie9 = new Analysekategorie();
            analysekategorie9 = _db.Analysekategorien.Where(a => a.analyseId == analyse.Id && a.name == "Individualisierbarkeit").FirstOrDefault();
            Frage frage3 = new Frage();
            frage3.name = "Das System eignet sich für Anfänger und Experten gleichermaßen, weil es auf den Kenntnisstand des Benutzers angepasst werden kann";
            frage3.analyseKategorieId = analysekategorie9.Id;
            Frage frage4 = new Frage();
            frage4.name = "Das System ist so gestaltet, dass der Benutzer die Ausgabe gut an seine individuellen Bedürfnisse anpassen kann (Bildschirmdarstellung/Accesibility) ";
            frage4.analyseKategorieId = analysekategorie9.Id;
            Analysekategorie analysekategorie10 = new Analysekategorie();
            analysekategorie10 = _db.Analysekategorien.Where(a => a.analyseId == analyse.Id && a.name == "Fehlertoleranz").FirstOrDefault();
            Frage frage5 = new Frage();
            frage5.name = "Das System informiert über fehlerhafte Eingaben";
            frage5.analyseKategorieId = analysekategorie10.Id;
            Frage frage6 = new Frage();
            frage6.name = "Das System liefert gut verständliche Fehlermeldungen";
            frage6.analyseKategorieId = analysekategorie10.Id;

            _db.Fragen.Add(frage1);
            _db.Fragen.Add(frage2);
            _db.Fragen.Add(frage3);
            _db.Fragen.Add(frage4);
            _db.Fragen.Add(frage5);
            _db.Fragen.Add(frage6);
            _db.SaveChanges();
            return RedirectToAction("Index", "Projekt");
        }
    }
   
}