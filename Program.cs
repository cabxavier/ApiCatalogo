using ApiCatalogo.Context;
using ApiCatalogo.Entities;
using ApiCatalogo.Resources.Commands;
using ApiCatalogo.Resources.Queries;
using MediatR;
using System.Reflection;

namespace ApiCatalogo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapGet("produto/getall", async (IMediator mediator) =>
            {
                try
                {
                    var command = new GetProdutosQuery();
                    var response = await mediator.Send(command);
                    return response is not null ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapGet("produto/getbyid", async (IMediator mediator, int id) =>
            {
                try
                {
                    var command = new GetProdutoPorIdQuery() { Id = id };
                    var response = await mediator.Send(command);
                    return response is not null ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapPost("produto/create", async (IMediator mediator, Produto produto) =>
            {
                try
                {
                    var command = new CreateProdutoCommand()
                    {
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        Categoria = produto.Categoria,
                        Preco = produto.Preco,
                        Ativo = produto.Ativo
                    };

                    var response = await mediator.Send(command);
                    return response is not null ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapPut("produto/update", async (IMediator mediator, Produto produto) =>
            {
                try
                {
                    var command = new UpdateProdutoCommand()
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        Categoria = produto.Categoria,
                        Preco = produto.Preco,
                        Ativo = produto.Ativo
                    };

                    var response = await mediator.Send(command);
                    return response is not null ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapDelete("produto/delete", async (IMediator mediator, int id) =>
            {
                try
                {
                    var command = new UpdateProdutoCommand() { Id = id };
                    var response = await mediator.Send(command);
                    return response is not null ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            app.Run();
        }
    }
}
