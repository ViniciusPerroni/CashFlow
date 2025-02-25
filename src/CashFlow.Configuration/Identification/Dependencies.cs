using Microsoft.Extensions.DependencyInjection;
using CashFlow.Domain.Identification.Repositories;
using CashFlow.Data.Identification.Repositories;


using User = CashFlow.Application.Identification.UseCases.User;

namespace CashFlow.Configuration.Identification
{
    public static class Dependencies
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            //Repositorios 
            services.AddTransient<IUserRepository, UserRepository>();

            //UseCases
            services.AddTransient<User.Create.IUseCase, User.Create.UseCase>();
            services.AddTransient<User.Delete.IUseCase, User.Delete.UseCase>();
            services.AddTransient<User.Edit.IUseCase, User.Edit.UseCase>();
            services.AddTransient<User.GetById.IUseCase, User.GetById.UseCase>();
            services.AddTransient<User.List.IUseCase, User.List.UseCase>();
            services.AddTransient<User.GetByEmailAndPassword.IUseCase, User.GetByEmailAndPassword.UseCase>();
            

            return services;
        }
    }
}
