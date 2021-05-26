namespace SkiGes_v1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pensiune")]
    public partial class Pensiune
    {
        [Key]
        public int idPensiune { get; set; }

        public int? idPartie { get; set; }
        [Display(Name = "Nume")]
        [StringLength(50)]
        public string nume { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string email { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(50)]
        public string telefon { get; set; }

        [Display(Name = "Camere")]
        public int? camere { get; set; }

        [Display(Name = "Latitudine")]
        public float? latitudine { get; set; }

        [Display(Name = "Longitudine")]
        public float? logitudine { get; set; }

        public int? idAdresa { get; set; }
        [Display(Name = "Adresa")]
        public virtual Adresa Adresa { get; set; }

        public virtual Partie Partie { get; set; }
    }
}
