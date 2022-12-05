using APISchool.Entity;
using APISchool.Helpers;
using APISchool.Models;
using APISchool.Models.Khoa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public interface IKhoaService
    {
        Task<List<Khoa>> GetAll(int page, int pagesize);
        Task<Khoa> GetById(string makhoa);
        Task<List<Khoa>> GetByName(string tenkhoa);
        Task<Khoa> AddKhoa(KhoaDTO khoaDTO);
        Task<Khoa> UpdateKhoa(string makhoa, KhoaRequest khoaRequest);
        Task<Khoa> RemoveKhoa(string makhoa);

    }

    public class KhoaService : IKhoaService
    {
        private readonly DataContext dataContext;

        public KhoaService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Khoa> AddKhoa(KhoaDTO khoaDTO)
        {
            try
            {
                Khoa newkhoa = new Khoa();
                if (dataContext.Khoas.Any(a => a.TenKhoa == khoaDTO.TenKhoa) || khoaDTO.MaKhoa == null || khoaDTO.TenKhoa == null)
                {
                    return null ;
                }
                else
                {
                    newkhoa.MaKhoa = khoaDTO.MaKhoa;
                    newkhoa.TenKhoa = khoaDTO.TenKhoa;
                    this.dataContext.Add(newkhoa);
                    await this.dataContext.SaveChangesAsync();
                    return newkhoa;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Khoa>> GetAll(int page, int pagesize)
        {
            return await this.dataContext.Khoas
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(a => a.MaKhoa)
                .ToListAsync();
        }

        public async Task<Khoa> GetById(string makhoa)
        {
            try
            {
                Khoa existKhoa = new Khoa();
                if (makhoa != null)
                {
                    existKhoa = await this.dataContext.Khoas.Where(a => a.MaKhoa == makhoa).FirstAsync();
                }
                return existKhoa;
            }
            catch
            {
                return null ;
            }
        }

        public async Task<Khoa> UpdateKhoa(string makhoa, KhoaRequest khoaRequest)
        {
            try
            {
                Khoa updateKhoa = await this.GetById(makhoa);
                if (updateKhoa != null || khoaRequest.TenKhoa != null)
                {
                    updateKhoa.TenKhoa = khoaRequest.TenKhoa;
                    this.dataContext.Update(updateKhoa);
                    await this.dataContext.SaveChangesAsync();

                }
                return updateKhoa;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Khoa>> GetByName(string tenkhoa)
        {
            return await this.dataContext.Khoas.Where(b => b.TenKhoa.StartsWith(tenkhoa)).ToListAsync();
  
        }

        public async Task<Khoa> RemoveKhoa(string makhoa)
        {
            try
            {
                Khoa remove = new Khoa();
                if (makhoa != null)
                {
                    remove = await this.dataContext.Khoas.FindAsync(makhoa);
                    this.dataContext.Khoas.Remove(remove);
                    await this.dataContext.SaveChangesAsync();
                    return remove;
                }
                return remove;
            }
            catch
            {
                return null;
            } 
            
        }
    }
}
