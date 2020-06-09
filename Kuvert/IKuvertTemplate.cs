using System.Threading.Tasks;

namespace Kuvert
{
    public interface IKuvertTemplate
    {
        public string Key();
        public Task<string> Html();
        public Task<string> PlainText();
    }
}
