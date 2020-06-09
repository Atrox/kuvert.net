using System.Threading.Tasks;
using RazorLight;

namespace Kuvert
{
    public class RazorRenderer : IKuvertRenderer
    {
        private readonly RazorLightEngine _engine;

        public RazorRenderer()
        {
            _engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(IKuvert))
                .UseMemoryCachingProvider()
                .Build();
        }

        public async Task<string> ParseAsync<T>(string key, string template, T model)
        {
            return await _engine.CompileRenderStringAsync(key, template, model);
        }
    }
}
