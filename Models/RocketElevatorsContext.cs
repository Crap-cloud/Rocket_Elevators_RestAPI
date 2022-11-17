using Microsoft.EntityFrameworkCore;

namespace Rocket_Elevators_Rest_API.Models
{
    public class RocketElevatorsContext : DbContext
    {
        public RocketElevatorsContext(DbContextOptions<RocketElevatorsContext> options)
            : base(options)
        {
        }

        public DbSet<Battery> batteries { get; set; } = null!;
        public DbSet<Column> column { get; set; } = null!;
        public DbSet<Elevator> elevator { get; set; } = null!;




    }
}
