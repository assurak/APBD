using Microsoft.AspNetCore.Http.HttpResults;

namespace AnimalShelter;

interface IMockDb
{
    public ICollection<Animal> GetAll();
    public Animal GetOne(int id);
    public void Add(Animal animal);
    public void Update(Animal animal, int id);
    public void Delete(int id);
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

    public Animal GetOne(int id)
    {
        return _animals.FirstOrDefault(animal => animal.ID == id);
    }

    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public void Update(Animal animal, int id)
    {
        Animal animalToUpdate = _animals.FirstOrDefault(animal => animal.ID == id);
        
        animalToUpdate.ID = animal.ID;
        animalToUpdate.name = animal.name;
        animalToUpdate.category = animal.category;
        animalToUpdate.weight = animal.weight;
        animalToUpdate.color = animal.color;
    }

    public void Delete(int id)
    {
        _animals.Remove(_animals.FirstOrDefault(animal => animal.ID == id));
    }
}