using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Xitaso_Webapplikation.Models
{
    public class Projekt
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool ProjectFinished { get; set; }

        public List<Analyse> analysis { get; set; }
    

    }
}