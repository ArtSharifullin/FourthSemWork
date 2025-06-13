using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Configurations
{
    public class PricesConfiguration : IEntityTypeConfiguration<PriceHistory>
    {
        public void Configure(EntityTypeBuilder<PriceHistory> builder)
        {
            var time = DateTime.SpecifyKind(new DateTime(2025, 6, 1, 12, 0, 0), DateTimeKind.Utc);
            var time2 = DateTime.SpecifyKind(new DateTime(2025, 6, 2, 12, 0, 0), DateTimeKind.Utc);

            builder.HasData(
                new PriceHistory { Id = 1, PlayerId = 1, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 2, PlayerId = 2, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 3, PlayerId = 3, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 4, PlayerId = 4, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 5, PlayerId = 5, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 6, PlayerId = 6, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 7, PlayerId = 7, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 8, PlayerId = 8, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 9, PlayerId = 9, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 10, PlayerId = 10, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 11, PlayerId = 11, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 12, PlayerId = 12, Purchase_price = 5, Sale_price = 5, Timestamp = time  },
                new PriceHistory { Id = 13, PlayerId = 13, Purchase_price = 5, Sale_price = 5, Timestamp = time  },
                new PriceHistory { Id = 14, PlayerId = 14, Purchase_price = 5, Sale_price = 5, Timestamp = time  },
                new PriceHistory { Id = 15, PlayerId = 15, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 16, PlayerId = 16, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 17, PlayerId = 17, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 18, PlayerId = 18, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 19, PlayerId = 19, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 20, PlayerId = 20, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 21, PlayerId = 21, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 22, PlayerId = 22, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 23, PlayerId = 23, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 24, PlayerId = 24, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 25, PlayerId = 25, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 26, PlayerId = 26, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 27, PlayerId = 27, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 28, PlayerId = 28, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 29, PlayerId = 29, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 30, PlayerId = 30, Purchase_price = 5, Sale_price = 5, Timestamp = time },
                new PriceHistory { Id = 31, PlayerId = 1, Purchase_price = 12, Sale_price = 10, Timestamp = time2 },
                new PriceHistory { Id = 32, PlayerId = 2, Purchase_price = 7, Sale_price = 8, Timestamp = time2 },
                new PriceHistory { Id = 33, PlayerId = 3, Purchase_price = 15, Sale_price = 14, Timestamp = time2 },
                new PriceHistory { Id = 34, PlayerId = 4, Purchase_price = 5, Sale_price = 6, Timestamp = time2 },
                new PriceHistory { Id = 35, PlayerId = 5, Purchase_price = 19, Sale_price = 17, Timestamp = time2 },
                new PriceHistory { Id = 36, PlayerId = 6, Purchase_price = 3, Sale_price = 4, Timestamp = time2 },
                new PriceHistory { Id = 37, PlayerId = 7, Purchase_price = 9, Sale_price = 9, Timestamp = time2 },
                new PriceHistory { Id = 38, PlayerId = 8, Purchase_price = 2, Sale_price = 3, Timestamp = time2 },
                new PriceHistory { Id = 39, PlayerId = 9, Purchase_price = 16, Sale_price = 15, Timestamp = time2 },
                new PriceHistory { Id = 40, PlayerId = 10, Purchase_price = 6, Sale_price = 7, Timestamp = time2 },
                new PriceHistory { Id = 41, PlayerId = 11, Purchase_price = 10, Sale_price = 10, Timestamp = time2 },
                new PriceHistory { Id = 42, PlayerId = 12, Purchase_price = 4, Sale_price = 5, Timestamp = time2 },
                new PriceHistory { Id = 43, PlayerId = 13, Purchase_price = 18, Sale_price = 16, Timestamp = time2 },
                new PriceHistory { Id = 44, PlayerId = 14, Purchase_price = 8, Sale_price = 9, Timestamp = time2 },
                new PriceHistory { Id = 45, PlayerId = 15, Purchase_price = 1, Sale_price = 2, Timestamp = time2 },
                new PriceHistory { Id = 46, PlayerId = 16, Purchase_price = 14, Sale_price = 13, Timestamp = time2 },
                new PriceHistory { Id = 47, PlayerId = 17, Purchase_price = 11, Sale_price = 12, Timestamp = time2 },
                new PriceHistory { Id = 48, PlayerId = 18, Purchase_price = 5, Sale_price = 5, Timestamp = time2 },
                new PriceHistory { Id = 49, PlayerId = 19, Purchase_price = 7, Sale_price = 8, Timestamp = time2 },
                new PriceHistory { Id = 50, PlayerId = 20, Purchase_price = 13, Sale_price = 12, Timestamp = time2 },
                new PriceHistory { Id = 51, PlayerId = 21, Purchase_price = 9, Sale_price = 10, Timestamp = time2 },
                new PriceHistory { Id = 52, PlayerId = 22, Purchase_price = 3, Sale_price = 4, Timestamp = time2 },
                new PriceHistory { Id = 53, PlayerId = 23, Purchase_price = 17, Sale_price = 15, Timestamp = time2 },
                new PriceHistory { Id = 54, PlayerId = 24, Purchase_price = 6, Sale_price = 7, Timestamp = time2 },
                new PriceHistory { Id = 55, PlayerId = 25, Purchase_price = 2, Sale_price = 3, Timestamp = time2 },
                new PriceHistory { Id = 56, PlayerId = 26, Purchase_price = 10, Sale_price = 9, Timestamp = time2 },
                new PriceHistory { Id = 57, PlayerId = 27, Purchase_price = 8, Sale_price = 8, Timestamp = time2 },
                new PriceHistory { Id = 58, PlayerId = 28, Purchase_price = 4, Sale_price = 5, Timestamp = time2 },
                new PriceHistory { Id = 59, PlayerId = 29, Purchase_price = 15, Sale_price = 14, Timestamp = time2 },
                new PriceHistory { Id = 60, PlayerId = 30, Purchase_price = 7, Sale_price = 6, Timestamp = time2 }
            );
        }
    }
}
