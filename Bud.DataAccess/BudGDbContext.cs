using BudG.Domain;
using Microsoft.EntityFrameworkCore;

namespace BudG.DataAccess
{
    public  class BudGDbContext: DbContext
    {
        public BudGDbContext()
        {

        }
        public BudGDbContext(DbContextOptions<BudGDbContext> options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=Budget;user id=sa;password=Allahisthe1;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<Question>().HasMany<Answer>().WithOne().HasForeignKey(a=>a.QuesId);

            modelBuilder.Entity<User>().
                HasOne<Answer>(u => u.Answer).
                WithOne(a => a.User).HasForeignKey<Answer>(a => a.UserId);

            
        }
    }
}
