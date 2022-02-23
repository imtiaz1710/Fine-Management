using FineManagement.Core.Entities;
using FineManagement.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineManagement.Infrastructure.Configurations
{
    public class UserDbConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.User);

            builder.HasMany(u => u.Teams)
                .WithMany(t => t.Users)
                .UsingEntity(x => x.ToTable(TableNames.UserTeam));
        }
    }
}
