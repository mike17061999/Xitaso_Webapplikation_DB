using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Xitaso_Webapplikation.Models;

namespace Xitaso_Webapplikation.Controllers
{
    public class AnalyseController : Controller
    {
        Boolean created = false;

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
        public ActionResult Index()
        {
            if (!created)
            {
                createExampleModels();
                created = true;
            }

            return View(analyse1);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(Analyse anlyse)
        {
            //Code um neue Analyse in die Datenbank einzufügen
            created = true;
            analyse1.name = anlyse.name;
            return RedirectToAction("Index", "Analyse");
        }

    }
}