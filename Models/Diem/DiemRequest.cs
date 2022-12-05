using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models.Diem
{
    public class DiemRequest
    {
        public string MaSV { get; set; }

        public string MaMon { get; set; }

        public double DiemThi { get; set; }
    }
}
