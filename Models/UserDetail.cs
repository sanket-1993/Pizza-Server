
namespace Models
{
    public class UserDetail: SignInDetail
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }

        public int Result { get; set; }
    }
}
