using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APISchool.Models.MonHoc
{
    public class MonHocRequest
    {
        public string TenMon { get; set; }

        public int TinChi { get; set; }
    }
}
