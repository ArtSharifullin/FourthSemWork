using Spovest.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spovest.Domain.Entities;

public class AppUser : BaseAuditableEntity 
{
    public string IdentityId { get; set; }
    public string Name { get; set; }
    public string Img { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Country { get; set; }
    public decimal Balance { get; set; }
    public bool IsWithdrawBlocked { get; set; }
}
