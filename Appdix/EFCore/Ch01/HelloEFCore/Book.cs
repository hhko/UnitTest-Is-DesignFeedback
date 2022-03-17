using System.ComponentModel.DataAnnotations;

namespace HelloEFCore;

// CreateDatabase
// public class Book
// {
//     public int BookId { get; set; }
//     public string Title { get; set; }
//     public int AuthorId { get; set; }
//     public Author Author { get; set; }
// }

public class Book
{
    public int BookId { get; set; }

    [StringLength(255)]
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}