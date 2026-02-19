var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add services to the container before this line
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/swagger"));


app.MapControllers();

app.Run();
