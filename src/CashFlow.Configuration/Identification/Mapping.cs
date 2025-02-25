using AutoMapper;
using CashFlow.Application.Identification.Dtos;
using CashFlow.Domain.Identification;

using System.Diagnostics.CodeAnalysis;

namespace CashFlow.Configuration.Identification
{
    [ExcludeFromCodeCoverage]
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>();
        }
    }
}
