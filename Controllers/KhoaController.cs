using APISchool.Entity;
using APISchool.Models;
using APISchool.Models.Khoa;
using APISchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhoaController : Controller
    {
        private readonly IKhoaService khoaService;

        public KhoaController(IKhoaService khoaService)
        {
            this.khoaService = khoaService;
        }

        [HttpGet("GetAll")]
        public async Task<List<Khoa>> GetAll(int page =0 , int pagesize =5)
        {
            var result = await khoaService.GetAll(page, pagesize);
            return result;
        }

        [HttpGet("GetByID")]
        public async Task<Khoa> GetById(string makhoa)
        {
            return await khoaService.GetById(makhoa);
        }

        [HttpGet("GetByName")]
        public async Task<List<Khoa>> GetByName(string tenkhoa)
        {
            return await khoaService.GetByName(tenkhoa);
        }

        [HttpPost("Add")]
        public async Task<Khoa> AddKhoa(KhoaDTO khoaDTO)
        {
            var result = await khoaService.AddKhoa(khoaDTO);
            return result;
        }

        [HttpPut("Update")]
        public async Task<Khoa> UpdateKhoa(string makhoa, KhoaRequest khoaRequest)
        {
            var result = await khoaService.UpdateKhoa(makhoa, khoaRequest);
            return result;
        }

        [HttpDelete("Remove")]
        public async Task<Khoa> RemoveKhoa(string makhoa)
        {
            var result = await khoaService.RemoveKhoa(makhoa);
            return result;
        }
    }
}
