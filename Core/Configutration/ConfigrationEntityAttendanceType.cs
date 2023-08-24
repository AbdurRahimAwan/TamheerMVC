using Core.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Configutration
{
    public class ConfigrationEntityAttendanceType : EntityTypeConfiguration<AttendanceType>
    {
        public ConfigrationEntityAttendanceType() 
        {

            Property(x => x.AttendTypeName).HasMaxLength(100)
                 .IsRequired();

            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
