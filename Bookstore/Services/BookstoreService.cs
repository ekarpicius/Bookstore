using Bookstore.Models;

namespace Bookstore.Services
{
    public class BookstoreService : IBookstoreService
    {
        List<Book> Books { get; }
        List<Author> Authors { get; }
        int NextBookId = 5;
        int NextAuthorId = 4;

        public BookstoreService()
        {
            Authors = new List<Author>
            {
                new Author{ Id = 1, FirstName = "Harper", LastName = "Lee" },
                new Author{ Id = 2, FirstName = "Dan", LastName = "Brown"},
                new Author{ Id = 3, FirstName = "John", LastName = "Green"}
            };
            Books = new List<Book> {
                new Book { Id = 1, Title = "To Kill a Mockingbird", Author = GetAuthor(1)},
                new Book { Id = 2, Title = "Angels & Demons", Author = GetAuthor(2)},
                new Book { Id = 3, Title = "The Da Vinci Code", Author = GetAuthor(2)},
                new Book { Id = 4, Title = "The Fault in Our Stars", Author = GetAuthor(3)},
            };
        }

        public List<Book> GetAllBooks() => Books;

        public List<Book>? GetAllBooksByAuthor(Author author) => Books.FindAll(b => b.Author == author);

        public List<Author> GetAllAuthors() => Authors;

        public Book? GetBook(int id) => Books.FirstOrDefault(b => b.Id == id);

        public Author? GetAuthor(int id) => Authors.FirstOrDefault(a => a.Id == id);

        public void AddBook(Book book)
        {
            book.Id = NextBookId++;
            Books.Add(book);
        }

        public void AddAuthor(Author author)
        {
            author.Id = NextAuthorId++;
            Authors.Add(author);
        }
        public void UpdateBook(Book book)
        {
            var index = Books.FindIndex(b => b.Id == book.Id);

            if (index < 0)
            {
                return;
            }

            Books[index] = book;
        }

        public void UpdateAuthor(Author author)
        {
            var index = Authors.FindIndex(a => a.Id == author.Id);

            if (index < 0)
            {
                return;
            }

            Authors[index] = author;
        }

        public void DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book is null)
            {
                return;
            }

            Books.Remove(book);

            if (GetAllBooksByAuthor(book.Author) is null)
            {
                Authors.Remove(book.Author);
            }
        }

        public void DeleteAuthor(int id)
        {
            var author = GetAuthor(id);
            if (author is null) 
            {
                return; 
            }
            Books.RemoveAll(b => b.Author == author);
            Authors.Remove(author);
        }
    }
}
