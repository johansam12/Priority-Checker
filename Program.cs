using Microsoft.EntityFrameworkCore;
// version setup for .NET - 8.0.11
var builder = WebApplication.CreateBuilder(args);

// Register Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB setup for temp storage 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

var app = builder.Build();

// 2. Middleware configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

// 3. API Endpoints
app.MapPost("/check-priority", async (string title, string desc, AppDbContext db) =>
{
    var priorityLevel = desc.Length > 30 ? "High" : "Low";
    var newTask = new PriorityTask { Title = title, Priority = priorityLevel };
    
    db.Tasks.Add(newTask);
    await db.SaveChangesAsync();
    
    return Results.Ok(newTask);
});

app.MapGet("/tasks", async (AppDbContext db) => 
    await db.Tasks.ToListAsync());

app.Run();

// 4. Database Classes (shown in schemas)
public class PriorityTask {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
}

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<PriorityTask> Tasks => Set<PriorityTask>();
}