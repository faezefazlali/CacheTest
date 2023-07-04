
using Microsoft.EntityFrameworkCore;


namespace CacheTest.Domain
{
    public class DB : DbContext
    {

        public DB(DbContextOptions<DB> options) : base(options)
        {
        }


        #region Common
        //public DbSet<Book> Books { get; set; }


        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
