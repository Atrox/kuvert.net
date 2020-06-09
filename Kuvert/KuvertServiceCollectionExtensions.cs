using System;
using Kuvert.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kuvert
{
    public static class KuvertServiceCollectionExtensions
    {
        public static KuvertServicesBuilder AddKuvert(this IServiceCollection services,
            Action<KuvertServiceOptions> configureService)
        {
            var options = new KuvertServiceOptions();
            configureService?.Invoke(options);

            // razor renderer
            services.AddSingleton<IKuvertRenderer, RazorRenderer>();

            // kuvert service
            services.AddSingleton<IKuvert>(provider =>
                new KuvertService(
                    provider.GetService<IKuvertRenderer>(),
                    provider.GetService<IKuvertTemplate>(),
                    options.Product));

            return new KuvertServicesBuilder(services);
        }
    }

    public class KuvertServiceOptions
    {
        public Product Product { get; set; }
    }

    public class KuvertServicesBuilder
    {
        public IServiceCollection Services { get; private set; }

        internal KuvertServicesBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
