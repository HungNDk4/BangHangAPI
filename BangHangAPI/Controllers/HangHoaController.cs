    using BangHangAPI.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
using BangHangAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using BangHangAPI.Services;

namespace BangHangAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly HangHoaService _service;

        public HangHoaController(HangHoaService service)
        {
            _service = service;
        }
        //bản cũ
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsHangHoa = _service.GetAll();
            return Ok(dsHangHoa);
        }

        // bảng mới
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{

        //    var danhSach = await _context.hanghoa
        //        .Select(hh => new HangHoaVM
        //        {
        //            TenHangHoa = hh.TenHangHoa, 
        //            DonGia = hh.DonGia,         
        //            TenLoai = hh.DanhmucSP.TenLoai 
        //        })
        //        .ToListAsync(); 

        //    return Ok(danhSach);
        //}



        [HttpGet("{id}")]
        public IActionResult GetbyId(int id) {
            var hanghoa = _service.GetById(id);

            if (hanghoa == null) {
                return NotFound();
            }

            return Ok(hanghoa);
        }

        [HttpPost]
        public IActionResult Create(HangHoa hangHoa)
        {
            var Hanghoa = _service.Create(hangHoa);
            return StatusCode(201, Hanghoa);
        }

        // sửa hàng hoá 
        //Put/api/1

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, HangHoa hangHoaEdit) {

            var hanghoa = _service.Update(id, hangHoaEdit);

            if (hanghoa == null)
                return NotFound();

            return Ok(hanghoa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var hanghoa = _service.Delete(id);
            if (!hanghoa)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(string keyword) { 
        var result = _service.Search(keyword);
        
            return Ok(result);
        }
            


        }

    }
