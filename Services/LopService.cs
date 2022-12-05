using APISchool.Entity;
using APISchool.Helpers;
using APISchool.Models.Lop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public interface ILopService
    {
        Task<List<Lop>> GetAll(int page, int pagesize);
        Task<Lop> GetById(string malop);
        Task<List<Lop>> GetByName(string tenlop);
        Task<List<Lop>> GetByMaKhoa(string makhoa, int page, int pagesize);
        Task<Lop> AddLop(LopDTO lopDTO);
        Task<Lop> UpdateLop(string malop, LopRequest lopRequest);
        Task<Lop> DeleteLop(string malop);
    }
    public class LopService : ILopService
    {
        private readonly DataContext dataContext;

        public LopService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Lop> AddLop(LopDTO lopDTO)
        {
            Lop newLop = new Lop();
            if (this.dataContext.Lops.Any(c => c.TenLop.Contains(newLop.TenLop)) && lopDTO.SiSo <0)
            {
                return null;
            }
            else
            {
                newLop.MaLop = lopDTO.MaLop;
                newLop.TenLop = lopDTO.TenLop;
                newLop.SiSo = lopDTO.SiSo;
                newLop.MaKhoa = lopDTO.MaKhoa;

                this.dataContext.Lops.Add(newLop);
                await this.dataContext.SaveChangesAsync();
                return newLop;
            }    
        }

        public async Task<Lop> DeleteLop(string malop)
        {
            try
            {
                Lop existLop = await this.GetById(malop);
                if (existLop != null)
                {
                    this.dataContext.Remove(existLop);
                    await this.dataContext.SaveChangesAsync();
                }
                return existLop;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Lop>> GetAll(int page, int pagesize)
        {
            return await this.dataContext.Lops
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(x => x.MaLop)
                .ToListAsync();
        }

        public async Task<Lop> GetById(string malop)
        {
            Lop existLop = new Lop();
            if(malop != null)
            {
                existLop = await this.dataContext.Lops.Where(c => c.MaLop.Contains(malop)).FirstAsync();
                return existLop;
            }
            return existLop;
        }

        public async Task<List<Lop>> GetByMaKhoa(string makhoa, int page, int pagesize)
        {
            return await this.dataContext.Lops
                .Where( c=> c.MaKhoa == makhoa )
                .Skip(page*pagesize)
                .Take(pagesize)
                .OrderBy(x => x.MaLop)
                .ToListAsync();
        }

        public async Task<List<Lop>> GetByName(string tenlop)
        {
            return await this.dataContext.Lops.Where( c=> c.TenLop.StartsWith(tenlop)).ToListAsync();
        }

        public async Task<Lop> UpdateLop(string malop, LopRequest lopRequest)
        {
            try
            {
                Lop newlop = await this.GetById(malop);
                if ((newlop != null || lopRequest.TenLop != null) && lopRequest.SiSo >=0 )
                {
                    newlop.TenLop = lopRequest.TenLop;
                    newlop.SiSo = lopRequest.SiSo;
                    newlop.MaKhoa= lopRequest.MaKhoa;
                    this.dataContext.Update(newlop);
                    await this.dataContext.SaveChangesAsync();
                }
                return newlop;
            }
            catch
            {
                return null;
            }
        }
    }
}
