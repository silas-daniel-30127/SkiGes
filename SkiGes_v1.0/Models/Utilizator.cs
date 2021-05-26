namespace SkiGes_v1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Utilizator")]
    public partial class Utilizator
    {
        [Key]
        public int idUtilizator { get; set; }

        [Display(Name = "Username/Email")]
        [StringLength(50)]
        public string nume { get; set; }

        [Display(Name = "Prenume")]
        [StringLength(50)]
        public string prenume { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string email { get; set; }

        public int? varsta { get; set; }
        [Display(Name = "Telefon")]
        [StringLength(50)]
        public string telefon { get; set; }
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string type { get; set; }
    }
}
