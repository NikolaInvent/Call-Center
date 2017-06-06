namespace Kolcen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zahtevi")]
    public partial class Zahtevi
    {
        public int ZahteviID { get; set; }

        public int ZaposleniID { get; set; }

        [Required]
        [StringLength(100)]
        public string OpisProblema { get; set; }

        public int BrojKlijenta { get; set; }

        [Required]
        [StringLength(100)]
        public string ResenjeProblema { get; set; }

        public virtual Zaposleni Zaposleni { get; set; }
    }
}
