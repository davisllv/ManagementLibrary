using ManagementLibrary.Communication.Request;
using ManagementLibrary.Communication.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ManagementLibrary.Models;

public class Books
{
    #region 
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public int QuantityStock { get; set; }

    public static List<Books> BooksElements { get; set; } = new List<Books>();
    public static ResponseInsertBooksJson InsertBook(RequestInsertBooksJson obj)
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
        BooksElements.Add(values);

        return new ResponseInsertBooksJson() { Id = values.Id, Title = values.Title };
    }

    public void UpdateBook(int index, RequestUpdateBooksJson obj)
    {
        Books findedBook = BooksElements[index];

        findedBook.Title = !string.IsNullOrEmpty(obj.Title) ? obj.Title : findedBook.Title;
        findedBook.Author = !string.IsNullOrEmpty(obj.Author) ? obj.Author :  findedBook.Author;
        findedBook.Gender = !string.IsNullOrEmpty(obj.Gender) ? obj.Gender : findedBook.Gender;
        findedBook.Price = obj.Price ?? findedBook.Price;
        findedBook.QuantityStock = obj.QuantityStock ?? findedBook.QuantityStock;
    }

    public List<Books> ListBook()
    {
        return BooksElements;
    }
    #endregion
}
