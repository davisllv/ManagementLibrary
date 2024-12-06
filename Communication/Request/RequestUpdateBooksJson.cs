namespace ManagementLibrary.Communication.Request;

public class RequestUpdateBooksJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int QuantityStock { get; set; }
}
