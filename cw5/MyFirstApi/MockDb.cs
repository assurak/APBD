namespace MyFirstApi;

public interface IMockDb
{
    public ICollection<Todo> GetAll();
    public bool Add(Todo todo);
    public Todo GetOne(int id);
}

public class MockDb : IMockDb
{
    private ICollection<Todo> _todos;

    public MockDb()
    {
        _todos = new List<Todo>();
        _todos.Add((new Todo
        {
            ID = 1,
            Desctription = "First Todo"
        }));
    }

    public ICollection<Todo> GetAll()
    {
        return _todos;
    }

    public bool Add(Todo todo)
    {
        _todos.Add(todo);
        return true;
    }

    public Todo? GetOne(int id)
    {
        return _todos.FirstOrDefault(todo => todo.ID == id);
    }
}