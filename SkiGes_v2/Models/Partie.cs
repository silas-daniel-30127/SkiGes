namespace SkiGes_v2.Models
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

        [StringLength(50)]
        public string nume { get; set; }

        [StringLength(50)]
        public string orar { get; set; }

        [StringLength(50)]
        public string link { get; set; }

        public float? latitudine { get; set; }

        public float? longitudine { get; set; }

        [StringLength(50)]
        public string stare_partie { get; set; }

        [StringLength(50)]
        public string dificultate { get; set; }

        public int? strat_zapada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pensiune> Pensiune { get; set; }
    }
}
