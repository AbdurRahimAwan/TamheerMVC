using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Core.Configutration
{
    public class ConfigrationEntityTraineeProfile : EntityTypeConfiguration<TraineeProfile>
    {
        public ConfigrationEntityTraineeProfile()
        {

            Property(x => x.ArabicName).HasMaxLength(500)
                 .IsRequired();
            Property(x => x.EnglishName).HasMaxLength(500)
                 .IsRequired();

            Property(x => x.Address).HasMaxLength(500)
                 .IsRequired();
            Property(x => x.Donation_Hours_File_Path).HasMaxLength(500);
            Property(x => x.ProfilePic).HasMaxLength(500);
            Property(x => x.CV_CoverLetter).HasMaxLength(500);
            Property(x => x.CV_filePath).HasMaxLength(500)
               .IsRequired();
            Property(x => x.CV_Summery).HasMaxLength(500);
            Property(x => x.GraduationFilePath).HasMaxLength(500);
            Property(x => x.License_File).HasMaxLength(500);

            Property(x => x.PhoneNo).HasMaxLength(50)
            .IsRequired();
            Property(x => x.IqamaNumber).HasMaxLength(100)
           .IsRequired();
            Property(x => x.CreatedOn).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.IsDeleted).IsRequired().HasColumnAnnotation("Default", false);
        }
    }
}
