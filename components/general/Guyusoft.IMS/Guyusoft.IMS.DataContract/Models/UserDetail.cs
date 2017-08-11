namespace Guyusoft.IMS.DataContract
{
    public class UserDetail : BaseModel
    {
        public string LoginName { get; set; }

        public string LoginPwd { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PostAddress { get; set; }
    }
}
