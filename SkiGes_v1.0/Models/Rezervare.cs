namespace SkiGes_v1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rezervare")]
    public partial class Rezervare
    {
        [Key]
        public int idRezervare { get; set; }

        public int? idPartie { get; set; }

        public int? idUtilizator { get; set; }

        public int? numarCamere { get; set; }
    }
}
