using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xitaso_Webapplikation_DB.Models
{
    public class Analyse
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string comment { get; set; }
        public DateTime lastChanged { get; set; }
        public List<Analysekategorie> analysekategories { get; set; }
    }
}