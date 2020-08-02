using System;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public interface ILoginRepo
    {
        Login GetUserByDetails(string username, string pass);
    }
}
