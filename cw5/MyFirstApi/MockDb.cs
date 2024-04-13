namespace MyFirstApi;

public interface IMockDb
{
    public ICollection<Todo> GetAll();
    public bool Add(Todo todo);
    public Todo GetOne(int id);
    public bool Delete(int id);
    public void UpdateT(Todo todo, int id);
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

    public bool Delete(int id)
    {
        _todos.Remove(_todos.FirstOrDefault(todo => todo.ID == id));
        return true;
    }

    public void UpdateT(Todo todo2, int id)
    {
        Todo todoToUpdate = _todos.FirstOrDefault(todo => todo.ID == id);
        todoToUpdate.ID = todo2.ID;
        todoToUpdate.Desctription = todo2.Desctription;
    }
}