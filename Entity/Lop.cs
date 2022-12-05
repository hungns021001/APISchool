using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISchool.Entity
{
    public class Lop
    {
        [Key]
        [Required]
        [Display(Name = "Mã Lớp")]
        public string MaLop { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Tên Lớp")]
        public string TenLop { get; set; }

        [Display(Name ="Sĩ số")]
        public int SiSo { get; set; }

        [Display(Name ="Mã Khoa")]
        public string MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public Khoa Khoas { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
