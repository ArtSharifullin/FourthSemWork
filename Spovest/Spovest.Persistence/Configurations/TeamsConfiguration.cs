using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Configurations
{
    public class TeamsConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team { Id = 1, Name = "Los Angeles Lakers", Img = "/images/teams/lakers.png" },
                new Team { Id = 2, Name = "Golden State Warriors", Img = "/images/teams/gsw.png" },
                new Team { Id = 3, Name = "Boston Celtics", Img = "/images/teams/bc.png" },
                new Team { Id = 4, Name = "Brooklyn Nets", Img = "/images/teams/bn.png" },
                new Team { Id = 5, Name = "Miami Heat", Img = "/images/teams/mh.png" },
                new Team { Id = 6, Name = "Denver Nuggets", Img = "/images/teams/dn.png" }
            );
        }
    }
}
