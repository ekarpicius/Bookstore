using Bookstore.Models;

namespace Bookstore.Services
{
    public interface IBookstoreService
    {
        List<Book> GetAllBooks();
        List<Book>? GetAllBooksByAuthor(Author author);
        List<Author> GetAllAuthors();
        Book? GetBook(int id);
        Author? GetAuthor(int id);
        void AddBook(Book book);
        void AddAuthor(Author author);
        void UpdateBook(Book book);
        void UpdateAuthor(Author author);
        void DeleteBook(int id);
        void DeleteAuthor(int id);
    }
}
