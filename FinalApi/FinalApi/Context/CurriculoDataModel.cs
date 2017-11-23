namespace FinalApi.Models.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CurriculoDataModel : DbContext
    {
        public CurriculoDataModel()
            : base("name=CurriculoDataModel")
        {
        }

        public virtual DbSet<Curriculo> Curriculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
