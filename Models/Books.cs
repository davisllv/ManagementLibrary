using System.Text.Json;

namespace ManagementLibrary.Models;

public class Books
{
    #region 
    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public int QuantityStock { get; set; }

    public static List<Books> BooksElements { get; set; } = new List<Books>();
    #endregion
}
