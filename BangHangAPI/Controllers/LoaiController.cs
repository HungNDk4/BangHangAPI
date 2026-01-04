using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BangHangAPI.Data;
using BangHangAPI.Services;

namespace BangHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        //private readonly BanHangContext _context;

        //public LoaiController(BanHangContext context)
        //{
        //    _context = context;
        //}


        private readonly LoaiService _service;
        
        public LoaiController(LoaiService service) { _service = service; }
        
        
        
        // 2. API Lấy tất cả danh sách loại
        // GET: api/Loai
        [HttpGet]
        public IActionResult GetAll()
        {
          
            var dsloai= _service.GetAll();

            return  Ok(dsloai);
        }

        [HttpPost]
        public IActionResult Create(Loai loaiMoi) { 
           var Loai = _service.Create(loaiMoi);
            return StatusCode(201, Loai);
      }

        // PUT: api/Loai/1 (Số 1 là id cần sửa)

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, Loai loaiEdit)
        {
            var Loai = _service.Update(id, loaiEdit);
            if(Loai != null)
            return NotFound();
                
            
            return Ok(Loai);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(int id) {
            // tìm id có có tồn tại 

            var success = _service.Delete(id);
            if(!success)
                return NotFound();
            return NoContent();
        }


    }
}
