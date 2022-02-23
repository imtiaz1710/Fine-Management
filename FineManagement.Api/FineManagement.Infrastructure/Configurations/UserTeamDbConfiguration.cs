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
