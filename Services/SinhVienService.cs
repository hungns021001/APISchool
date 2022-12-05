using APISchool.Entity;
using APISchool.Helpers;
using APISchool.Models.SinhVien;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public interface ISinhVienService
    {
        Task<List<SinhVien>> GetAll(int page, int pagesize);
        Task<SinhVien> GetById(string masv);
        Task<List<SinhVien>> GetName(string name, int page, int pagesize);
        Task<List<SinhVien>> GetGender(string gioitinh, int page, int pagesize);
        Task<List<SinhVien>> GetQueQuan(string quequan, int page, int pagesize);
        Task<List<SinhVien>> GetMaLop(string malop, int page, int pagesize);
        Task<SinhVien> AddSinhVien(SinhVienDTO sinhVienDTO);
        Task<SinhVien> UpdateSinhVien(string masv, SinhVienRequest sinhVienRequest);
        Task<SinhVien> DeleteSinhVien(string masv);
    }

    public class SinhVienService : ISinhVienService
    {
        private readonly DataContext dataContext;

        public SinhVienService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<SinhVien> AddSinhVien(SinhVienDTO sinhVienDTO)
        {
            try
            {
                SinhVien newSV = new SinhVien();
                if (this.dataContext.SinhViens.Any(c => c.MaSV.Contains(sinhVienDTO.MaSV)) || sinhVienDTO.MaSV == null)
                {
                    return null;
                }
                else
                {
                    newSV.MaSV = sinhVienDTO.MaSV;
                    newSV.TenSV = sinhVienDTO.TenSV;
                    newSV.NgaySinh = sinhVienDTO.NgaySinh;
                    newSV.GioiTinh = sinhVienDTO.GioiTinh;
                    newSV.QueQuan = sinhVienDTO.QueQuan;
                    newSV.MaLop = sinhVienDTO.MaLop;

                    this.dataContext.Add(newSV);
                    await this.dataContext.SaveChangesAsync();

                    return newSV;

                }
            }
            catch { return null; }
        }

        public async Task<SinhVien> DeleteSinhVien(string masv)
        {
            try
            {
                SinhVien existSV = await this.GetById(masv);
                if (existSV != null)
                {
                    this.dataContext.Remove(existSV);
                    await this.dataContext.SaveChangesAsync();
                }
                return existSV;
            }
            catch { return null; }
        }

        public async Task<List<SinhVien>> GetAll(int page, int pagesize)
        {
            return await this.dataContext.SinhViens
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(c=>c.MaSV)
                .ToListAsync();
        }

        public async Task<SinhVien> GetById(string masv)
        {
            return await this.dataContext.SinhViens.Where(c => c.MaSV.Contains(masv)).FirstAsync();
        }

        public async Task<List<SinhVien>> GetGender(string gioitinh, int page, int pagesize)
        {
            return await this.dataContext.SinhViens
                .Where(c => c.GioiTinh.Contains(gioitinh))
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(c => c.MaSV)
                .ToListAsync();
        }

        public async Task<List<SinhVien>> GetMaLop(string malop, int page, int pagesize)
        {
            return await this.dataContext.SinhViens
                .Where(c => c.MaLop.Contains(malop))
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(c => c.MaSV)
                .ToListAsync();
        }

        public async Task<List<SinhVien>> GetName(string name, int page, int pagesize)
        {
            return await this.dataContext.SinhViens
                .Where(c => c.TenSV.StartsWith(name))
                .Skip(page * pagesize)
                .Take(pagesize)
                .OrderBy(c => c.MaSV)
                .ToListAsync();
        }

        public async Task<List<SinhVien>> GetQueQuan(string quequan, int page, int pagesize)
        {
            return await this.dataContext.SinhViens.Where(c => c.QueQuan.Contains(quequan)).ToListAsync();
        }

        public async Task<SinhVien> UpdateSinhVien(string masv, SinhVienRequest sinhVienRequest)
        {
            try
            {
                SinhVien existSV = await this.GetById(masv);
                if (sinhVienRequest.NgaySinh < DateTime.Now || existSV != null)
                {
                    existSV.NgaySinh = sinhVienRequest.NgaySinh;
                    existSV.GioiTinh = sinhVienRequest.GioiTinh;
                    existSV.QueQuan = sinhVienRequest.QueQuan;
                    existSV.MaLop = sinhVienRequest.MaLop;

                    this.dataContext.Update(existSV);
                    await this.dataContext.SaveChangesAsync();                
                }
                return existSV;
            }
            catch { return null; }
        }
    }
}
