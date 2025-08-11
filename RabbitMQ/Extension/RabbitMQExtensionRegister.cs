using FluentValidation;
using statejitsss.RabbitMQ.Config;
using statejitsss.RabbitMQ.Models;

namespace statejitsss.RabbitMQ.Extension
{
    public static class RabbitMQExtensionRegister
    {
        public static IServiceCollection AddRabbitMQ(
        this IServiceCollection services,
        IConfiguration configuration)

        {
            var rabbitMQConfig = configuration.GetSection("RabbitMQ").Get<RabbitMQConfigurationModel>();
            if (rabbitMQConfig == null)
            {
                throw new InvalidOperationException("RabbitMQ configuration is missing");
            }

            services.AddSingleton(rabbitMQConfig);
            services.AddSingleton<IRabbitMQConnectionFactory, RabbitMQConnectionFactory>();

            return services;
        }


        public static IServiceCollection AddMessageProcessing(
        this IServiceCollection services)
        {

            //consumers
            //services.AddScoped<IValidator<List<RejecteFtoDetailDataModel>>, RejectedFtoValidator>();
            //services.AddScoped<IMessageProcessor<List<RejecteFtoDetailDataModel>>, RejectedFtoService>();
            //services.AddHostedService<RejectedFtoConsumer>();



            //ack

            return services;
        }
    }
}
