using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;

namespace Saloon4kBLL
{
    public class Utilities
    {
        /// <summary>
        /// Generic functions
        /// </summary>
        public class Helper
        {
            public static void SetPleaseSelect(ref DropDownList ddl)
            {
                ddl.Items.Insert(0, new ListItem("Select", "0"));
            }
            public static string Encrypt(string toEncrypt)
            {
                var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                var settingsReader = new AppSettingsReader();
                var key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
                var hashmd5 = new MD5CryptoServiceProvider();
                var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                var cTransform = tdes.CreateEncryptor();
                var resultArray =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length);
                tdes.Clear();
                var returnString = Convert.ToBase64String(resultArray, 0, resultArray.Length);
                if (returnString.Contains("+"))
                {
                    returnString = returnString.Replace("+", "$");
                }
                return returnString;
            }
            public static string Decrypt(string cipherString)
            {
                if (cipherString.Contains("$"))
                {
                    cipherString = cipherString.Replace("$", "+");
                }
                var toEncryptArray = Convert.FromBase64String(cipherString);
                var settingsReader = new AppSettingsReader();
                var key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
                var hashmd5 = new MD5CryptoServiceProvider();
                var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                var cTransform = tdes.CreateDecryptor();
                var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Encoding.UTF8.GetString(resultArray);
            }
            public static string AuthenticateUser(string email, string password)
            {
                var str = "";
                using (var conn = new Saloon4KEntities())
                {
                    var a = conn.Users.FirstOrDefault(p => p.Username.ToLower() == email.ToLower());
                    if (a != null)
                    {
                        var decryptPassword = Decrypt(a.Password);
                        if (password == decryptPassword)
                        {
                            var p = new Profile
                                {
                                    UserId = a.UserId,
                                    FacebookId = a.FacebookId,
                                    Role = a.Role,
                                    Username = a.Username,
                                    Password = a.Password,
                                    FirstName = a.Firstname,
                                    LastName = a.Lastname,
                                    Latitude = a.Latitude,
                                    Longitude = a.Longitude,
                                    Address = a.Address,
                                    City = a.City,
                                    State = a.State,
                                    Phone = a.Phone,
                                    FaceBookAccount = a.Facebook,
                                    About = a.About,
                                    Avatar = a.Avatar,
                                    Country = a.Country
                                };
                            UserSession.Current.UserProfile = p;
                            UserSession.Current.IsUserAuthenticated = true;
                            str = "GOOD";
                        }
                        else
                        {
                            str = "Invalid email/password! Please try again.";
                        }
                    }
                    return str;
                }
            }
            public static string AuthenticateSystemManager(string email, string password)
            {
                var str = "";
                using (var conn = new Saloon4KEntities())
                {
                    var a = conn.SystemManagers.FirstOrDefault(p => p.Email.ToLower() == email.ToLower());
                    if (a != null)
                    {
                        var decryptPassword = Decrypt(a.Password);
                        if (password == decryptPassword)
                        {
                            var p = new SystemManagerProfile
                            {
                                SystemManagerId = a.SystemManagerId,
                                Country = a.Country,
                                SalonId = Convert.ToInt32(a.SalonId),
                                Name = a.Name,
                                Email = a.Email,
                                Password = a.Password,
                                Gender = a.Gender,
                                Role = a.Role,
                                RecordStatus = a.RecordStatus
                            };
                            SystemManagerSession.Current.SystemManagerProfile = p;
                            SystemManagerSession.Current.IsSystemManagerAuthenticated = true;
                            str = "GOOD";
                        }
                        else
                        {
                            str = "Invalid email/password! Please try again.";
                        }
                    }
                    return str;
                }
            }
            // ReSharper disable MemberHidesStaticFromOuterClass
            public static void LogInFaceBook(string firstname, string lastname, string fbId, string email, string gender, string birthday)
            // ReSharper restore MemberHidesStaticFromOuterClass
            {
                using (var con = new Saloon4KEntities())
                {
                    var a = con.Users.FirstOrDefault(p => p.FacebookId.Trim() == fbId.Trim());
                    if (a != null)
                    {
                        var p = new Profile
                        {
                            UserId = a.UserId,
                            FacebookId = a.FacebookId,
                            Username = a.Username,
                            Password = a.Password,
                            FirstName = a.Firstname,
                            LastName = a.Lastname,
                            Address = a.Address,
                            City = a.City,
                            Latitude = a.Latitude,
                            Longitude = a.Longitude,
                            State = a.State,
                            Phone = a.Phone,
                            FaceBookAccount = a.Facebook,
                            Role = UserRoles.User,
                            About = a.About,
                            Avatar = a.Avatar,
                            Country = a.Country
                        };
                        UserSession.Current.UserProfile = p;
                        UserSession.Current.IsUserAuthenticated = true;
                    }
                    else
                    {
                        var user = new User();
                        user.FacebookId = fbId;
                        user.Role = UserRoles.User;
                        user.Username = email;
                        user.Password = "";
                        user.Firstname = firstname;
                        user.Lastname = lastname;
                        user.Address = "";
                        user.City = "";
                        user.State = "";
                        user.Latitude = "";
                        user.Longitude = "";
                        user.Phone = "";
                        user.Facebook = "";
                        user.About = "";
                        user.Avatar = "";
                        user.Country = "";
                        user.AddedDate = DateTime.Now.Date;
                        user.ModifiedDate = DateTime.Now.Date;
                        user.RecordStatus = RecordStatus.Active;
                        con.AddToUsers(user);
                        con.SaveChanges();
                        var p = new Profile
                        {
                            UserId = user.UserId,
                            FacebookId = user.FacebookId,
                            Username = user.Username,
                            Password = user.Password,
                            FirstName = user.Firstname,
                            LastName = user.Lastname,
                            Address = user.Address,
                            City = user.City,
                            Latitude = user.Latitude,
                            Longitude = user.Longitude,
                            State = user.State,
                            Phone = user.Phone,
                            FaceBookAccount = user.Facebook,
                            Role = UserRoles.User,
                            About = user.About,
                            Avatar = user.Avatar,
                            Country = user.Country
                        };
                        UserSession.Current.UserProfile = p;
                        UserSession.Current.IsUserAuthenticated = true;
                    }
                }
            }
            /// <summary>
            /// Contact us email generic method
            /// </summary>
            /// <param name="senderEmail"></param>
            /// <param name="senderName"></param>
            /// <param name="senderPhone"></param>
            /// <param name="message"></param>
            /// <param name="adminEmail"></param>
            public static bool SendEmail(string senderEmail, string senderName, string senderPhone, string message, string adminEmail)
            {
                var mm = new MailMessage(senderEmail, adminEmail, senderName + " has sent you a message.", MailBody(senderName, senderEmail, senderPhone, message))
                {
                    IsBodyHtml = true
                };
                try
                {
                    var smtp = new SmtpClient();
                    smtp.Send(mm);
                    mm.Dispose();
                    smtp.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            public static string MailBody(string senderName, string senderEmail, string senderPhone, string message)
            {

                var reader = new StreamReader(ConfigurationManager.AppSettings["SiteRoot"] + @"EmailTemplates\ContactUs.html");
                var body = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                body = body.Replace("<name>", senderName);
                body = body.Replace("<email>", senderEmail);
                body = body.Replace("<phone>", senderPhone);
                body = body.Replace("<comment>", message);
                return body;
            }
            /// <summary>
            /// Point System Rewarding Functions
            /// </summary>
            /// <param name="pointsFor"></param>
            /// <returns></returns>
            public static int GetPoints(string pointsFor)
            {
                Point point;
                using (var conn = new Saloon4KEntities())
                {
                    point = conn.Points.FirstOrDefault(x => x.PointsFor == pointsFor);
                }
                if (point != null)
                {
                    return Convert.ToInt32(point.PointsCount);
                }
                else
                {
                    return 0;
                }
            }
            public static int GetUserPoints(int userId)
            {
                var entity = UsersRepository.GetUserById(userId);
                if (entity != null)
                {
                    return Convert.ToInt32(entity.TotalPoints);
                }
                else
                {
                    return 0;
                }
            }
            public static void BindCountries(ref DropDownList ddl)
            {
                var names = new[] { "Bahrain", "Kuwait", "Oman", "Qatar", "Saudi Arabia", "UAE" };
                foreach (var name in names)
                {
                    var value = name.Replace(" ", "");
                    ddl.Items.Add(new ListItem(name, value));
                }
            }
            public static bool IsNotCategoryBelongToSaloon(int saloonId)
            {
                bool result = false;
                var scRep = new SaloonCategoriesRepository();
                var scList = scRep.GetAllSaloonCategoriesBySaloonId(saloonId);
                if (scList.Count > 0)
                {
                    for (int i = 0; i < scList.Count; i++)
                    {
                        foreach (var item in scList)
                        {
                            item.CategoryId = scList[i].CategoryId;
                            result = true;
                            break;
                        }
                    }

                }
                return result;
            }
            public static bool IsTracked(int userMouseTrackingId)
            {
                var result = false;
                var scRep = new UserMouseTrackingsRepository();
                var entity = scRep.GetUserMouseTrackingById(userMouseTrackingId);
                if (entity != null)
                {
                    result = true;
                }
                return result;
            }
            public static User Login(string email, string password)
            {
                User user;
                const string status = RecordStatus.Deleted;
                using (var conn = new Saloon4KEntities())
                {
                    user = conn.Users.FirstOrDefault(x => x.Username == email && x.RecordStatus != status && x.Password == password);
                }
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            public static void BindChartTypesWithDropDown(ref DropDownList ddl)
            {
                var names = new[] { "Line 2D", "Line 3D", "Column 2D", "Column 3D", "Area 2D", "Area 3D", "Scatter Plot 2D", "Scatter Plot 3D" };
                foreach (var name in names)
                {
                    var value = name.Replace(" ", "");
                    ddl.Items.Add(new ListItem(name, value));
                }
            }
            public static void BindChartType(ref DropDownList ddl, ref Chart chart, string chartSeries)
            {
                if (ddl.SelectedValue == "Line2D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.Line;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                }
                else if (ddl.SelectedValue == "Line3D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.Line;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                }

                else if (ddl.SelectedValue == "Column2D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.Column;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                }

                else if (ddl.SelectedValue == "Column3D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.Column;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                }

                else if (ddl.SelectedValue == "Area2D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.Area;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                }

                else if (ddl.SelectedValue == "Area3D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.Area;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                }

                else if (ddl.SelectedValue == "ScatterPlot2D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.FastPoint;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                }

                else if (ddl.SelectedValue == "ScatterPlot3D")
                {
                    chart.Series[chartSeries].ChartType = SeriesChartType.FastPoint;
                    chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                }
            }
            public static string GetCountryNameToShow(string countryName)
            {
                string name = countryName;
                if (countryName == "UAE" || countryName == "UnitedArabEmirates")
                {
                    name = "United Arab Emirates";
                }
                else if (countryName == "SaudiArabia")
                {
                    name = "Saudi Arabia";
                }
                else if (countryName == "Bahrain")
                {
                    name = "Bahrain";
                }
                else if (countryName == "Kuwait")
                {
                    name = "Kuwait";
                }
                else if (countryName == "Oman")
                {
                    name = "Oman";
                }
                else if (countryName == "Qatar")
                {
                    name = "Qatar";
                }
                return name;
            }
            public static string GetSalonName(int salonId)
            {
                var name = "N/A";
                var rep = new SaloonsRepository();
                var entity = rep.GetSaloonById(salonId);
                if (entity != null)
                {
                    name = entity.Name;
                }
                return name;
            }
            public static string GetDealName(int dealId)
            {
                var name = "N/A";
                var rep = new DealsRepository();
                var entity = rep.GetDealById(dealId);
                if (entity != null)
                {
                    name = entity.Name;
                }
                return name;
            }
            public static string GetUserName(int userId)
            {
                var name = "N/A";
                var rep = new UsersRepository();
                var entity = UsersRepository.GetUserById(userId);
                if (entity != null)
                {
                    name = entity.Firstname + " " + entity.Lastname;
                }
                return name;
            }
            public static string GetVoucherCode()
            {
                var vguid = Guid.NewGuid();
                return vguid.ToString().Substring(0, 8);
            }
            public static void BindPoints(ref DropDownList ddl, int points)
            {
                var endLimit = points / 100;
                var val = 100;
                int index = 1;
                for (int i = 1; i <= endLimit; i++)
                {
                    ddl.Items.Insert(0, new ListItem(val.ToString(), val.ToString()));
                    index++;
                    val += 100;
                }
                ddl.Items.Insert(0, new ListItem("Select", "0"));
            }
            public static void BindRoles(ref DropDownList ddl)
            {
                ddl.Items.Clear();
                var names = new[] { "AdminLevel1", "AdminLevel2", "Manager" };
                foreach (var name in names)
                {
                    ddl.Items.Add(new ListItem(name, name));
                }
                SetPleaseSelect(ref ddl);
            }

        }
        /// <summary>
        /// Login or Register with facebook
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="fbId"></param>
        /// <param name="email"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        public static void LogInFaceBook(string firstname, string lastname, string fbId, string email, string gender, string birthday)
        {
            using (var con = new Saloon4KEntities())
            {
                var a = con.Users.FirstOrDefault(p => p.FacebookId.Trim() == fbId.Trim());
                if (a != null)
                {
                    var p = new Profile
                    {
                        UserId = a.UserId,
                        FacebookId = a.FacebookId,
                        Role = UserRoles.User,
                        Username = a.Username,
                        Password = a.Password,
                        FirstName = a.Firstname,
                        LastName = a.Lastname,
                        Latitude = a.Latitude,
                        Longitude = a.Longitude,
                        Address = a.Address,
                        City = a.City,
                        State = a.State,
                        Phone = a.Phone,
                        FaceBookAccount = a.Facebook,
                        About = a.About,
                        Avatar = a.Avatar,
                        Country = a.Country
                    };
                    UserSession.Current.UserProfile = p;
                    UserSession.Current.IsUserAuthenticated = true;
                }
                else
                {
                    var user = new User
                        {
                            FacebookId = fbId,
                            Role = UserRoles.User,
                            Username = email,
                            Password = "",
                            Firstname = firstname,
                            Lastname = lastname,
                            Address = "",
                            Latitude = "25.294371",
                            Longitude = "55.314574",
                            Phone = "",
                            Facebook = "",
                            About = "",
                            Country = "",
                            Avatar = "N/A",
                            AddedDate = DateTime.Now.Date,
                            ModifiedDate = DateTime.Now.Date,
                            RecordStatus = RecordStatus.Active
                        };
                    con.AddToUsers(user);
                    con.SaveChanges();
                    var p = new Profile
                    {
                        UserId = user.UserId,
                        FacebookId = user.FacebookId,
                        Role = UserRoles.User,
                        Username = user.Username,
                        Password = user.Password,
                        FirstName = user.Firstname,
                        LastName = user.Lastname,
                        Latitude = user.Latitude,
                        Longitude = user.Longitude,
                        Address = user.Address,
                        City = user.City,
                        State = user.State,
                        Phone = user.Phone,
                        FaceBookAccount = user.Facebook,
                        About = user.About,
                        Avatar = user.Avatar,
                        Country = user.Country
                    };
                    UserSession.Current.UserProfile = p;
                    UserSession.Current.IsUserAuthenticated = true;
                }
            }
        }
        /// <summary>
        /// Method to check whether the user with this email is already registered or not.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsSingle(string userName)
        {
            IntermediateUser user;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                user = conn.IntermediateUsers.FirstOrDefault(x => x.Username == userName && x.RecordStatus != status);
            }
            if (user != null)
            {
                return false;
            }
            return true;
        }
        public static bool IsSingleUser(string userName)
        {
            User user;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                user = conn.Users.FirstOrDefault(x => x.Username == userName && x.RecordStatus != status);
            }
            if (user != null)
            {
                return false;
            }
            return true;
        }
        public static bool IsSingleUserFacebook(string facebookId)
        {
            User user;
            const string status = RecordStatus.Deleted;
            using (var conn = new Saloon4KEntities())
            {
                user = conn.Users.FirstOrDefault(x => x.FacebookId == facebookId && x.RecordStatus != status);
            }
            if (user != null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check if the gives string is null or empty
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string IsNull(string txt)
        {
            return string.IsNullOrEmpty(txt) ? "N/A" : txt;
        }
        public class ModuleNames
        {
            public const string Dashboard = "Dashboard";
            public const string Users = "Users";
            public const string Deals = "Deals";
            public const string Directories = "Directories";
            public const string Salons = "Salons";
            public const string Adds = "Adds";
            public const string Points = "Points";
            public const string SystemManagers = "SystemManagers";
        }
    }

    /// <summary>
    /// Record Status to be used in the system
    /// </summary>
    public class RecordStatus
    {
        public const string Active = "Active";
        public const string InActive = "In Active";
        public const string Deleted = "Deleted";
    }

    /// <summary>
    /// User Roles to be used in the system
    /// </summary>
    public class UserRoles
    {
        public const string Administrator = "Administrator";
        public const string User = "User";
    }

    public class AddAlignment
    {
        public const string Top = "Top";
        public const string Right = "Right";
        public const string Left = "Left";
    }

    public class AddPosition
    {
        public const string One = "1";
        public const string Two = "2";
        public const string Three = "3";
    }

    public class AddStatus
    {
        public const string Open = "Open";
        public const string Active = "Active";
        public const string Deleted = "Deleted";
        public const string InActive = "InActive";
    }
    public class DealSalonStatus
    {
        public const string Pending = "Pending";
        public const string Confirmed = "Confirmed";
    }

}
