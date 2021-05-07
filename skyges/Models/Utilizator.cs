namespace skyges.Models
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

        [StringLength(50)]
        public string nume { get; set; }

        [StringLength(50)]
        public string prenume { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public int? varsta { get; set; }

        [StringLength(50)]
        public string telefon { get; set; }
    }
}
