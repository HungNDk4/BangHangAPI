using BangHangAPI.Data;
using BangHangAPI.DTOs;
using BangHangAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace BangHangAPI.Services
{
    public class OrderService
    {
        private readonly BanHangContext _context;
        public OrderService(BanHangContext context)
        {

            _context = context;
        }

        public Order CreateOrder(CreateOrderRequest request)
        {
            // 1. check request
            if (request == null || request.Items == null )
                throw new Exception("request không hợp lệ");

            if (!request.Items.Any())
                throw new Exception("Đơn hàng phải có ít nhất 1 sản phẩm");
            // tạo Order
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending,
                UserId = request.UserId
            };

            decimal totalAmount = 0;


            foreach (var item in request.Items)
            {
                var hanghoa = _context.hanghoa.SingleOrDefault(h => h.MaHangHoa == item.HangHoaId);
                //kiểm tra tồn tại 
                if (hanghoa == null)
                    throw new Exception($"Sản phẩm {item.HangHoaId} không tồn tại ");
                //kiểm tra số lượng
                if (item.Quantity <= 0)
                    throw new Exception("Số lượng phải lớn hơn 0");

                //kiểm tra tồn kho
                if (item.Quantity > hanghoa.SoLuongTon)
                    throw new Exception("Không đủ tồn kho");

                var orderItem = new OrderItem
                {
                    HangHoaId = hanghoa.MaHangHoa,
                    Quantity = item.Quantity,
                    UnitPrice = hanghoa.DonGia
                };
                totalAmount += orderItem.Quantity * orderItem.UnitPrice;

                order.OrderItems.Add(orderItem);

            }

            order.TotalAmount = totalAmount;

            // ===== 5. Lưu DB (1 lần duy nhất) =====
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;



        }

        public void ConfirmOrder(int OrderId)
        {
            var order = _context.Orders.Include(oi=> oi.OrderItems).SingleOrDefault(h=> h.OrderId == OrderId);

            if(order == null)
                throw new Exception("Đơn hàng không tồn tại ");

            if (order.Status != OrderStatus.Pending)
                throw new Exception("chỉ đc thể comfirm đc đơn hàng ở trạng thái pending");

            //check tồn kho
            foreach (var item in order.OrderItems)
            {
                 var hangHoa = _context.hanghoa
            .SingleOrDefault(h => h.MaHangHoa == item.HangHoaId);

        if (hangHoa == null)
            throw new Exception("Sản phẩm không tồn tại");

        if (item.Quantity > hangHoa.SoLuongTon)
            throw new Exception($"Không đủ tồn kho cho sản phẩm {hangHoa.TenHangHoa}");
            }

            // trừ tồn kho
            foreach (var item in order.OrderItems)
            {
                var hangHoa = _context.hanghoa
                    .Single(h => h.MaHangHoa == item.HangHoaId);

                hangHoa.SoLuongTon -= item.Quantity;
            }

            order.Status = OrderStatus.Confirmed;

            _context.SaveChanges();



        }

        public void CancelOrder(int OrderId) { 
        var Order = _context.Orders.SingleOrDefault(o => o.OrderId == OrderId);

            if (Order == null)
                throw new Exception("đơn hàng không tồn tại");

            if (Order.Status != OrderStatus.Pending)
                throw new Exception("chỉ có thể huỷ đơn hàng ở trạng thái pending");

            Order.Status = OrderStatus.Canceled;

            _context.SaveChanges();

        
        
        }





    }
}

