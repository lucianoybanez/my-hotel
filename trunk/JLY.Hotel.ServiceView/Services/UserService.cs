using System;
using System.Collections.Generic;
using JLY.Hotel.Model.Repositories;
using JLY.Hotel.ServiceView.ServicesInterface;

namespace JLY.Hotel.ServiceView.Services
{
    public class UserService :BaseService, IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool IsAccountValid(string username, string password)
        {
            bool ret = false;
            var user = userRepository.GetUserByNamePassword(username, password);
            if (user==null)
            {
                AddError(TypeError.NotExist,"The User don't exist.");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        public IList<IErrors> GetErrors()
        {
            return base.Errors;
        }
    }
}