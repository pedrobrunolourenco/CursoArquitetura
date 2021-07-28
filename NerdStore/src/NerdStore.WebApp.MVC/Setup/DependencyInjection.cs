using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Domain;
using NetScore.Catalogo.Data;
using NetScore.Catalogo.Data.Repository;
using NetStore.Catalogo.Domain;
using NetStore.Catalogo.Domain.Events;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();
            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>,ProdutoEventHandler>();

            // vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand,bool>,PedidoCommandHandler >();
 


        }
    }
}
