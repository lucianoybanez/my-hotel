using JLY.Hotel.Infrastructure;

namespace JLY.Hotel.ServiceView.Services
{
    public enum TypeError
    {
        [StringValue("Not Exist")]
        NotExist,
        None
    }

    public interface IErrors
    {
        TypeError TypeError { get; set; }
        string Message { get; set; }
    }
}