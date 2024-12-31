
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Models.Domain;
public class Book
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(60)]
    public string? Title { get; set; }

    [Required, MaxLength(15)]
    public string? ISBN { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Total pages must be greater than 0.")]
    [Required]
    public int TotalPages { get; set; }

    [Required]
    public int AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public Author? Author { get; set; } 

    [Required]
    public int PublisherId { get; set; }

    [ForeignKey("PublisherId")]
    public Publisher? Publisher { get; set; }

    [Required]
    public int GenreId { get; set; }

    [ForeignKey("GenreId")]
    public Genre? Genre { get; set; }
}
