namespace PizzeriaSoftwareEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            DettaglioOrdini = new HashSet<DettaglioOrdini>();
        }

        [Key]
        public int IdProdotto { get; set; }

        [Required]
        [Display(Name = "Prodotto")]
        public string NomeProdotto { get; set; }

        [Column(TypeName = "money")]
        public decimal Costo { get; set; }
        [Display(Name = "Tempo di Consegna")]
        public int? TempoConsegna { get; set; }

        [Required]
        [Display(Name = "Img.Prodotto")]
        public string FotoProdotto { get; set; }

        [Required]
        public string Ingredienti { get; set; }
        [Display(Name = "Descrizione Prodotto")]
        public string DescrizioneAggiuntiva { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioOrdini> DettaglioOrdini { get; set; }
    }
}
