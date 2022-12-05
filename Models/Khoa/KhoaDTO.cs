using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models.Khoa
{


    public class KhoaDTO
    {
        [Key]
        [Display(Name = "Mã Khoa")]
        public string MaKhoa { get; set; }

        [Required]
        [Display(Name = "Tên Khoa")]
        [MaxLength(100)]
        public string TenKhoa { get; set; }
    }
}
