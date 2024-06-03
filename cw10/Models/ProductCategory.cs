using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

[Table("ProductsCategories")]
public class ProductCategory
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
