using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JLY.Hotel.ServiceView.Services
{
    public class Errors : IErrors
    {
        public TypeError TypeError { get; set; }
        public string Message { get; set; }
    }
}
