
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Domain;

public class Author{

    [Key]
    public int Id { get; set; }

    [Required]
    public string AuthorName { get; set; } = string.Empty;
}