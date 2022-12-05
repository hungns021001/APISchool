using APISchool.Entity;
using APISchool.Models.SinhVien;
using APISchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinhVienController : Controller
    {
        private readonly ISinhVienService sinhVienService;

        public SinhVienController(ISinhVienService sinhVienService)
        {
            this.sinhVienService = sinhVienService;
        }

        [HttpGet("GetAll")]
        public async Task<List<SinhVien>> GetAll(int page = 0, int pagesize = 5)
        {
            return await sinhVienService.GetAll(page, pagesize);
        }

        [HttpGet("GetById")]
        public async Task<SinhVien> GetById(string masv)
        {
            return await sinhVienService.GetById(masv);
        }

        [HttpGet("GetName")]
        public async Task<List<SinhVien>> GetName(string name, int page = 0, int pagesize = 5)
        {
            return await sinhVienService.GetName(name, page, pagesize);
        }

        [HttpGet("GetGender")]
        public async Task<List<SinhVien>> GetGender(string gioitinh, int page = 0, int pagesize = 5)
        {
            return await sinhVienService.GetGender(gioitinh, page, pagesize);
        }

        [HttpGet("GetQueQuan")]             
        public async Task<List<SinhVien>> GetQueQuan(string quequan, int page = 0, int pagesize = 5)
        {
            return await sinhVienService.GetQueQuan(quequan, page, pagesize);
        }

        [HttpGet("GetMaLop")]
        public async Task<List<SinhVien>> GetMaLop(string malop, int page = 0, int pagesize = 5)
        {
            return await sinhVienService.GetMaLop(malop, page, pagesize);
        }

        [HttpPost("AddSV")]
        public async Task<SinhVien> AddSinhVien(SinhVienDTO sinhVienDTO)
        {
            return await sinhVienService.AddSinhVien(sinhVienDTO);
        }

        [HttpPut("UpdateSV")]
        public async Task<SinhVien> UpdateSinhVien(string masv, SinhVienRequest sinhVienRequest)
        {
            return await sinhVienService.UpdateSinhVien(masv, sinhVienRequest);
        }

        [HttpDelete("DeleteSV")]
        public async Task<SinhVien> DeleteSinhVien(string masv)
        {
            return await sinhVienService.DeleteSinhVien(masv);
        }
    }
}
