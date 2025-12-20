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

    }
}
