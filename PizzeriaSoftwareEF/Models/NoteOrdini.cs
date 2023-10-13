namespace PizzeriaSoftwareEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoteOrdini")]
    public partial class NoteOrdini
    {
        [Key]
        public int IdNota { get; set; }

        [Required]
        [Display(Name = "Nota")]
        public string DescrizioneNota { get; set; }

        public int IdOrdine { get; set; }

        public virtual Ordini Ordini { get; set; }
    }
}
