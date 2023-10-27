using Crud_app_with_mongo.Data_access_layer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// services here by me // dependcy creataion done
builder.Services.AddScoped<ICrudOperationsDL, CrudOperationsDL>();
// swaggergen done
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    
});

app.MapControllers();

app.Run();
