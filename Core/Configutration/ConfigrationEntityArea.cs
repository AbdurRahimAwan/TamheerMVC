using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
{
    public class ConfigrationEntityArea : EntityTypeConfiguration<Area>
    {
        public ConfigrationEntityArea()
        {

            Property(x => x.Name).HasMaxLength(100)
                 .IsRequired();
            Property(x => x.Notes).HasMaxLength(200);
            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
