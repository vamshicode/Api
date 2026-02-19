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
    //in dev environment, we want to show the swagger UI
    // app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VKInsurance API V1");
    //    c.RoutePrefix = string.Empty; // optional: serve at root
    //});

}
//app.UseDeveloperExceptionPage();

//added this for PROD deployment
app.UseSwagger();

//added this for PROD deployment
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VKInsurance API V1");
    c.RoutePrefix = string.Empty; // optional: serve at root
});


app.UseHttpsRedirection();


app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/swagger"));


app.MapControllers();

app.Run();
