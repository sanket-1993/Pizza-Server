using Contract;
using Models;
using System;

namespace Repository
{
    public class UserService : IUserService
    {
        public UserDetail SignIn(SignInDetail signin)
        {
            try
            {
                UserDetail userDetail = new UserDetail();
                userDetail.UserId = 1;
                //To do - Check credentials;
                if(signin.Email == "sanket159@gmail.com" && signin.Password == "sanket123")
                {
                    userDetail.Result = 1;
                }
                return userDetail;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}
