using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models
{
    public class MonHocDTO
    {
        [Key]
        [Display(Name = "Mã môn học")]
        public string MaMon { get; set; }

        [Required]
        [Display(Name = "Tên môn học")]
        [MaxLength(200)]
        public string TenMon { get; set; }

        [Display(Name = "Số tín chỉ")]
        public int TinChi { get; set; }
    }
}
