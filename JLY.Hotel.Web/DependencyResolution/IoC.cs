using StructureMap;
using JLY.Hotel.ServiceView.Services;
using JLY.Hotel.ServiceView.ServicesInterface;

namespace JLY.Hotel.Web {
    

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
                        });
            return ObjectFactory.Container;
        }

        private static void ServicesView(IInitializationExpression x)
        {
            x.For<IHomeService>().Use<HomeService>();
        }
    }
}