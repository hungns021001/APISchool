using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models.SinhVien
{
    public class SinhVienRequest
    {
        public DateTime NgaySinh { get; set; }

        public string GioiTinh { get; set; }

        public string QueQuan { get; set; }

        public string MaLop { get; set; }
    }
}
