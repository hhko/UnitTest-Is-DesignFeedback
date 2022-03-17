namespace HelloEFCore;

public class Program
{
    public static void Main(string[] args)
    {
        // Case 1. 추가
        // using (var context = new DemoContext())
        // {
        //     var author = new Author {
        //         FirstName = "William",
        //         LastName = "Shakespeare",
        //         Books = new List<Book>
        //         {
        //             new Book { Title = "Hamlet"},
        //             new Book { Title = "Othello" },
        //             new Book { Title = "MacBeth" }
        //         }
        //     };
        //     context.Add(author);
        //     context.SaveChanges();
        // }

        using (var context = new DemoContext())
        {
            foreach(var book in context.Books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
