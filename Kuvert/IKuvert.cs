using System;
using System.Threading.Tasks;
using Kuvert.Models;

namespace Kuvert
{
    public interface IKuvert
    {
        public Task<ValueTuple<string, string>> Generate(Email email);

        public Task<string> GenerateHtml(Email email);
        public Task<string> GeneratePlainText(Email email);
    }
}
