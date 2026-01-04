using System.ComponentModel.DataAnnotations;

namespace BangHangAPI.ViewModels
{
    public class HangHoaModel
    {
        [Required]
        public string TenHangHoa { get; set; }

        public double DonGia { get; set; }


        public int MaLoai { get; set; }
    }
}
