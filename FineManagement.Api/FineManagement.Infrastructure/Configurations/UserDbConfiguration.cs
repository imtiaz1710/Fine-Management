using FineManagement.Core.Entities;
using FineManagement.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FineManagement.Infrastructure.Configurations
{
    public class UserDbConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.User);
            builder.HasMany(x => x.Teams)
                .WithMany(y => y.Users)
                .UsingEntity<UserTeam>();
        }
    }
}
