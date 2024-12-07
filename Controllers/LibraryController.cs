using ManagementLibrary.Communication.Request;
using ManagementLibrary.Communication.Response;
using ManagementLibrary.Models;
using ManagementLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManagementLibrary.Controllers;

public class LibraryController : ManagementLibraryBaseController
{
    [HttpGet]
    [Route("List")]
    [ProducesResponseType(typeof(List<Books>), StatusCodes.Status200OK)]
    public IActionResult List()
    {
        return Ok(new BookRepositorie().ListBook());
    }

    [HttpPost]
    [Route("Insert")]
    [ProducesResponseType(typeof(ResponseInsertBooksJson), StatusCodes.Status201Created)]
    public IActionResult Insert([FromBody] RequestInsertBooksJson obj)
    {
        return Created(string.Empty, new BookRepositorie().InsertBook(obj));
    }

    [HttpPut]
    [Route("Edit/{id}")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Edit(
        [FromRoute] Guid Id,
        [FromBody] RequestUpdateBooksJson obj)
    {
        BookRepositorie books = new BookRepositorie();
        List<Books> listBooks = books.ListBook();

        int findedIndex = listBooks.FindIndex(x => x.Id == Id);
        
        if(findedIndex < 0)
            return NotFound(new { Message = $"Book with ID {Id} not found." });
        
        books.UpdateBook(findedIndex, obj);
        return Ok("Books has been updated");
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid Id)
    {
        BookRepositorie books = new BookRepositorie();
        List<Books> listBooks = books.ListBook();

        int findedIndex = listBooks.FindIndex(x => x.Id == Id);

        if (findedIndex < 0)
            return NotFound(new { Message = $"Book with ID {Id} not found." });

        string title = listBooks[findedIndex].Title;

        books.DeleteBook(findedIndex);

        return Ok($"Book {title} has been removed");
    }
}
