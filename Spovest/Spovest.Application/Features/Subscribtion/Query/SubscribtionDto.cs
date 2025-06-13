using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Subscribtion.Query
{
    public class SubscribtionDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int FollowerId { get; set; }
        public AppUser Follower { get; set; }
    }
}
