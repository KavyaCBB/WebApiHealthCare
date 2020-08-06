using System;
using WebApiHealthCare.Data;
using System.Threading.Tasks;
namespace WebApiHealthCare.Repository
{
    public interface ILoginRepo
    {
        Task<Login> GetUserByDetails(string username, string pass);
        Task<int> AddUserDetails(Login loginDetails);
        Task UpdateUser(Login loginDetails);
        Task<int> DeleteUser(int? loginId);
    }
}
