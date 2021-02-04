using HellowWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HellowWorld.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  { }
 
        public DbSet<Charecter> charecters { get; set; }
    }
}