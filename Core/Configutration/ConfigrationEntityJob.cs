using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
{
    public class ConfigrationEntityJob : EntityTypeConfiguration<Job>
    {
        public ConfigrationEntityJob()
        {

            Property(x => x.Name).HasMaxLength(100)
                 .IsRequired();
            Property(x => x.Notes).HasMaxLength(200);
            Property(x => x.GoogleMapLink).IsRequired().HasMaxLength(200);
            Property(x => x.ExplaningOfTranningTask).HasMaxLength(500);
            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);

        }
    }
}
