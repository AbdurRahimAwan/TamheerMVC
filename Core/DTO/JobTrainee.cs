namespace Core.Entity
{
    public class JobTrainee
    {
        public string UserID { get; set; }
        public string FullName { get; set; } = null!;
        public string Name { get; set; }
        public int CountRequiredToJob { get; set; }
        public bool IsDeleted { get; set; }
        public int JobId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InterViewDate { get; set; }
        public string Trainee_Address { get; set; }
        public string? jobState { get; set; }
        public string Majority { get; set; }
        public string CV_filePath { get; set; }
        public string? ProfilePic { get; set; }
        public string? GraduationFilePath { get; set; }

        public DateTime BirthDate { get; set; }
        public string? Donation_Hours_File_Path { get; set; }
        public bool Gender { get; set; }
        public string? IqamaNumber { get; set; }
        public string? License_File { get; set; }
    }
}
