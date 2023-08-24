namespace Core.Entity
{
    public class TraineeProfileAdmin : BaseEntity /// Old trainee_experiences
    {
        public int Id { get; set; }

        public string? PhoneNo { get; set; }
        public string? fullName { get; set; }
        public string? ArabicName { get; set; }
        public bool Gender { get; set; }
        public string? IqamaNumber { get; set; }
        public string? EducationMajority { get; set; }
        public DateTime? Iqama_Expiry_Date { get; set; }
        public string? Address { get; set; }
        public string? CityName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public string? ProfilePic { get; set; } 
        public string? CV_CoverLetter { get; set; }
        public string? CV_Summery { get; set; }
        public string? CV_filePath { get; set; }
        public int Social_Duration { get; set; }
        public bool Social_Status_Id { get; set; }
        public string? Tamheir_Duration { get; set; }
        public string? Tamheir_Status_Id { get; set; }
        public string? tamheir_getting_status { get; set; }
        public bool license_State { get; set; }
        public string? Training_File_Path { get; set; }
        public bool Donation_Hours_Status { get; set; }
        public string? Donation_Hours_File_Path { get; set; }
        public string? GraduationFilePath { get; set; }
        public string? License_File { get; set; }
        public int? Tamher_getting_duration { get; set; }

        public ICollection<TraineeJob> TraineeJob { get; set; } = new List<TraineeJob>();
        public ICollection<TraineeExperience> TraineeExperience { get; set; } = new List<TraineeExperience>();
    }
}
