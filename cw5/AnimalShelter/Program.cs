using AnimalShelter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMockDb, MockDb>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/GetAllAnimals", (IMockDb mockDb) =>
{
    return TypedResults.Ok(mockDb.GetAll());
});

app.MapGet("/GetOneAnimal{id:int}", (int id,IMockDb mockDb) =>
{
    var animal = mockDb.GetOne(id);
    if (animal is null) return TypedResults.NotFound();
    return Results.Ok(animal);
});

app.MapPost("/AddAnimal", (Animal animal,IMockDb mockDb) =>
{
    mockDb.Add(animal);
    return TypedResults.Created();
});

app.MapPut("/UpdateAnimal", (Animal animal,int id, IMockDb mockDb) =>
{
    mockDb.Update(animal,id);
    return TypedResults.Ok();
});

app.MapDelete("/DeleteAnimal", (int id, IMockDb mockDb) =>
{
    mockDb.Delete(id);
    return TypedResults.Ok();
});

app.MapGet("/GetVisitsForAnimal", (int id, IMockDb mockDb) =>
{
    var visits = mockDb.GetVisitsForAnimal(id);
    if (visits is null) return TypedResults.NotFound();
    return Results.Ok(visits);
});

app.MapPost("/AddVisit", (Visit visit, IMockDb mockDb) =>
{
    mockDb.AddVisit(visit);
    return TypedResults.Created();
});

app.Run();

