using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models.Lop
{
    public class LopRequest
    {
        public string TenLop { get; set; }

        public int SiSo { get; set; }

        public string MaKhoa { get; set; }
    }
}
