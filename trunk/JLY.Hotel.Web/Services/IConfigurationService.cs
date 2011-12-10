using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLY.Hotel.Web.Services
{
    public interface IConfigurationService
    {
        string SmtpServer { get; }
    }
}
