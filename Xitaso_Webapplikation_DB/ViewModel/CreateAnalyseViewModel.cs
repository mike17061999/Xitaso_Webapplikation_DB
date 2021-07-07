using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xitaso_Webapplikation_DB.Models;


namespace Xitaso_Webapplikation_DB.ViewModels
{
    public class CreateAnalyseViewModel
    {

        public List<Projekt> Projekte { get; set; }
        public Analyse Analyse { get; set; }

        public CreateAnalyseViewModel(List<Projekt>_Projekte)
        {
            Projekte = _Projekte;
        }

    }
}