using BangHangAPI.Services;
using Microsoft.AspNetCore.Mvc;
using BangHangAPI.DTOs;

namespace BangHangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase

    {
        private readonly OrderService _service;

        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult CreateOrder(CreateOrderRequest request)
        {
            try
            {
                var order = _service.CreateOrder(request);
                return StatusCode(201, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/confirm")]
        public IActionResult ConfirmOrder(int id)
        {
            try
            {
                _service.ConfirmOrder(id);
                return Ok("Xác nhận đơn hàng thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{id}/cancel")]
        public IActionResult DeleteOrder(int id)
        {

            try
            {
                _service.CancelOrder(id);
                return Ok("huỷ đơn hàng thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }





        }
    }
}

