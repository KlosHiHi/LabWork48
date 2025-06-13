using WebApiServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


var client = new HttpClient()
{
    //BaseAddress = new Uri("http://localhost:5185/api/")
    BaseAddress = new Uri("http://localhost:5042/api/")
};

builder.Services.AddSingleton<GamesApiService>(new GamesApiService(client));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
