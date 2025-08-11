using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using statejitsss.BAL.Interfaces;
using statejitsss.BAL.Services;
using statejitsss.DAL;
using statejitsss.DAL.Interfaces;
using statejitsss.DAL.Repositories;
using statejitsss.RabbitMQ.Config;
using statejitsss.RabbitMQ.Helper;
using statejitsss.RabbitMQ.Interfaces;
using statejitsss.RabbitMQ.Repositories;

namespace statejitsss.Dependency
{
    public static class StateJitDependency
    {
        public static IServiceCollection AddStateJitDependencies(this IServiceCollection services)
        {
            #region Services
            //Services
            services.AddSingleton<DapperContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMasterService, MasterService>();
            #endregion

            #region RabbitMQ Configuration
            services.AddTransient<IConsumeLogRepository, ConsumeLogRepository>();
            services.AddTransient<IRabbitMqService, RabbitMqService>();
            services.AddTransient<IRabbitMQTransactionRepo, RabbitMQTransactionRepo>();
            services.AddTransient<RabbitMQHelper>();
            #endregion

            #region Repositories
            //Repositories
            services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
            services.AddScoped<IMasterRepository, MasterRepository>();
            #endregion

            return services;
        }
    }
}
