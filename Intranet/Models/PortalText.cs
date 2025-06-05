using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Models;

[Table("PortalTexts")]
public class PortalText
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Key { get; set; } = string.Empty;

    [Required]
    public string Value { get; set; } = string.Empty;

    [StringLength(100)]
    public string Section { get; set; } = string.Empty;

    [StringLength(10)]
    public string? Language { get; set; }
}
