using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public record WarehouseProductDTO(
    [Required] int IdProduct,
    [Required] int IdWarehouse,
    [Required] int Amount,
    [Required] DateTime CreatedAt
);