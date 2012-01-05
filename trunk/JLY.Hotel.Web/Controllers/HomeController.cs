using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JLY.Hotel.Web.Infrastucture;

namespace JLY.Hotel.Web.Controllers
{
    using JLY.Hotel.ServiceView.ServicesInterface;

    public class HomeController : BaseController
    {
        private IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View("Index",homeService.GetDefault());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
