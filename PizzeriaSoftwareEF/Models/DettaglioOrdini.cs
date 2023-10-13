namespace PizzeriaSoftwareEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettaglioOrdini")]
    public partial class DettaglioOrdini
    {
        [Key]
        public int IdDettaglio { get; set; }

        public int IdProdotto { get; set; }
        [Display(Name = "Quantit�")]
        public int Quantita { get; set; }

        public int IdOrdine { get; set; }

        public virtual Ordini Ordini { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
