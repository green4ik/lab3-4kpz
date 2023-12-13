using Microsoft.EntityFrameworkCore;
using TeamFightTacticsReviewApp;
using TeamFightTacticsReviewApp.Data;
using TeamFightTacticsReviewApp.Interface;
using TeamFightTacticsReviewApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITacticRepository,TacticRepository>();
builder.Services.AddScoped<IChampionRepository, ChampionRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        builder => {
            builder.WithOrigins("http://localhost:3000") // Update with your React app's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
//builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
app.UseCors("ReactPolicy");
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app) {
    var scopedfactory = app.Services.GetService<IServiceScopeFactory>();
    using( var scope = scopedfactory.CreateScope()) {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.seedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
