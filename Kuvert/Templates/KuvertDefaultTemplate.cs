using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Kuvert.Templates
{
    public class KuvertDefaultTemplate : IKuvertTemplate
    {
        private const string BasePath = "Kuvert.Templates.Default";

        public string Key() => "default";
        public Task<string> Html() => GetTemplate("Html.cshtml");
        public Task<string> PlainText() => GetTemplate("PlainText.cshtml");

        private static Task<string> GetTemplate(string template)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{BasePath}.{template}");
            using var reader = new StreamReader(stream);
            return reader.ReadToEndAsync();
        }
    }

    public static class KuvertDefaultTemplateExtensions
    {
        public static KuvertServicesBuilder AddDefaultTemplate(this KuvertServicesBuilder builder)
        {
            builder.Services.AddSingleton<IKuvertTemplate, KuvertDefaultTemplate>();
            return builder;
        }
    }
}
