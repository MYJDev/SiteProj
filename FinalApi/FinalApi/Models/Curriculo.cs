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
        public int id { get; set; }

        [Required]
        public string city { get; set; }

        
        public Guid id_file { get; set; }

        public byte[] file { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string state { get; set; }

        public string text { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string phone { get; set; }
    }
}
