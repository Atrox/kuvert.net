﻿using System;
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

            // ensure product is set
            if (options.Product == null)
                throw new ArgumentException("product needs to be set", nameof(options.Product));

            // razor renderer
            services.AddSingleton<IKuvertRenderer, RazorRenderer>();

            // kuvert service
            services.AddSingleton<IKuvert>(provider =>
                new KuvertService(
                    provider.GetRequiredService<IKuvertRenderer>(),
                    provider.GetRequiredService<IKuvertTemplate>(),
                    options.Product));

            return new KuvertServicesBuilder(services);
        }
    }

    public class KuvertServiceOptions
    {
        public Product? Product { get; set; }
    }

    public class KuvertServicesBuilder
    {
        internal KuvertServicesBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
