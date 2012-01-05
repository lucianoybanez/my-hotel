using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JLY.Hotel.ServiceView.Services;

namespace JLY.Hotel.Web.Controllers
{
    public class BaseController : Controller
    {
        public void AddError(IList<IErrors> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError(string.Empty,item.Message);
            }
        }
    }
}