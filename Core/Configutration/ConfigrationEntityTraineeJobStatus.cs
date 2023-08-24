using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
{
    public class ConfigrationEntityTraineeJobStatus : EntityTypeConfiguration<TraineeJobStatus>
    {
        public ConfigrationEntityTraineeJobStatus()
        {

            Property(x => x.TStatusName).HasMaxLength(100)
                 .IsRequired();
            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
