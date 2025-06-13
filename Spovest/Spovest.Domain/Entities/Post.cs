using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Common;

namespace Spovest.Domain.Entities
{
    public class Post : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Img { get; set; }
    }
}
