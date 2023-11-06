namespace DevicesAPI
{
    using Microsoft.EntityFrameworkCore;
    //Database context
    class DevicesDb : DbContext
    {
        public DevicesDb(DbContextOptions<DevicesDb> options) : base(options) { }
        public DbSet<Devices> Devices => Set<Devices>();
    }
}
