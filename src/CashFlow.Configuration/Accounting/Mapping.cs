using AutoMapper;
using CashFlow.Application.Accounting.Dtos;
using CashFlow.Domain.Accounting;
using System.Diagnostics.CodeAnalysis;

namespace CashFlow.Configuration.Accounting
{
    [ExcludeFromCodeCoverage]
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountingEntry, AccountingEntryDto>();
        }
    }
}
