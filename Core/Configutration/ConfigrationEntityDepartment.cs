using Core.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Configutration
{
    public class ConfigrationEntityDepartment : EntityTypeConfiguration<Department>
    {
        public ConfigrationEntityDepartment ()
        {

            Property(x => x.Name).HasMaxLength(100)
                 .IsRequired();
            Property(x => x.Notes).HasMaxLength(200).IsRequired();
            Property(x => x.CoordinatorId).HasMaxLength(450);
            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
