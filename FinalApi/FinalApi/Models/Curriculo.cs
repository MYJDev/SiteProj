namespace FinalApi.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Curriculo")]
    public partial class Curriculo
    {
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        
        public Guid IdFile { get; set; }

        public byte[] File { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string State { get; set; }

        public string Text { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
