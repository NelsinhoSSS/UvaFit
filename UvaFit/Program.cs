using Microsoft.EntityFrameworkCore;
using UvaFit.Data;
using UvaFit.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Configurando o DbContext para SQLite
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DataBase")));

// Registrando o reposit�rio de usu�rios
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Registrando o reposit�rio de equipamentos
builder.Services.AddScoped<IEquipamentoRepositorio, EquipamentoRepositorio>();

// Registrando o reposit�rio de matriculas
builder.Services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();

// Registrando o reposit�rio de treinos
builder.Services.AddScoped<ITreinoRepositorio, TreinoRepositorio>();

// Adicionando outros servi�os
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o do pipeline de requisi��es
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
