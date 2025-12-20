using Microsoft.EntityFrameworkCore;

namespace BangHangAPI.Data
{
    public class BanHangContext :DbContext
    {
        public BanHangContext(DbContextOptions<BanHangContext> options) :base(options) { 
        
        }
        #region Dbset - bien class thanh bang
        // khai bao quan li bang loai
        public DbSet<Loai> loais { get; set; }

        //khai bao quan li bang HangHoa

        public DbSet<HangHoa> hanghoa { get; set; }
        #endregion



    }
}
