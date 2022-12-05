using APISchool.Entity;
using APISchool.Models.Diem;
using APISchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiemController : Controller
    {
        private readonly IDiemService diemService;

        public DiemController(IDiemService diemService) 
        {
            this.diemService = diemService;
        }

        [HttpGet("GetAll")]
        public async Task<List<Diem>> GetAll(int page = 0, int pagesize =5)
        {
            return await diemService.GetAll(page,pagesize);
        }

        [HttpGet("GetById")]
        public async Task<Diem> GetById(string madiem)
        {
            return await diemService.GetById(madiem);
        }

        [HttpGet("GetByMaSV")]
        public async Task<List<Diem>> GetMaSV(string masv)
        {
            return await diemService.GetMaSV(masv);
        }

        [HttpGet("GetByMaMon")]
        public async Task<List<Diem>> GetMaMon(string mamon)
        {
            return await diemService.GetMaMon(mamon);
        }

        [HttpGet("GetByDiem")]
        public async Task<List<Diem>> GetDiem(double diemthi)
        {
            return await diemService.GetDiem(diemthi);
        }

        [HttpPost("AddDiem")]
        public async Task<Diem> AddDiem(DiemDTO diemDTO)
        {
            return await diemService.AddDiem(diemDTO);
        }

        [HttpPut("UpdateDiem")]
        public async Task<Diem> UpdateDiem(string madiem, DiemRequest diemRequest)
        {
            return await diemService.UpdateDiem(madiem, diemRequest);
        }

        [HttpDelete("Delete")]
        public async Task<Diem> DeleteDiem(string madiem)
        {
            return await diemService.DeleteDiem(madiem);
        }
    }
}
