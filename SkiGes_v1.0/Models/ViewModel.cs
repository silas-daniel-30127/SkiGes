using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiGes_v1._0.Models
{
    public class ViewModel
    {
        public Rezervare rezervare { get; set; }

        public List<Pensiune> pensiuni { get; set; }
    }
}