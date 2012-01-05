using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLY.Hotel.ServiceView.ServicesInterface
{
    public interface IUserService : IBaseService
    {
        bool IsAccountValid(string username, string password);
    }
}
