
using System.Threading.Tasks;

namespace Core.IRepository // Adjust the namespace
{
    public interface ISmsService
    {
        Task SendSmsAsync(string recipient, string message);
    }
}
