using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JLY.Hotel.ServiceView.ServicesInterface;

namespace JLY.Hotel.ServiceView.Services
{
    using JLY.Hotel.Model.Repositories;
    using JLY.Hotel.ServiceView.Views;
    using JLY.Hotel.ServiceView.ViewsInterface;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class HomeService : BaseService, IHomeService
    {
        private IUserRepository userRepository;

        public HomeService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IHomeView GetDefault()
        {
            IHomeView myView = new HomeView();
            myView.FirstUser = userRepository.GetUserById(1).Name;
            return myView;
        }
    }
}
