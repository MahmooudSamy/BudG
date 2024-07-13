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

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(q => q.QuestionId);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(a => a.AnswerId);
            });

            //modelBuilder.Entity<Question>().HasMany<Answer>().WithOne().HasForeignKey(a => a.QuestionId);

            //modelBuilder.Entity<Question>()
            //    .HasMany(q => q.Answers)
            //    .WithOne(a => a.Question)
            //    .HasForeignKey(a => a.QuestionId);

            //modelBuilder.Entity<Question>()
            //.HasMany(q => q.Answers)
            //.WithOne(a => a.Question)
            //.HasForeignKey(a => a.QuesId);

            //    modelBuilder.Entity<Answer>()
            //.HasOne(a => a.Question)
            //.WithMany(q => q.Answers)
            //.HasForeignKey(a => a.QuesId);

            modelBuilder.Entity<User>().
                HasOne(u => u.Answer).
                WithOne(a => a.User).HasForeignKey<Answer>(a => a.UserId);

            modelBuilder.Entity<Question>().HasData(
                new Question { QuestionId = 1, QuestionShape = "What was the name of your first school teacher?" },
                new Question { QuestionId = 2, QuestionShape = "What year did you enter college?" },
                new Question { QuestionId = 3, QuestionShape = "What is your grandmother’s maiden name?" },
                new Question { QuestionId = 4, QuestionShape = "How old are you?" },
                new Question { QuestionId = 5, QuestionShape = "What is your child’s nickname?" },
                new Question { QuestionId = 6, QuestionShape = "What is the manufacturer of your first car?" },
                new Question { QuestionId = 7, QuestionShape = "What was the name of your favorite childhood pet?" },
                new Question { QuestionId = 8, QuestionShape = "What is your favorite sport?" },
                new Question { QuestionId = 9, QuestionShape = "In which area of the city is your place of work located?" }
                );

            
        }
    }
}
