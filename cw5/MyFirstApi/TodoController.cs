using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi;


[ApiController]
[Route("/todos2")]
public class TodoController : ControllerBase
{
    private IMockDb _mockDb;

    public TodoController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mockDb.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetAll(int id)
    {
        var todo = _mockDb.GetOne(id);
        if (todo is null) return NotFound();
        return Ok(todo);
    }
}