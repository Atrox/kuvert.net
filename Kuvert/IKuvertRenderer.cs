using System.Threading.Tasks;

namespace Kuvert
{
    public interface IKuvertRenderer
    {
        public Task<string> ParseAsync<T>(string key, string template, T model);
    }
}
