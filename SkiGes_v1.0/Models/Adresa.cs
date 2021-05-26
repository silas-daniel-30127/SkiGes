namespace SkiGes_v1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adresa")]
    public partial class Adresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adresa()
        {
            Pensiune = new HashSet<Pensiune>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idAdresa { get; set; }

        [Display(Name = "Nume Oras")]
        [StringLength(50)]
        public string oras { get; set; }

        [Display(Name = "Strada")]
        [StringLength(50)]
        public string strada { get; set; }

        [Display(Name = "Numar")]
        public int? numar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pensiune> Pensiune { get; set; }
    }
}
