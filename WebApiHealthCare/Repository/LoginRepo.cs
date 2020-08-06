using System;
using System.Linq;
using WebApiHealthCare.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiHealthCare.Repository
{
    public class LoginRepo: ILoginRepo
    {
        private readonly HealthCareDbContext _healthCareDbContext;
        public LoginRepo(HealthCareDbContext healthCareDbContext)
        {
            _healthCareDbContext = healthCareDbContext;
        }

        public  async Task<Login> GetUserByDetails(string username, string pass)
        {
            if (_healthCareDbContext != null)
            {
                var loginDetails = await _healthCareDbContext.Login.Where(x => x.Name == username && x.Password == pass).FirstOrDefaultAsync();
                Login log = new Login();
                if (loginDetails != null)
                {
                    log.Name = loginDetails.Name;
                    log.Password = loginDetails.Password;
                    log.Email = loginDetails.Email;
                    log.Loginid = loginDetails.Loginid;
                    log.SocialLoginType = loginDetails.SocialLoginType;
                    log.Token = loginDetails.Token;
                    log.UpdatedOn = loginDetails.UpdatedOn;
                    log.Contact = loginDetails.Contact;
                    log.CreatedOn = loginDetails.CreatedOn;
                    log.DateOfBirth = loginDetails.DateOfBirth;

                    return log;
                }
                
            }
            return null;
        }

        public async Task<int> AddUserDetails(Login loginDetails)
        {
            if (_healthCareDbContext != null)
            {
                var login = new Login()
                {
                    Name = loginDetails.Name,
                    Password = loginDetails.Password,
                    Email = loginDetails.Email,
                    Loginid = loginDetails.Loginid,
                    SocialLoginType = loginDetails.SocialLoginType,
                    Token = loginDetails.Token,
                    UpdatedOn = loginDetails.UpdatedOn,
                    Contact = loginDetails.Contact,
                    CreatedOn = loginDetails.CreatedOn,
                    DateOfBirth = loginDetails.DateOfBirth
                };
                await _healthCareDbContext.Login.AddAsync(login);
                await _healthCareDbContext.SaveChangesAsync();

                return login.Loginid;
            }
            return -1;
        }
        public async Task UpdateUser(Login loginDetails)
        {
            if (_healthCareDbContext != null)
            {
                //update that login
                _healthCareDbContext.Login.Update(loginDetails);

                //Commit the transaction
                await _healthCareDbContext.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteUser(int? loginId)
        {
            int result = 0;

            if (_healthCareDbContext != null)
            {
                //Find the post for specific login id
                var post = await _healthCareDbContext.Login.FirstOrDefaultAsync(x => x.Loginid == loginId);

                if (post != null)
                {
                    //Delete that id
                    _healthCareDbContext.Login.Remove(post);

                    //Commit the transaction
                    result = await _healthCareDbContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }



    }
}
