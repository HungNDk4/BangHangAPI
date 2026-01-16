using BangHangAPI.Data;
using BangHangAPI.DTOs;
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
            if (request == null || !request.Items.Any() )
                throw new Exception("request không hợp lệ");

            if (request.Items == null)
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

                var OrderItem = new OrderItem
                {
                    HangHoaId = hanghoa.MaHangHoa,
                    Quantity = item.Quantity,
                    UnitPrice = hanghoa.DonGia
                };
                totalAmount += OrderItem.Quantity * OrderItem.UnitPrice;

                order.OrderItems.Add(OrderItem);

            }

            order.TotalAmount = totalAmount;

            // ===== 5. Lưu DB (1 lần duy nhất) =====
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;



        }




    }
}

