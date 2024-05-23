using Microsoft.EntityFrameworkCore;
using DTO;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DbSet<ProposalDTO> Proposals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:ggst-infohub.database.windows.net,1433;Initial Catalog=proposals;Persist Security Info=False;User ID=Zep;Password=Lansch99/E;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }

}
