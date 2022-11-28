using BloodBankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManagementSystem.database
{
    public class DonorContext:DbContext
    {
        public DonorContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DonorDetails> DonorDetails{ get; set; }
    }
}
