using System.Web;

namespace Saloon4kBLL
{
    public class SystemManagerSession
    {
        private SystemManagerSession()
        {
            SystemManagerProfile = null;
            IsSystemManagerAuthenticated = false;
        }

        public static SystemManagerSession Current
        {
            get
            {
                var session = (SystemManagerSession)HttpContext.Current.Session["__SystemManagerSession__"];
                if (session == null)
                {
                    session = new SystemManagerSession();
                    HttpContext.Current.Session["__SystemManagerSession__"] = session;
                }
                return session;
            }
        }
        public SystemManagerProfile SystemManagerProfile { get; set; }
        public bool IsSystemManagerAuthenticated { get; set; }
    }
    public class SystemManagerProfile
    {
        public int SystemManagerId { get; set; }
        public int SalonId { get; set; }
        public string Role { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string RecordStatus { get; set; }
    }
}
