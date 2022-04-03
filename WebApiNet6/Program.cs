var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseOpenApi(); // serve documents (same as app.UseSwagger())
app.UseSwaggerUi3(); // serve Swagger UI

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
