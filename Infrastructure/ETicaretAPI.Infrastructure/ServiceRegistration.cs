using GOAL.Application.Abstractions.Services;
using GOAL.Application.Abstractions.Services.Configurations;
using GOAL.Application.Abstractions.Storage;
using GOAL.Application.Abstractions.Token;
using GOAL.Infrastructure.Enums;
using GOAL.Infrastructure.Services;
using GOAL.Infrastructure.Services.Configurations;
using GOAL.Infrastructure.Services.Storage;
using GOAL.Infrastructure.Services.Storage.Azure;
using GOAL.Infrastructure.Services.Storage.Local;
using GOAL.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace GOAL.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
            serviceCollection.AddScoped<IQRCodeService, QRCodeService>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
