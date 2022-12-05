using APISchool.Entity;
using APISchool.Models;
using APISchool.Models.MonHoc;
using APISchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonController : Controller
    {
        private readonly IMonService monService;

        public MonController(IMonService monService)
        {
            this.monService = monService;
        }

        [HttpGet("GetAll")]
        public async Task<List<MonHoc>> GetAll(int page=0, int pagesize =5)
        {
            return await monService.GetAll(page, pagesize);
        }

        [HttpGet("GetByID")]
        public async Task<MonHoc> GetById(string mamon)
        {
            var result = await monService.GetById(mamon);
            return result;
        }

        [HttpGet("GetByTinChi")]
        public async Task<List<MonHoc>> GetByTinChi(int tinchi, int page =0, int pagesize =5)
        {
            return await monService.GetByTinChi(tinchi, page, pagesize);
        }

        [HttpGet("GetByMon")]
        public async Task<List<MonHoc>> GetByMon(string tenmon, int page=0, int pagesize =5)
        {
            return await monService.GetByMon(tenmon, page, pagesize);
        }

        [HttpPost("Add")]
        public async Task<MonHoc> AddMon(MonHocDTO monHocDTO)
        {
            var result = await monService.AddMon(monHocDTO);
            return result;
        }

        [HttpPut("Update")]
        public async Task<MonHoc> UpdateMon(string mamon, MonHocRequest monHocRequest)
        {
            return await monService.UpdateMon(mamon, monHocRequest); 
        }

        [HttpDelete("Delete")]
        public async Task<MonHoc> DeleteMon(string mamon)
        {
            return await monService.DeleteMon(mamon);
        }
    }
}
