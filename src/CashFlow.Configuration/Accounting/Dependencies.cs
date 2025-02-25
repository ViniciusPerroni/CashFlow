using AutoMapper;

using CashFlow.Crosscutting;
using CashFlow.Data.Accounting.Repositories;
using CashFlow.Domain.Accounting.Repositories;
using Microsoft.Extensions.DependencyInjection;

using Account = CashFlow.Application.Accounting.UseCases.Account;
using AccountingEntry = CashFlow.Application.Accounting.UseCases.AccountingEntry;

namespace CashFlow.Configuration.Accounting
{
    public static class Dependencies
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            //Repositorios 
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountingEntryRepository, AccountingEntryRepository>();


            //UseCases
            services.AddTransient<Account.Create.IUseCase, Account.Create.UseCase>();
            services.AddTransient<Account.Delete.IUseCase, Account.Delete.UseCase>();
            services.AddTransient<Account.Edit.IUseCase, Account.Edit.UseCase>();
            services.AddTransient<Account.GetById.IUseCase, Account.GetById.UseCase>();
            services.AddTransient<Account.List.IUseCase, Account.List.UseCase>();

            services.AddTransient<AccountingEntry.Create.IUseCase, AccountingEntry.Create.UseCase>();
            services.AddTransient<AccountingEntry.Delete.IUseCase, AccountingEntry.Delete.UseCase>();
            services.AddTransient<AccountingEntry.GetById.IUseCase, AccountingEntry.GetById.UseCase>();
            services.AddTransient<AccountingEntry.List.IUseCase, AccountingEntry.List.UseCase>();

            //Infrastructure
            services.AddTransient<IAuthTokenService, AuthTokenService>();

            //AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping());
                mc.AddProfile(new Identification.Mapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
