using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xitaso_Webapplikation_DB.Models;


namespace Xitaso_Webapplikation_DB.ViewModels
{
    public class AnalyseViewModel
    {

        public Dictionary<string, double> istData { get; set; }
        public Dictionary<string, double> sollData { get; set; }
        public Analyse analyse1 { get; set; }
        public string jsonIst { get; set;}
        public string jsonSoll { get; set; }

        public AnalyseViewModel(Dictionary<string, double> _istData, Dictionary<string, double> _sollData, Analyse _analyse1, string _jsonIst, string _jsonSoll)
        {
            istData = _istData;
            sollData = _sollData;
            analyse1 = _analyse1;
            jsonIst = _jsonIst;
            jsonSoll = _jsonSoll;

        }
        
    }
}