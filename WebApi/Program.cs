using DBLibrary.DataBase;
using DBLibrary.Repository;

var builder = WebApplication.CreateBuilder(args);

//string connectionString = "Data Source=mssql;Initial Catalog=ispp3101;Persist Security Info=True;User ID=ispp3101;Password=3101;Trust Server Certificate=True";
string connectionString = "Data Source=FLTP-5i5-8256;Initial Catalog=lection;Integrated Security=True;Trust Server Certificate=True";

builder.Services.AddSingleton<IDbConnectionFactory>(new MsSqlFactory(connectionString));
builder.Services.AddScoped<GameRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
