using APISchool.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models.SinhVien
{

    public class SinhVienDTO 
    {
        [Key]
        [Required]
        public string MaSV { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Tên sinh viên")]
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
    }
}
