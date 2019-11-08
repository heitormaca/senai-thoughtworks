using System.Threading.Tasks;
using TW.Models;
using TW.ViewModel;

namespace TW.Interfaces
{
    public interface ILoginRepositorio
    {
         Usuario Login(LoginViewModel login);
    }
}