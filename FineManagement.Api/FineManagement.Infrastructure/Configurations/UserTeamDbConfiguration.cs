using FineManagement.Core.Entities;
using FineManagement.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FineManagement.Infrastructure.Configurations
{
    public class UserTeamDbConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.ToTable(TableNames.UserTeam);

            builder.HasMany(ut => ut.Fines).WithOne(f => f.UserTeam);

            builder.HasMany(ut => ut.Transactions).WithOne(t => t.UserTeam);
        }
    }
}
