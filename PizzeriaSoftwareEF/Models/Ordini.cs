namespace PizzeriaSoftwareEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            DettaglioOrdini = new HashSet<DettaglioOrdini>();
            NoteOrdini = new HashSet<NoteOrdini>();
        }

        [Key]
        public int IdOrdine { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data Ordine")]
        public DateTime DataOrdine { get; set; }

        [Column(TypeName = "money")]
        public decimal Importo { get; set; }

        [Required]
        [Display(Name = "Indirizzo Consegna")]
        public string IndirizzoConsegna { get; set; }
        [Display(Name = "Stato Ordine")]
        public string StatoOrdine { get; set; }

        public int IdCliente { get; set; }

        public virtual Clienti Clienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioOrdini> DettaglioOrdini { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoteOrdini> NoteOrdini { get; set; }
    }
}
