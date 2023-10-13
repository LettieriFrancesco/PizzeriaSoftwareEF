namespace PizzeriaSoftwareEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int IdUser { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordUser { get; set; }

        [StringLength(50)]
        public string Ruolo { get; set; }
    }
}
