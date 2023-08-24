using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
{
    public class ConfigrationEntityTicketResponse : EntityTypeConfiguration<TicketResponse>
    {
        public ConfigrationEntityTicketResponse()
        {


            Property(x => x.FilePath).HasMaxLength(500);

            Property(x => x.Response).HasMaxLength(500);
            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
