using PayRoll.Service.DataAccess;
using PayRoll.Service.DBContext;
using PayRoll.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPayRollService, PayRollService>();
builder.Services.AddScoped<IPayRollDataAccess, PayRollDataAccess>();
builder.Services.AddScoped<IDBContext, DBContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
