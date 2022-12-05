using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISchool.Entity
{
    public class Diem
    {
        [Key]
        public string MaDiem { get; set; }

        [Required]
        public string MaSV { get; set; }

        [Display(Name = "Mã môn học")]
        public string MaMon { get; set; }

        [Display(Name ="Điểm thi")]
        [Required]
        public double DiemThi { get; set; }

        [ForeignKey("MaSV")]
        public SinhVien SinhViens { get; set; }

        [ForeignKey("MaMon")]
        public MonHoc MonHocs { get; set; }
    }
}
