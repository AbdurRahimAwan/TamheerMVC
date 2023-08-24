using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
    {
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {

            Property(x => x.FullName).HasMaxLength(200)
                     .IsRequired();
            //Property(x => x.UniqueId).ValueGeneratedOnAdd();
            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
