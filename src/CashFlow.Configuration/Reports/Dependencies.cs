using AutoMapper;

using CashFlow.Application.Reports;
using CashFlow.Crosscutting;
using CashFlow.Data.Reports;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Configuration.Reports
{
    public static class Dependencies
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {

            services.AddTransient<IDailyConsolidatedReportRepository, DailyConsolidatedReportRepository>();
            services.AddTransient<IDailyConsolidatedReportService, DailyConsolidatedReportService>();
            services.AddTransient<IAuthTokenService, AuthTokenService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Identification.Mapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
