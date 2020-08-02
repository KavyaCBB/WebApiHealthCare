using System;
using System.Linq;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public class LoginRepo: ILoginRepo
    {
        private readonly HealthCareDbContext _healthCareDbContext;
        public LoginRepo(HealthCareDbContext healthCareDbContext)
        {
            _healthCareDbContext = healthCareDbContext;
        }

        public Login GetUserByDetails(string username, string pass)
        {
            var loginDetails = _healthCareDbContext.Login.Where(x => x.Name == username && x.Password == pass).FirstOrDefault();
            Login log = new Login();
            if (loginDetails != null)
            {
                log.Name = loginDetails.Name;
                log.Password = loginDetails.Password;
                log.Email = loginDetails.Email;

                return log;
            }
            return null;
        }
         
    }
}
