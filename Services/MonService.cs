using APISchool.Entity;
using APISchool.Helpers;
using APISchool.Models;
using APISchool.Models.MonHoc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public interface IMonService
    {
        Task<List<MonHoc>> GetAll(int page, int pagesize);
        Task<MonHoc> GetById(string mamon);
        Task<List<MonHoc>> GetByTinChi(int tinchi, int page, int pagesize);
        Task<List<MonHoc>> GetByMon(string tenmon, int pgae,int pagesize);
        Task<MonHoc> AddMon(MonHocDTO monHocDTO);
        Task<MonHoc> UpdateMon(string mamon, MonHocRequest monHocRequest);
        Task<MonHoc> DeleteMon(string mamon);
    }
    public class MonService : IMonService
    {
        private readonly DataContext dataContext;

        public MonService(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }

        public async Task<MonHoc> AddMon(MonHocDTO monHocDTO)
        {
            MonHoc newMon = new MonHoc();
            try
            {
                if (this.dataContext.MonHocs.Any(c => c.MaMon == monHocDTO.MaMon) && monHocDTO.TinChi < 0)
                {
                    return newMon = null;
                }
                else
                {
                    newMon.MaMon = monHocDTO.MaMon;
                    newMon.TenMon = monHocDTO.TenMon;
                    newMon.TinChi = monHocDTO.TinChi;

                    this.dataContext.MonHocs.Add(newMon);
                    await this.dataContext.SaveChangesAsync();
                    return newMon;
                }
            }
            catch
            {
                return null;
            }
}

        public async Task<MonHoc> DeleteMon(string mamon)
        {
            try
            {
                MonHoc existMon = await this.GetById(mamon);
                if(existMon != null)
                {
                    this.dataContext.Remove(existMon);
                    await this.dataContext.SaveChangesAsync();
                }
                return existMon;
            }
            catch
            { return null; }
        }

        public async Task<List<MonHoc>> GetAll(int page, int pagesize)
        {
            return await this.dataContext.MonHocs
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(c => c.MaMon)
                .ToListAsync();
        }

        public async Task<MonHoc> GetById(string mamon)
        {
            try
            {
                MonHoc existMon = new MonHoc();
                if(mamon != null)
                {
                    existMon = await this.dataContext.MonHocs.Where(c=> c.MaMon.Contains(mamon)).FirstAsync();
                    
                }
                return existMon;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<MonHoc>> GetByMon(string tenmon, int page, int pagesize)
        {
            return await this.dataContext.MonHocs
                .Where(c => c.TenMon.StartsWith(tenmon))
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(c => c.MaMon)
                .ToListAsync();
        }

        public async Task<List<MonHoc>> GetByTinChi(int tinchi, int page, int pagesize)
        {
            return await this.dataContext.MonHocs
                .Where(c => c.TinChi == tinchi)
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(c => c.MaMon)
                .ToListAsync();
        }

        public async Task<MonHoc> UpdateMon(string mamon, MonHocRequest monHocRequest)
        {
            MonHoc existMon = await this.GetById(mamon);
            try
            {
                if (existMon != null && monHocRequest.TinChi >= 0)
                {
                    existMon.TenMon = monHocRequest.TenMon;
                    existMon.TinChi = monHocRequest.TinChi;
                    this.dataContext.Update(existMon);
                    await this.dataContext.SaveChangesAsync();
                }
                return existMon;
            }
            catch
            {
                return null;
            }
        }
    }
}
