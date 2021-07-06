using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Xitaso_Webapplikation.Models
{
    public class Analyse
    {

        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string comment { get; set; }
        public DateTime lastChanged { get; set; }



    }
}
