using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Common;

namespace Spovest.Domain.Entities
{
    public class Subscription : BaseAuditableEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int FollowerId { get; set; }
        public AppUser Follower { get; set; }
    }
}
