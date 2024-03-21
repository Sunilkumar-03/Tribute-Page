using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_API.Entities;
namespace Tribute_API.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }


        //Store Context
        public DbSet<User> Users { get; set; }
        public DbSet<Tribute> Tributes { get; set; }
        public DbSet<TributeCategory> TributeCategories { get; set; }
        public DbSet<Approval> Approvals { get; set; }
        public DbSet<TributeLog> TributeLogs { get; set; }
        public DbSet<TributeRating> Ratings { get; set; }
    }
}
