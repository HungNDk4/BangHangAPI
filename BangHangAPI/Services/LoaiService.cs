namespace BangHangAPI.Services;
using BangHangAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;

public class LoaiService
{
    private readonly BanHangContext _context;
    public LoaiService(BanHangContext context) {  _context = context; }
    //method
    

    public List<Loai> GetAll() { 
     return _context.loais.ToList();

    }

    public Loai GetById(int Id)
    {

        return _context.loais.SingleOrDefault(l => l.MaLoai == Id);
    }

    public Loai Create(Loai Loai)
    {

        _context.loais.Add(Loai);
        _context.SaveChanges();
        return Loai;
    }

    public Loai Update(int Id, Loai LoaiEdit) {

        var loai = _context.loais.SingleOrDefault(l => l.MaLoai == Id);

        if (loai == null)
            return null;

        loai.TenLoai = LoaiEdit.TenLoai;

        _context.SaveChanges();

        return loai;


    }
    public bool Delete(int Id) {
        var Loai = _context.loais.SingleOrDefault( l => l.MaLoai == Id);

        if (Loai == null) return false;

        _context.loais.Remove(Loai);
        _context.SaveChanges();
        return true;
    
    }


    
    
    }


