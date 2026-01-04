
namespace BangHangAPI.Services;
using BangHangAPI.Data;

public class HangHoaService
{

    private readonly BanHangContext _context;

    public HangHoaService(BanHangContext context) {
        _context = context;
    }
    //method

    public List<HangHoa> GetAll()
    { 
        return _context.hanghoa.ToList();
    }

    public HangHoa GetById(int id) {
        var hanghoa = _context.hanghoa.SingleOrDefault(hh=> hh.MaHangHoa == id);

        if (hanghoa == null) 
            return null;

        return hanghoa;
            }

    public HangHoa Create(HangHoa hangHoa) { 
        _context.hanghoa.Add(hangHoa);
        _context.SaveChanges();

        return hangHoa;
    }
    public HangHoa Update(int id,HangHoa hangHoaEdit) { 
        var HangHoa = _context.hanghoa.SingleOrDefault( hh => hh.MaHangHoa == id);

        if (HangHoa == null)
            return null;

        HangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
        HangHoa.DonGia = hangHoaEdit.DonGia;
        HangHoa.MaLoai = hangHoaEdit.MaLoai;
        _context.SaveChanges();
        return HangHoa;
    
    }
    public bool Delete(int id) { 
        var Hanghoa = _context.hanghoa.SingleOrDefault(hh=> hh.MaHangHoa == id);

        if(Hanghoa == null) return false;

        _context.hanghoa.Remove(Hanghoa);
        _context.SaveChanges();
        return true;
    }

    public List<HangHoa> Search(string Keyword) { 
    if(string.IsNullOrWhiteSpace(Keyword))
            return new List<HangHoa>();

    return _context.hanghoa.Where(hh=> hh.TenHangHoa.Contains(Keyword)).ToList();
    }




}




