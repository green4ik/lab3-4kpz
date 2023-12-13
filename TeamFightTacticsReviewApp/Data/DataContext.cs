using Microsoft.EntityFrameworkCore;
using TeamFightTacticsReviewApp.Models;

namespace TeamFightTacticsReviewApp.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }
        /*public DbSet<Category> Categories { get; set; }*/
        public DbSet<Tactic> Tactics { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Champion> Champions { get; set; }

       
    }
}
