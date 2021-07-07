using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xitaso_Webapplikation_DB.Models
{
    public class Frage
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int istBewertung { get; set; }
        public int SollBewertung { get; set; }
        public int analyseKategorieId { get; set; }
    }
}