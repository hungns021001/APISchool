using System.ComponentModel.DataAnnotations;

namespace APISchool.Entity
{
    public class MonHoc
    {
        [Key]
        [Display(Name = "Mã môn học")]
        public string MaMon { get; set; }

        [Required]
        [Display(Name ="Tên môn học")]
        [MaxLength(200)]
        public string TenMon { get; set; }

        [Display(Name ="Số tín chỉ")]
        public int TinChi { get; set; }

        public virtual ICollection<Diem>? Diems { get; set; }
    }
}
