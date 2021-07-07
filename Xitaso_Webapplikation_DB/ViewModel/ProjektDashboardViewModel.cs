using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xitaso_Webapplikation_DB.Models;


namespace Xitaso_Webapplikation_DB.ViewModels
{
    public class ProjektDashboardViewModel
    {
        public List<Projekt> projects { get; set; }

        //public List<Analyse> Analysis { get; set; }
        public ProjektDashboardViewModel(List<Projekt> _projects)
        {
            projects = _projects;
        }


        //public ProjektDashboardViewModel(List<Analyse> _analysis)
        //{
        //    Analysis = _analysis;
        //}
    }
}