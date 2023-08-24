using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class JobDetails : BaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "اسم  وظيفي")]
        public string? Name { get; set; } = null!;
        [Display(Name = "اسم وظيفي")]
        public string? Department { get; set; }
        [Display(Name = "التعليم المطلوب")]
        public string? Education { get; set; }
        [Display(Name = "الوظيفة المطلوبة الخبرة")]
        public string? Experience { get; set; }
        [Display(Name = "الاسم الوظيفي")]
        public string? Notes { get; set; }
        [Display(Name = "تفاصيل الوظيفة")]
        public string? ExplaningOfTranningTask { get; set; }
        [Display(Name = "منسق العمل")]
        public string? Coordinator { get; set; }
        [Display(Name = "مشرف العمل")]
        public string? Supervisor { get; set; }
        [Display(Name = "حالة تطبيق المتدرب")]
        public string? traineeStatus { get; set; }
        [Display(Name = "تطبيق المتدرب")]
        public int? TraineeCount { get; set; }
        [Display(Name = "المتدرب المطلوب")]
        public int? CountRequiredToJobs { get; set; }
        [Display(Name = "تاريخ النشر")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "اخر موعد")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "موعد المقابلة")]
        public DateTime? interviewDate { get; set; }

        public ICollection<TraineeRows> TraineeRows { get; set; } = new List<TraineeRows>();
    }
}
