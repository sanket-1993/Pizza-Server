using Models;

namespace Contract
{
    public interface IUserService
    {
        UserDetail SignIn(SignInDetail signin);
    }
}
