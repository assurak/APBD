namespace AnimalShelter;

interface IMockDb
{
    public ICollection<Animal> GetAll();
}

public class MockDb : IMockDb
{
    private ICollection<Animal> _animals;

    public MockDb()
    {
        _animals = new List<Animal>();
        (_animals as List<Animal>)?.Add(new Animal
        {
            ID = 1,
            name = "reksio",
            category = "pies",
            weight = 2.0,
            color = "czerwony"
        });
        (_animals as List<Animal>)?.Add(new Animal
        {
            ID = 2,
            name = "burek",
            category = "pies",
            weight = 5.0,
            color = "bury"
        });
        (_animals as List<Animal>)?.Add(new Animal
        {
            ID = 3,
            name = "filemon",
            category = "kot",
            weight = 0.5,
            color = "bialy"
        });
    }

    public ICollection<Animal> GetAll()
    {
        return _animals;
    }
}