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

    


    }

}
