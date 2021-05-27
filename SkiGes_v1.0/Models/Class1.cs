using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiGes_v1._0.Models
{
    public class Class1
    {
        [Display(Name = "Range (Km)")]
        public float range { get; set; }

        [Display(Name = "Party name")]
        public string searchName { get; set; }
    }
}