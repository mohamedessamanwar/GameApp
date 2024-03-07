using Game_APP.Services.Game_Repo;
using Game_APP.Fillters;
using Game_APP.Middlewares;
using Game_APP.Services.CategoryRepo;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<Filter1>();

/////add json file ...
builder.Configuration.AddJsonFile("conf.json");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<Filter1>();
});
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IGameService,GameService>();

builder.Services.AddDbContext<Game_APP.Models.Data.AppContext>(options => options

    .UseSqlServer(builder.Configuration["ConnectionString"]));

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//app.UseMiddleware<ProfilerMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Game}/{action=Index}/{id?}"); 

app.Run();
