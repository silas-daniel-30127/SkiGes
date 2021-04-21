namespace SkiGes_v2.Models
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

        [StringLength(50)]
        public string nume { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string telefon { get; set; }

        public int? camere { get; set; }

        public float? latitudine { get; set; }

        public float? logitudine { get; set; }

        public int? idAdresa { get; set; }

        public virtual Adresa Adresa { get; set; }

        public virtual Partie Partie { get; set; }
    }
}
