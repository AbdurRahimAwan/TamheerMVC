using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
{
    public class ConfigrationEntityNationality : EntityTypeConfiguration<Nationality>
    {
        public ConfigrationEntityNationality()
        {

            Property(x => x.ArNationalityName).HasMaxLength(100)
                 .IsRequired();
            Property(x => x.EnNationalityName).HasMaxLength(100)
                .IsRequired();

            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
