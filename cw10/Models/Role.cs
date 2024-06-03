using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

[Table("Roles")]
public class Role
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<Account> Accounts { get; set; }
}