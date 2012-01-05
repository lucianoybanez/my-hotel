using StructureMap;
using JLY.Hotel.ServiceView.Services;
using JLY.Hotel.ServiceView.ServicesInterface;
using JLY.Hotel.Model.Repositories;
using JLY.Hotel.Repository;

namespace JLY.Hotel.Web {
    using System.Data.Entity;

    using JLY.Hotel.Repository.DB;

    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            ServicesView(x);
                            Repositories(x);
                        });
            return ObjectFactory.Container;
        }

        private static void Repositories(IInitializationExpression x)
        {
            x.For<DbContext>().Use<HotelDB>();
            x.For<IUserRepository>().Use<UserRepository>();
        }

        private static void ServicesView(IInitializationExpression x)
        {
            x.For<IHomeService>().Use<HomeService>();
            x.For<IUserService>().Use<UserService>();
        }
    }
}