using Microsoft.EntityFrameworkCore;
using Refit;
using WebApplication1.Data;
using WebApplication1.Integracao;
using WebApplication1.Integracao.Interface;
using WebApplication1.Integracao.Refit;
using WebApplication1.Repositorios;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona servi�os ao cont�iner.

            builder.Services.AddControllers();
            // Saiba mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                   .AddDbContext<SistemaTarefasDBContex>(
                       options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                   );

            // Registra os reposit�rios e servi�os necess�rios no cont�iner de inje��o de depend�ncia.
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

            // Configura o cliente Refit para a interface IViaCepIntegracaoRefit.
            builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

            var app = builder.Build();

            // Configura o pipeline de solicita��o HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}