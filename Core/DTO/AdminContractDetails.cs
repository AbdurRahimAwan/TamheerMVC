using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class AdminContractDetails : BaseEntity
    {
        public int Id { get; set; }
        [Display(Name= "اسم المتدرب")]
        public string? contractFor { get; set; }
        [Display(Name= "التعاقد من قبل")]
        public string? ContractBy { get; set; }
        [Display(Name= "تاريخ بدء العقد")]
        public DateTime? startDate { get; set; }
        [Display(Name= "تاريخ انتهاء العقد")]
        public DateTime? EndDate { get; set; }
        [Display(Name= "الأحكام والشروط")]
        public bool? AcceptContract { get; set; }
        [Display(Name= "عنوان العقد")]
        public string? Name { get; set; }
        [Display(Name= "اسم القسم")]
        public string? DepartmentName { get; set; }
        [Display(Name= "تفاصيل العقد")]
        public string? Details { get; set; }
        [Display(Name= "اسم العمل")]
        public string? JobName { get; set; }
        [Display(Name= "إرفاق العقد")]
        public string? Attachment { get; set; }

        [Display(Name= "مدة العقد")]
        public string? ContractDuration { get; set; }
        [Display(Name= "حالة التعاقد")]
        public string? ContractStatus { get; set; }
        public string? ContractStatusColor { get; set; }

    }
}
