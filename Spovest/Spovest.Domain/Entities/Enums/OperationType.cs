using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spovest.Domain.Entities.Enums
{
    public enum OperationType
    {
        [Display(Name = "Buy")]
        Buy,
        [Display(Name = "Sell")]
        Sell,
        [Display(Name = "Refill")]
        Refill,
        [Display(Name = "Withdraw")]
        Withdraw,
    }
}
