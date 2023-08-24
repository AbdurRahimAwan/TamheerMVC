using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class TraineeProfile : BaseEntity /// Old trainee_experiences
    {
        public int Id { get; set; }

        #region Missing User Profile  Data
        public string? PhoneNo { get; set; }
        public int EducationMajorityId { get; set; }
        //public Nationality? Nationality { get; set; }
        //public int NationalityId { get; set; }
        public bool Gender { get; set; }

        [Index("IX_IqamaNumber", IsUnique = true)]
        public string IqamaNumber { get; set; } = null!;
        public string ArabicName { get; set; } = null!;
        public string EnglishName { get; set; } = null!;

        public DateTime? Iqama_Expiry_Date { get; set; }

        public string Address { get; set; } = null!;
        public int CityId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public string ProfilePic { get; set; } = null!;
        public string? CV_CoverLetter { get; set; }

        #endregion
        public string? CV_Summery { get; set; }
        public string? CV_filePath { get; set; }
        public int Trainee_Id { get; set; }
        public int Social_Duration { get; set; }
        public bool Social_Status_Id { get; set; }
        public int Tamheir_Duration { get; set; }
        public bool Tamheir_Status_Id { get; set; }
        public bool tamheir_getting_status { get; set; }
        public bool license_State { get; set; }
        public TamheirStatus? TamheirStatus { get; set; }
        public int TamheirStatusId { get; set; }
        public Experience? Experience { get; set; }
        [ForeignKey("Experience")]
        public int? ExpId { get; set; } = null;
        public string? Training_File_Path { get; set; }

        public bool Donation_Hours_Status { get; set; }

        public string? Donation_Hours_File_Path { get; set; }
        public string? GraduationFilePath { get; set; }
        public string? License_File { get; set; }
        public MaritalState? MaritalState { get; set; }
        [ForeignKey("MaritalState")]
        public int MaritalStatesId { get; set; }
        // عدد المدد السابقة بالايام
        public int? Tamher_getting_duration { get; set; }
        public string? Eqrar { get; set; }
        public ApplicationUser? User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; } = null!;

        public ICollection<TraineeJob> TraineeJob { get; set; } = new List<TraineeJob>();

    }
}
