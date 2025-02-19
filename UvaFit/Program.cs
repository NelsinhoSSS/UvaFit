using Microsoft.EntityFrameworkCore;
using UvaFit.Data;
using UvaFit.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Configurando o DbContext para SQLite
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DataBase")));

// Registrando o repositório de usuários
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Registrando o repositório de equipamentos
builder.Services.AddScoped<IEquipamentoRepositorio, EquipamentoRepositorio>();

// Registrando o repositório de matriculas
builder.Services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();

// Registrando o repositório de treinos
builder.Services.AddScoped<ITreinoRepositorio, TreinoRepositorio>();

// Adicionando outros serviços
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline de requisições
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurando as rotas para o controlador
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
