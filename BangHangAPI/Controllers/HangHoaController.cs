using BangHangAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly BanHangContext _context;
        public HangHoaController(BanHangContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() { 
        var dsHangHoa = _context.hanghoa.ToList();
        return Ok(dsHangHoa);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id) {
            var hanghoa = _context.hanghoa.FirstOrDefault(hh => hh.MaHangHoa == id);

            if (hanghoa == null) { 
                return NotFound();
            }
            // nếu thấy thì trả dữ liệu về 
            return Ok(hanghoa);
        }

        //them mới sản phầm
        [HttpPost]
        public IActionResult Create(HangHoa hanghoa) { 
             // thêm dữ liệu vào database
            _context.hanghoa.Add(hanghoa);
            // lưu thay đổi 
            _context.SaveChanges();

            return StatusCode(201, hanghoa);
               }
    


    }

}
