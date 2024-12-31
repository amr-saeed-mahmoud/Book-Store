
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Domain;

public class Genre{

    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
}