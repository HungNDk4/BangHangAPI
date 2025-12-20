using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangHangAPI.Data
{
    [Table("loai") ] // ten bang trong sql server
    public class Loai
    {
        [Key] //primary key 
        public int MaLoai { get; set; }
        [Required]// bat buoc nhap ko de trong
        [MaxLength(50)] // do dai toi da la 50
        public String TenLoai { get; set; }
    }
}
