using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Common;

namespace Spovest.Domain.Entities
{
    public class Team : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public string? Img { get; set; }
    }
}
