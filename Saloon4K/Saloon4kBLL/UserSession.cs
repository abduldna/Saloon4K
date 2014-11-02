using System.Web;

namespace Saloon4kBLL
{
    public class UserSession
    {
        private UserSession()
        {
            UserProfile = null;
            IsUserAuthenticated = false;
        }

        public static UserSession Current
        {
            get
            {
                var session = (UserSession)HttpContext.Current.Session["__UserSession__"];
                if (session == null)
                {
                    session = new UserSession();
                    HttpContext.Current.Session["__UserSession__"] = session;
                }
                return session;
            }
        }
        public Profile UserProfile { get; set; }
        public bool IsUserAuthenticated { get; set; }
    }
    public class Profile
    {
        public int UserId { get; set; }
        public string FacebookId { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string FaceBookAccount { get; set; }
        public string Avatar { get; set; }
        public string About { get; set; }
        public string Country { get; set; }
    }
}
