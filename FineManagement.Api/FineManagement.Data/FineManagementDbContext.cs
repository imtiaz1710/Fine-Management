using FineManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FineManagement.Data
{
    public class FineManagementDbContext
    {
        public virtual DbSet<Fine>? Fines { get; set; }
        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Transaction>? Transactions { get; set; }
        public virtual DbSet<Team>? Teams { get; set; }
        public virtual DbSet<UserTeam>? UserTeams { get; set; }


    }
}