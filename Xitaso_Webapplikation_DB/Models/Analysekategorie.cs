﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xitaso_Webapplikation.Models
{
    public class Analysekategorie
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Frage> questions { get; set; }
    }
}