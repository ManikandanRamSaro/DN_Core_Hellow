using HellowWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HellowWorld.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  { }
 
        public DbSet<Charecter> charecters { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharecterSkill> CharecterSkills { get; set; }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)  // creating relationship between 2 more table --"OnModelCreating" -> this is case sensitive
        {
            modelBuilder.Entity<CharecterSkill>()
                .HasKey(ob => new { ob.CharecterId,ob.SkillId});
        }
    }
}