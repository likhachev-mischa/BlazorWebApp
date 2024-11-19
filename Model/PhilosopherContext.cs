using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class PhilosopherContext : DbContext
    {
        public PhilosopherContext()
        {
		//	Database.EnsureDeleted();
			Database.EnsureCreated();
        }

        public DbSet<Philosopher> Philosophers { get; set; } = null!;
        public DbSet<Philosophy> Philosophies { get; set; } = null!;

        public DbSet<Country> Countries { get; set; }
        public DbSet<PhilosopherPhilosophyConnection> PhilosopherPhilosophiesConnections { get; set; } = null!;
        public DbSet<PhilosopherCountryConnection> PhilosopherCountryConnections { get; set; }

        public DbSet<PhilosopherStudentConnection> PhilosopherStudentConnections { get; set; }

        public DbSet<Work> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PhilosophersDB;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}