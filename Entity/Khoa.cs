using System.ComponentModel.DataAnnotations;

namespace APISchool.Entity
{
    public class Khoa
    {
        [Key]
        [Display(Name ="Mã Khoa")]
        public string MaKhoa { get; set; }

        [Required]
        [Display(Name ="Tên Khoa")]
        [MaxLength(100)]
        public string TenKhoa { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }
    }
}
