using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Spovest.Persistence.Configurations
{
    public class PlayersConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasData(
                new Player { Id = 1, TeamId = 1, TeamName = "Los Angeles Lakers", Name = "Lebron James", Img = "/images/player_search/avatar_3.png", Games = 72, Points = 28.5m, Assists = 7.8m, Rebounds = 8.3m, Steals = 1.6m, Minutes = 36.2m, Ftps = 0.73m },
                new Player { Id = 2, TeamId = 1, TeamName = "Los Angeles Lakers", Name = "Anthony Davis", Img = "/images/player_search/avatar_5.png", Games = 65, Points = 22.4m, Assists = 3.1m, Rebounds = 10.2m, Steals = 1.8m, Minutes = 32.5m, Ftps = 0.78m },
                new Player { Id = 3, TeamId = 1, TeamName = "Los Angeles Lakers", Name = "Russell Westbrook", Img = "/images/player_search/avatar_1.png", Games = 70, Points = 18.2m, Assists = 8.4m, Rebounds = 7.5m, Steals = 1.3m, Minutes = 34.0m, Ftps = 0.67m },
                new Player {Id = 4, TeamId = 1, TeamName = "Los Angeles Lakers", Name = "D'Angelo Russell", Img = "/images/player_search/avatar_6.png", Games = 68, Points = 15.3m, Assists = 6.2m, Rebounds = 3.4m, Steals = 1.1m, Minutes = 29.8m, Ftps = 0.82m },
                new Player {Id = 5, TeamId = 1, TeamName = "Los Angeles Lakers", Name = "Austin Reaves", Img = "/images/player_search/avatar_2.png" , Games = 60, Points = 9.7m, Assists = 2.9m, Rebounds = 2.8m, Steals = 0.9m, Minutes = 21.4m, Ftps = 0.85m },

                new Player {Id = 6, TeamId = 2, TeamName = "Golden State Warriors", Name = "Stephen Curry", Img = "/images/player_search/avatar_1.png", Games = 67, Points = 31.2m, Assists = 6.5m, Rebounds = 5.5m, Steals = 1.2m, Minutes = 34.7m, Ftps = 0.91m },
                new Player {Id = 7, TeamId = 2, TeamName = "Golden State Warriors", Name = "Klay Thompson", Img = "/images/player_search/avatar_6.png", Games = 62, Points = 21.5m, Assists = 3.2m, Rebounds = 3.9m, Steals = 1.3m, Minutes = 31.0m, Ftps = 0.87m },
                new Player {Id = 8, TeamId = 2, TeamName = "Golden State Warriors", Name = "Draymond Green", Img = "/images/player_search/avatar_2.png", Games = 64, Points = 8.5m, Assists = 6.9m, Rebounds = 7.1m, Steals = 1.5m, Minutes = 28.3m, Ftps = 0.65m },
                new Player {Id = 9, TeamId = 2, TeamName = "Golden State Warriors", Name = "Andrew Wiggins", Img = "/images/player_search/avatar_3.png", Games = 66, Points = 17.3m, Assists = 3.4m, Rebounds = 5.2m, Steals = 1.0m, Minutes = 30.1m, Ftps = 0.76m },
                new Player {Id = 10, TeamId = 2, TeamName = "Golden State Warriors", Name = "Chris Paul", Img = "/images/player_search/avatar_5.png", Games = 58, Points = 14.2m, Assists = 8.8m, Rebounds = 4.1m, Steals = 1.7m, Minutes = 29.5m, Ftps = 0.83m },

                new Player {Id = 11, TeamId = 3, TeamName = "Boston Celtics", Name = "Jayson Tatum", Img = "/images/player_search/avatar_5.png", Games = 74, Points = 30.1m, Assists = 4.9m, Rebounds = 9.2m, Steals = 1.4m, Minutes = 36.5m, Ftps = 0.86m },
                new Player {Id = 12, TeamId = 3, TeamName = "Boston Celtics", Name = "Jaylen Brown", Img = "/images/player_search/avatar_3.png", Games = 70, Points = 24.6m, Assists = 3.5m, Rebounds = 6.3m, Steals = 1.3m, Minutes = 33.2m, Ftps = 0.80m },
                new Player {Id = 13, TeamId = 3, TeamName = "Boston Celtics", Name = "Kristaps Porzingis", Img = "/images/player_search/avatar_2.png", Games = 58, Points = 20.4m, Assists = 2.1m, Rebounds = 8.9m, Steals = 1.2m, Minutes = 28.7m, Ftps = 0.82m },
                new Player {Id = 14, TeamId = 3, TeamName = "Boston Celtics", Name = "Derrick White", Img = "/images/player_search/avatar_1.png", Games = 65, Points = 11.2m, Assists = 4.0m, Rebounds = 3.1m, Steals = 1.0m, Minutes = 26.4m, Ftps = 0.85m },
                new Player {Id = 15, TeamId = 3, TeamName = "Boston Celtics", Name = "Al Horford", Img = "/images/player_search/avatar_6.png", Games = 60, Points = 9.5m, Assists = 2.8m, Rebounds = 7.2m, Steals = 0.8m, Minutes = 24.1m, Ftps = 0.79m },

                new Player {Id = 16, TeamId = 4, TeamName = "Brooklyn Nets", Name = "Kevin Durant", Img = "/images/player_search/avatar_6.png", Games = 70, Points = 29.8m, Assists = 5.4m, Rebounds = 7.3m, Steals = 1.1m, Minutes = 35.9m, Ftps = 0.90m },
                new Player {Id = 17, TeamId = 4, TeamName = "Brooklyn Nets", Name = "Ben Simmons", Img = "/images/player_search/avatar_1.png", Games = 55, Points = 6.8m, Assists = 6.5m, Rebounds = 6.1m, Steals = 1.4m, Minutes = 27.3m, Ftps = 0.55m },
                new Player {Id = 18, TeamId = 4, TeamName = "Brooklyn Nets", Name = "Mikal Bridges", Img = "/images/player_search/avatar_2.png", Games = 68, Points = 19.4m, Assists = 3.2m, Rebounds = 4.8m, Steals = 1.6m, Minutes = 33.0m, Ftps = 0.83m },
                new Player {Id = 19, TeamId = 4, TeamName = "Brooklyn Nets", Name = "Spencer Dinwiddie", Img = "/images/player_search/avatar_5.png", Games = 62, Points = 13.6m, Assists = 5.7m, Rebounds = 2.9m, Steals = 0.9m, Minutes = 28.4m, Ftps = 0.81m },
                new Player {Id = 20, TeamId = 4, TeamName = "Brooklyn Nets", Name = "Seth Curry", Img = "/images/player_search/avatar_3.png", Games = 64, Points = 11.5m, Assists = 2.4m, Rebounds = 2.1m, Steals = 0.7m, Minutes = 23.9m, Ftps = 0.92m },

                new Player {Id = 21, TeamId = 5, TeamName = "Miami Heat", Name = "Jimmy Butler", Img = "/images/player_search/avatar_3.png", Games = 69, Points = 22.6m, Assists = 5.4m, Rebounds = 5.8m, Steals = 2.1m, Minutes = 34.8m, Ftps = 0.84m },
                new Player {Id = 22, TeamId = 5, TeamName = "Miami Heat", Name = "Bam Adebayo", Img = "/images/player_search/avatar_2.png", Games = 71, Points = 20.1m, Assists = 3.5m, Rebounds = 9.4m, Steals = 1.3m, Minutes = 33.6m, Ftps = 0.77m },
                new Player {Id = 23, TeamId = 5, TeamName = "Miami Heat", Name = "Tyler Herro", Img = "/images/player_search/avatar_6.png", Games = 66, Points = 21.2m, Assists = 4.3m, Rebounds = 5.1m, Steals = 1.0m, Minutes = 32.1m, Ftps = 0.86m },
                new Player {Id = 24, TeamId = 5, TeamName = "Miami Heat", Name = "Max Strus", Img = "/images/player_search/avatar_1.png", Games = 63, Points = 9.8m, Assists = 2.1m, Rebounds = 3.2m, Steals = 0.8m, Minutes = 24.5m, Ftps = 0.88m },
                new Player {Id = 25, TeamId = 5, TeamName = "Miami Heat", Name = "Gabe Vincent", Img = "/images/player_search/avatar_5.png", Games = 58, Points = 7.4m, Assists = 2.3m, Rebounds = 2.0m, Steals = 0.9m, Minutes = 19.8m, Ftps = 0.85m },

                new Player {Id = 26, TeamId = 6, TeamName = "Denver Nuggets", Name = "Nikola Jokic", Img = "/images/player_search/avatar_5.png", Games = 74, Points = 24.5m, Assists = 8.7m, Rebounds = 10.8m, Steals = 1.3m, Minutes = 33.7m, Ftps = 0.83m },
                new Player {Id = 27, TeamId = 6, TeamName = "Denver Nuggets", Name = "Jamal Murray", Img = "/images/player_search/avatar_1.png", Games = 68, Points = 20.3m, Assists = 6.1m, Rebounds = 4.5m, Steals = 1.4m, Minutes = 32.6m, Ftps = 0.89m },
                new Player {Id = 28, TeamId = 6, TeamName = "Denver Nuggets", Name = "Aaron Gordon", Img = "/images/player_search/avatar_2.png", Games = 70, Points = 17.2m, Assists = 3.8m, Rebounds = 6.9m, Steals = 1.1m, Minutes = 31.5m, Ftps = 0.76m },
                new Player {Id = 29, TeamId = 6, TeamName = "Denver Nuggets", Name = "Michael Porter Jr.", Img = "/images/player_search/avatar_6.png", Games = 60, Points = 14.1m, Assists = 1.9m, Rebounds = 6.3m, Steals = 0.9m, Minutes = 27.4m, Ftps = 0.87m },
                new Player {Id = 30, TeamId = 6, TeamName = "Denver Nuggets", Name = "Kentavious Caldwell-Pope", Img = "/images/player_search/avatar_3.png", Games = 67, Points = 10.2m, Assists = 2.5m, Rebounds = 3.4m, Steals = 1.2m, Minutes = 25.8m, Ftps = 0.80m }
            );
        }
    }
}
