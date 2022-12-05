using APISchool.Entity;
using APISchool.Helpers;
using APISchool.Models.Diem;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace APISchool.Services
{
    public interface IDiemService
    {
        Task<List<Diem>> GetAll(int page, int pagesize);
        Task<Diem> GetById(string madiem);
        Task<List<Diem>> GetMaSV(string masv);
        Task<List<Diem>> GetMaMon(string mamon);
        Task<List<Diem>> GetDiem(double diemthi);
        Task<Diem> AddDiem(DiemDTO diemDTO);
        Task<Diem> UpdateDiem(string madiem, DiemRequest diemRequest);
        Task<Diem> DeleteDiem(string madiem);
    }

    public class DiemService : IDiemService
    {
        private readonly DataContext dataContext;

        public DiemService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Diem> AddDiem(DiemDTO diemDTO)
        {
            Diem newDiem = new Diem();
            try
            {
                if (this.dataContext.Diems.Any(c => c.MaMon.Contains(diemDTO.MaMon)) && this.dataContext.Diems.Any(c => c.MaSV.Contains(diemDTO.MaSV)))
                {
                    return null;
                }
                else
                {
                    if (0 <= diemDTO.DiemThi && diemDTO.DiemThi <= 10)
                    {
                        newDiem.MaDiem = diemDTO.MaDiem;
                        newDiem.MaSV = diemDTO.MaSV;
                        newDiem.MaMon = diemDTO.MaMon;
                        newDiem.DiemThi = diemDTO.DiemThi;

                        this.dataContext.Add(newDiem);
                        await this.dataContext.SaveChangesAsync();
                    }
                }
                return newDiem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Diem> DeleteDiem(string madiem)
        {
            try
            {
                Diem existDiem = await this.GetById(madiem);
                if (existDiem != null)
                {
                    this.dataContext.Remove(existDiem);
                    await this.dataContext.SaveChangesAsync();
                }
                return existDiem;
            }
            catch { return null; }
        }

        public async Task<List<Diem>> GetAll(int page, int pagesize)
        {
            return await this.dataContext.Diems.Skip(page * pagesize).Take(pagesize).OrderBy(madiem => madiem.MaDiem).ToListAsync();
        }

        public async Task<Diem> GetById(string madiem)
        {
            return await this.dataContext.Diems.Where(c => c.MaDiem.Contains(madiem)).FirstAsync();
        }

        public async Task<List<Diem>> GetDiem(double diemthi)
        {
            return await this.dataContext.Diems.Where( c=> c.DiemThi == diemthi).ToListAsync(); 
        }

        public async Task<List<Diem>> GetMaMon(string mamon)
        {
            return await this.dataContext.Diems.Where( c=> c.MaMon == mamon).ToListAsync();
        }

        public async Task<List<Diem>> GetMaSV(string masv)
        {
            return await this.dataContext.Diems.Where(c=> c.MaSV == masv).ToListAsync();
        }

        public async Task<Diem> UpdateDiem(string madiem, DiemRequest diemRequest)
        {
            Diem existDiem = await this.GetById(madiem);
            try
            {
                if (existDiem != null && diemRequest.DiemThi >= 0 && diemRequest.DiemThi <= 10)
                {
                    existDiem.MaSV = diemRequest.MaSV;
                    existDiem.MaMon = diemRequest.MaMon;
                    existDiem.DiemThi = diemRequest.DiemThi;

                    this.dataContext.Update(existDiem);
                    await this.dataContext.SaveChangesAsync();
                }
                return existDiem;
            }
            catch { return null; }
        }
    }
}
