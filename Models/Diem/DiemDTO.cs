using APISchool.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models.Diem
{
    public class DiemDTO
    {
        [Key]
        public string MaDiem { get; set; }

        public string MaSV { get; set; }

        public string MaMon { get; set; }

        public double DiemThi { get; set; }
    }
}
