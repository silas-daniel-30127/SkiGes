namespace SkiGes_v1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partie")]
    public partial class Partie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partie()
        {
            Pensiune = new HashSet<Pensiune>();
        }

        [Key]
        public int idPartie { get; set; }

        [Display(Name = "Partie")]
        [StringLength(50)]
        public string nume { get; set; }

        [Display(Name = "Orar")]
        [StringLength(50)]
        public string orar { get; set; }

        [Display(Name = "Link")]
        [StringLength(50)]
        public string link { get; set; }

        [Display(Name = "Latitudine")]
        public double latitudine { get; set; }

        [Display(Name = "Longitudine")]
        public double longitudine { get; set; }

        [Display(Name = "Stare")]
        [StringLength(50)]
        public string stare_partie { get; set; }

        [Display(Name = "Dificultate")]
        [StringLength(50)]
        public string dificultate { get; set; }

        [Display(Name = "Strat zapada")]
        public int? strat_zapada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pensiune> Pensiune { get; set; }
    }
}
