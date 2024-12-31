
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Domain;

public class Publisher{

    [Key]
    public int Id { get; set; }

    [Required]
    public string PublisherName { get; set; } = string.Empty;
}