using System.Collections.Generic;
using JLY.Hotel.ServiceView.Services;

namespace JLY.Hotel.ServiceView.ServicesInterface
{
    public interface IBaseService
    {
        IList<IErrors> GetErrors();
    }
}
