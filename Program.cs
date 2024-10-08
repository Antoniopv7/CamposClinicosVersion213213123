using Microsoft.EntityFrameworkCore; // Para DbContext y Entity Framework
using Microsoft.AspNetCore.Identity; // Para Identity
using Npgsql.EntityFrameworkCore.PostgreSQL; // Para usar el proveedor de PostgreSQL
using Gestion_Del_Presupuesto.Data; // Aseg�rate de que este `using` apunte a tu contexto de base de datos

var builder = WebApplication.CreateBuilder(args);

// Configurar el servicio de DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar servicios de ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurar la cookie de autenticaci�n
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";  // Redirigir al login si no est� autenticado
    options.AccessDeniedPath = "/Account/AccessDenied";  // Redirigir si no tiene permisos
});

// Agregar servicios para controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitar autenticaci�n y autorizaci�n
app.UseAuthentication();  // Habilitar autenticaci�n
app.UseAuthorization();  // Habilitar autorizaci�n

// Configurar las rutas predeterminadas de la aplicaci�n
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Role}/{action=Index}/{id?}"); // Redirigir a la p�gina de roles


app.Run();
