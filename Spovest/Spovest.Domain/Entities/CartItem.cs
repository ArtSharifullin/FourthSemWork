using Spovest.Domain.Common;

namespace Spovest.Domain.Entities;

public class CartItem : BaseAuditableEntity
{
    public int UserId { get; set; }
    public AppUser AppUser { get; set; }
    
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    
    public int Quantity { get; set; }

    public decimal PriceAtAdd { get; set; }
} 