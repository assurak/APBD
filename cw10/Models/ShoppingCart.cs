using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

[Table("ShoppingCarts")]
public class ShoppingCart
{
    [Key, Column(Order = 0)]
    public int AccountId { get; set; }

    [ForeignKey("AccountId")]
    public Account Account { get; set; }

    [Key, Column(Order = 1)]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Required]
    public int Amount { get; set; }

    public string Name { get; set; }
}
