﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Xitaso_Webapplikation.Models;
using Newtonsoft.Json;
using Xitaso_Webapplikation.ViewModels;

namespace Xitaso_Webapplikation.Controllers
{
    public class AnalyseController : Controller
    {
        Boolean created = false;

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
        public ActionResult Index(int id)
        {
            if (!created)
            {

                createExampleModels();
                created = true;
            }
            
            diagramData();
            string jsonIst = JsonConvert.SerializeObject(istData, Formatting.Indented);
            string jsonSoll = JsonConvert.SerializeObject(sollData, Formatting.Indented);


            Console.WriteLine(jsonIst);
            Console.WriteLine(jsonSoll);

            return View(new AnalyseViewModel(istData, sollData, analyse1, jsonIst, jsonSoll));

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


        /////////////////
        //Diagram Daten//
        /////////////////

        public void diagramData()
        { 
            Dictionary<string, double> istDataJSON = new Dictionary<string, double>();
            Dictionary<string, double> sollDataJSON = new Dictionary<string, double>();

            for (int i = 0; i < analyse1.analysekategories.Count(); i++)
            {
                string categoryName = analyse1.analysekategories[i].name;
                List<int> istValuesList = new List<int>();
                List<int> sollValuesList = new List<int>();

                //Loop für Ist-Bewertung
                for (int j = 0; j < analyse1.analysekategories[i].questions.Count(); j++)
                {
                    istValuesList.Add(analyse1.analysekategories[i].questions[j].istBewertung);
                }

                //Loop für Soll-Bewertung
                for (int j = 0; j < analyse1.analysekategories[i].questions.Count(); j++)
                {
                    sollValuesList.Add(analyse1.analysekategories[i].questions[j].SollBewertung);
                }

                double istMean = istValuesList.Average();
                double sollMean = sollValuesList.Average();

                istData.Add(categoryName, istMean);
                sollData.Add(categoryName, sollMean);

            }

        }
    }
   
}