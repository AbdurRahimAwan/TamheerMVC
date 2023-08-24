using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
{
    public class ConfigrationEntityTicket : EntityTypeConfiguration<Ticket>
    {
        public ConfigrationEntityTicket()
        {

            Property(x => x.Subject).HasMaxLength(100)
                 .IsRequired();
            Property(x => x.Details).HasMaxLength(500)
                 .IsRequired();
            Property(x => x.Notes).HasMaxLength(500);

            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
