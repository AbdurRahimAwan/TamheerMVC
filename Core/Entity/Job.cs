using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class Job : BaseEntity
    {
        
        public int Id { get; set; }
        [Display(Name = "عنوان الفرصة")]
        public string Name { get; set; } = null!;
        [Display(Name = "ملاحظات اخري")]
        public string? Notes { get; set; }
        [Display(Name = "العدد الأقصي للحصول علي الفرصة")]
        public int CountRequiredToJobs { get; set; }
        [Display(Name = "تاريخ بداية التقديم"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاريخ نهاية التقديم"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "تاريخ المقابلة الشخصية"), DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InterViewDate { get; set; }
        [Display(Name = "رابط الفرصة علي جوجل")]
        public string GoogleMapLink { get; set; } = null!;
        [Display(Name = "تفاصيل وشرح المهمة")]
        public string ExplaningOfTranningTask { get; set; } = null!;
        public JobsStatus? JobStatus { get; set; }
        public int? JobStatusId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("Department")]
        public int? DepId { get; set; } = null;
        public Experience? Experience { get; set; }
        [ForeignKey("Experience")]
        public int? ExpId { get; set; } = null;

        [ForeignKey("EducationMajority")]
        public int? EducId { get; set; } = null;
        public Education? EducationMajority { get; set; }
        public ICollection<TraineeJob> TraineeJob { get; set; } = new List<TraineeJob>();
    }
}
