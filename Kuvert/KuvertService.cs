using System.Threading.Tasks;
using Kuvert.Models;

namespace Kuvert
{
    public class KuvertService : IKuvert
    {
        private readonly IKuvertRenderer _renderer;
        private readonly IKuvertTemplate _template;
        private readonly Product _product;

        public KuvertService(IKuvertRenderer renderer, IKuvertTemplate template, Product product)
        {
            _renderer = renderer;
            _template = template;
            _product = product;
        }

        public async Task<(string, string)> Generate(Email email)
        {
            var result = await Task.WhenAll(GenerateHtml(email), GeneratePlainText(email));
            return (result[0], result[1]);
        }

        public async Task<string> GenerateHtml(Email email)
        {
            var key = $"html-{_template.Key()}";
            var template = await _template.Html();

            var html = await _renderer.ParseAsync(key, template, new TemplateModel(email, _product));
            return PreMailer.Net.PreMailer.MoveCssInline(html, removeComments: true).Html;
        }

        public async Task<string> GeneratePlainText(Email email)
        {
            var key = $"text-{_template.Key()}";
            var template = await _template.PlainText();

            return await _renderer.ParseAsync(key, template, new TemplateModel(email, _product));
        }
    }
}
