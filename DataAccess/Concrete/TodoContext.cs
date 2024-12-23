using Core.Helpers;
using Entity.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {

        }
        public TodoContext(DbContextOptions options) :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer(AppSettingsHelper.GetValue("SqlServerConnectionString",""),
                   providerOptions => { providerOptions.EnableRetryOnFailure(5); });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entidade in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propriedade in entidade.GetProperties())
                {
                    // datetime conversion
                    if (propriedade.Name == "CreatedOn" || propriedade.Name == "UpdatedOn")
                    {
                        propriedade.SetColumnType("datetime");
                    }
                }
            }
        }
        
        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientDiet> ClientDiet { get; set; }
        public DbSet<Diet> Diet { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
