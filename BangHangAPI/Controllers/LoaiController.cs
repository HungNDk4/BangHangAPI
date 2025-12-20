using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BangHangAPI.Data;

namespace BangHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly BanHangContext _context;

        public LoaiController(BanHangContext context)
        {
            _context = context;
        }
        // 2. API Lấy tất cả danh sách loại
        // GET: api/Loai
        [HttpGet]
        public IActionResult GetAll()
        {
            //logic vào DB => lấy bảng loại -> chuyển thành list 
            var dsloai= _context.loais.ToList();

            return  Ok(dsloai);
        }

        [HttpPost]
        public IActionResult Create(Loai loai) { 
           _context.loais.Add(loai);

            _context.SaveChanges();
            return StatusCode(201, loai);
        
        
      }
        // PUT: api/Loai/1 (Số 1 là id cần sửa)
        [HttpPut("{id}")] // cần id thì mới update đc 
        public IActionResult UpdateLoaiById(int id, Loai loaiEdit)
        {
            // Tìm xem có cái loại đó trong kho không?
            var loaiCanSua = _context.loais.SingleOrDefault(loai => loai.MaLoai == id);

            // Nếu tìm không thấy -> Báo lỗi 404 Not Found
            if (loaiCanSua == null)
            {
                return NotFound();
            }

            // Bước 2: Nếu thấy -> Sửa thông tin
            loaiCanSua.TenLoai = loaiEdit.TenLoai;

            // Bước 3: Lưu thay đổi
            _context.SaveChanges();

            return Ok(loaiCanSua); // Trả về cục đã sửa xong
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(int id) {
            // tìm id có có tồn tại 

            var LoaiCanXoa = _context.loais.SingleOrDefault(xoa => xoa.MaLoai == id);
            if (LoaiCanXoa == null)
            {
                return NotFound();
            }

            //thuc hien xoa
            _context.loais.Remove(LoaiCanXoa);
            //save
            _context.SaveChanges();

            return StatusCode(200);
        }


    }
}
