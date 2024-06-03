using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

[Table("Categories")]
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<ProductCategory> ProductsCategories { get; set; }
}
