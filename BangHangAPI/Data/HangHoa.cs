using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangHangAPI.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHangHoa { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenHangHoa { get; set; }

        public double DonGia { get; set; }

        // 1. Phải có dòng này để hứng số 1 (quan trọng)
        public int MaLoai { get; set; }

        // 2. Thêm dấu ? vào đây để bảo: "Cái này có thể rỗng, đừng bắt bẻ tao"
        [ForeignKey("MaLoai")]
        public Loai? DanhmucSP { get; set; }
    }
}