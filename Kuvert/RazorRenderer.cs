using System.Collections.Generic;
using System.Threading.Tasks;
using RazorLight;
using RazorLight.Razor;

namespace Kuvert
{
    public class RazorRenderer : IKuvertRenderer
    {
        private readonly RazorLightEngine _engine;

        public RazorRenderer()
        {
            _engine = new RazorLightEngineBuilder()
                .UseProject(new InMemoryRazorLightProject())
                .UseMemoryCachingProvider()
                .Build();
        }

        public async Task<string> ParseAsync<T>(string key, string template, T model)
        {
            return await _engine.CompileRenderStringAsync(key, template, model);
        }
    }

    public class InMemoryRazorLightProject : RazorLightProject
    {
        public override Task<RazorLightProjectItem> GetItemAsync(string templateKey)
        {
            return Task.FromResult<RazorLightProjectItem>(new TextSourceRazorProjectItem(templateKey, templateKey));
        }

        public override Task<IEnumerable<RazorLightProjectItem>> GetImportsAsync(string templateKey)
        {
            return Task.FromResult<IEnumerable<RazorLightProjectItem>>(new List<RazorLightProjectItem>());
        }
    }
}
