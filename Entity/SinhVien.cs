using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISchool.Entity
{
    public class SinhVien
    {
        [Key]
        [Required]
        public string MaSV { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Tên sinh viên")]
        public string TenSV { get; set; }

        [Required]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [MaxLength(200)]
        [Display(Name = "Quê quán")]
        public string QueQuan { get; set; }

        [Display(Name = "Mã lớp")]
        public string MaLop { get; set; }
        [ForeignKey("MaLop")]
        public Lop Lops { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
    }
}
