using ManagementLibrary.Communication.Request;
using ManagementLibrary.Communication.Response;
using ManagementLibrary.Models;

namespace ManagementLibrary.Repositories;

public class BookRepositorie
{
    public ResponseInsertBooksJson InsertBook(RequestInsertBooksJson obj)
    {
        Books values = new Books()
        {
            Id = System.Guid.NewGuid(),
            Title = obj.Title,
            Author = obj.Author,
            Gender = obj.Gender,
            Price = obj.Price,
            QuantityStock = obj.QuantityStock,
        };
        Books.BooksElements.Add(values);

        return new ResponseInsertBooksJson() { Id = values.Id, Title = values.Title };
    }

    public void UpdateBook(int index, RequestUpdateBooksJson obj)
    {
        Books findedBook = Books.BooksElements[index];

        findedBook.Title = !string.IsNullOrEmpty(obj.Title) ? obj.Title : findedBook.Title;
        findedBook.Author = !string.IsNullOrEmpty(obj.Author) ? obj.Author : findedBook.Author;
        findedBook.Gender = !string.IsNullOrEmpty(obj.Gender) ? obj.Gender : findedBook.Gender;
        findedBook.Price = obj.Price ?? findedBook.Price;
        findedBook.QuantityStock = obj.QuantityStock ?? findedBook.QuantityStock;
    }

    public void DeleteBook(int index)
    {
        Books.BooksElements.RemoveAt(index);
    }

    public List<Books> ListBook()
    {
        return Books.BooksElements;
    }
}
