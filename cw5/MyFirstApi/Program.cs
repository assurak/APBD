using MyFirstApi;

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

app.MapGet("/hello", () =>
{
    return TypedResults.Ok("Hello World!");
});

app.MapGet("/todos", (IMockDb mockDb) =>
{
    return TypedResults.Ok(mockDb.GetAll());
});

app.MapPost("/todos", (Todo todo, IMockDb mockDb) =>
{
    mockDb.Add(todo);
    return TypedResults.Created();
});

app.MapGet("/todos/{id:int}", (int id,IMockDb mockDb) =>
{
    var todo = mockDb.GetOne(id);
    if (todo is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(todo);
});

app.MapDelete("/todos", (int id, IMockDb mockDb) =>
{
    mockDb.Delete(id);

    return TypedResults.Ok("deleted");
});

app.MapPut("/todosPut", (Todo todo,int id, IMockDb mockDb) =>
{
    mockDb.UpdateT(todo,id);
});

app.Run();
