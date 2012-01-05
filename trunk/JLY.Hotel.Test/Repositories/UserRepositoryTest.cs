using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JLY.Hotel.Model.Entities;
using JLY.Hotel.Model.Repositories;
using JLY.Hotel.Repository;
using JLY.Hotel.Repository.DB;
using NUnit.Framework;

namespace JLY.Hotel.Test.Repositories
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private IUserRepository _UserRepository;


        [SetUp]
        public void Setup()
        {
            var _dbContext = new HotelDB();
            _UserRepository = new UserRepository(_dbContext);
        }

        [Test]
        public void GetUserByIdTest()
        {
            IUser user = _UserRepository.GetUserById(4);
            Assert.IsTrue(user!=null);
        }

        [Test]
        public void GetUserBynamepasas()
        {
            IUser user = _UserRepository.GetUserByNamePassword("admin", "a123456");
            Assert.IsTrue(user != null);
        }

    }
}
