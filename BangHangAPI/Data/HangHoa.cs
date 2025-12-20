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
        public string TenHangHoa{ get; set; }
        public double DonGia { get; set; }

        [ForeignKey("MaLoai")]
        public Loai DanhmucSP { get; set; }
    }
}
