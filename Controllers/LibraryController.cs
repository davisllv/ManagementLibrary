using ManagementLibrary.Communication.Request;
using ManagementLibrary.Communication.Response;
using ManagementLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementLibrary.Controllers;

public class LibraryController : ManagementLibraryBaseController
{
    [HttpGet]
    [Route("List")]
    [ProducesResponseType(typeof(List<Books>), StatusCodes.Status200OK)]
    public IActionResult List()
    {
        return Ok(new Books().ListBook());
    }

    [HttpPost]
    [Route("Insert")]
    [ProducesResponseType(typeof(ResponseInsertBooksJson), StatusCodes.Status201Created)]
    public IActionResult Insert([FromBody] RequestInsertBooksJson obj)
    {
        return Created(string.Empty, Books.InsertBook(obj));
    }

    [HttpPut]
    [Route("Edit/{id}")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Edit(
        [FromRoute] Guid Id,
        [FromBody] RequestUpdateBooksJson obj)
    {
        Books books = new Books();
        books.UpdateBook(Id, obj);
        return Ok("Livro Alterado");
    }
}
