using BelajarWebApi_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelajarWebApi_EntityFramework.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<FirstModel> Users { get; set; }
    }
}
