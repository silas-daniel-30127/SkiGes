namespace SkiGes_v1._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Echipamente")]
    public partial class Echipamente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEchipamente { get; set; }

        [Column(TypeName = "text")]
        public string descriere { get; set; }

        [Column(TypeName = "text")]
        public string stoc { get; set; }
    }
}
