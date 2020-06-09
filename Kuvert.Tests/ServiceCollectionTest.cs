using System;
using Kuvert.Models;
using Kuvert.Templates;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Kuvert.Tests
{
    public class ServiceCollectionTest
    {
        [Fact]
        public void TestKuvertServiceCollection()
        {
            var services = new ServiceCollection();

            // require configuration
            Assert.Throws<ArgumentException>(() => { services.AddKuvert(options => { }); });

            // add kuvert
            services.AddKuvert(options =>
            {
                options.Product = new Product("test product", "testlink");
            }).AddDefaultTemplate();
            
            var provider = services.BuildServiceProvider();
            
            // kuvert service
            var kuvertService = provider.GetRequiredService<IKuvert>();
            Assert.IsType<KuvertService>(kuvertService);

            // template service
            var templateService = provider.GetRequiredService<IKuvertTemplate>();
            Assert.IsType<KuvertDefaultTemplate>(templateService);
            
            // renderer service
            var rendererService = provider.GetRequiredService<IKuvertRenderer>();
            Assert.IsType<RazorRenderer>(rendererService);
        }
    }
}
