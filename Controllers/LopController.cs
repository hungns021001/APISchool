using APISchool.Entity;
using APISchool.Helpers;
using APISchool.Models.Lop;
using APISchool.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace APISchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LopController : Controller
    {
        private readonly ILopService lopService;
        private readonly DataContext dataContext;

        public LopController(ILopService lopService, DataContext dataContext)
        {
            this.lopService = lopService;
            this.dataContext = dataContext;
        }

        [HttpGet("GetAll")]
        public async Task<List<Lop>> GetAll(int page = 0, int pagesize =5)
        {
            var result = await lopService.GetAll(page, pagesize);
            return result;
        }

        [HttpGet("GetByMaLop")]
        public async Task<Lop> GetById(string malop)
        {
            var result = await lopService.GetById(malop);
            return result;
        }

        [HttpGet("GetByName")]
        public async Task<List<Lop>> GetByName(string tenlop)
        {
            return await lopService.GetByName(tenlop);
        }

        [HttpGet("GetByMaKhoa")]
        public async Task<List<Lop>> GetByMaKhoa (string makhoa, int page =0, int pagesize =5)
        {
            return await lopService.GetByMaKhoa(makhoa, page, pagesize);
        }

        [HttpPost("AddLop")]
        public async Task<Lop> AddLop(LopDTO lopDTO)
        {
            var result = await lopService.AddLop(lopDTO);
            return result;
        }

        [HttpPut("UpdateLop")]
        public async Task<Lop> UpdateLop(string malop, LopRequest lopRequest)
        {
            var result = await lopService.UpdateLop(malop, lopRequest);
            return result;
        }

        [HttpDelete("Remove")]
        public async Task<Lop> DeleteLop(string malop)
        {
            var result = await lopService.DeleteLop(malop);
            return result;
        }
        
    }
}
