using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Common;

namespace Spovest.Domain.Entities
{
    public class Player : BaseAuditableEntity
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Games { get;set; }
        public decimal Points { get; set; }
        public decimal Assists { get; set; }
        public decimal Rebounds { get; set; }
        public decimal Steals { get; set; }
        public decimal Minutes { get; set; }
        public decimal Ftps { get; set; }
    }
}
