using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Resources;
using Saloon4kBLL;

namespace Saloon4K
{
    public class Saloon4KService : ISaloon4KService
    {
        OutgoingWebResponseContext ctx = WebOperationContext.Current.OutgoingResponse;
        string _returnJson = string.Empty;

        public Message GetAllDeals(string countryName)
        {
            try
            {
                var rep = new DealsRepository();
                var content = rep.GetAllDeals(countryName);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetAllDealsOfTheDay(string countryName)
        {
            try
            {
                var rep = new DealsRepository();
                var content = rep.GetAllDealsOfTheDay(countryName);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetAllFeaturedDeals(string countryName)
        {
            try
            {
                var rep = new DealsRepository();
                var content = rep.GetAllFeaturedDeals(countryName);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetDealById(int dealId)
        {
            try
            {
                var rep = new DealsRepository();
                var content = rep.GetDealByIdForService(dealId);
                if (content != null)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetAllDirectories()
        {
            try
            {
                var rep = new CategoriesRepository();
                var content = rep.GetAllCategories();
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetAllSalonsInDirectory(int directoryId, string country)
        {
            try
            {
                var rep = new SaloonsRepository();
                var content = rep.GetAllSaloonsByCategoryId(directoryId, country);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetSalonById(int saloonId)
        {
            try
            {
                var rep = new SaloonsRepository();
                var content = rep.GetSaloonById(saloonId);
                if (content != null)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetUserFavouriteDeals(int userId)
        {
            try
            {
                var rep = new UserFavouriteAndBookedDealsRepository();
                var content = rep.GetAllFavouriteDeals_ByUserId(userId);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetUserBookedDeals(int userId)
        {
            try
            {
                var rep = new UserFavouriteAndBookedDealsRepository();
                var content = rep.GetAllBookedDeals_ByUserId(userId);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message Login(string userName, string password)
        {
            try
            {
                var user = Utilities.Helper.Login(userName, Utilities.Helper.Encrypt(password));
                if (user != null)
                {
                    var returnJson = JsonConvert.SerializeObject(user);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message Register(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["firstName"] != null && o["lastName"] != null && o["userName"] != null && o["password"] != null && o["latitude"] != null && o["longitude"] != null && o["address"] != null && o["city"] != null && o["state"] != null && o["country"] != null && o["phone"] != null && o["facebook"] != null && o["about"] != null && o["deviceId"] != null)
                {
                    var firstName = (string)o["firstName"];
                    var lasName = (string)o["lastName"];
                    var userName = (string)o["userName"];
                    var password = (string)o["password"];
                    var latitude = (string)o["latitude"];
                    var longitude = (string)o["longitude"];
                    var address = (string)o["address"];
                    var city = (string)o["city"];
                    var state = (string)o["state"];
                    var country = (string)o["country"];
                    var phone = (string)o["phone"];
                    var facebook = (string)o["facebook"];
                    var about = (string)o["about"];
                    var deviceId = (string)o["deviceId"];
                    if (Utilities.IsSingleUser(userName))
                    {
                        var rep = new UsersRepository();
                        var user = new User
                        {
                            Firstname = firstName,
                            Lastname = lasName,
                            Username = userName,
                            Password = Utilities.Helper.Encrypt(password),
                            Latitude = latitude,
                            Longitude = longitude,
                            Address = address,
                            City = city,
                            State = state,
                            Country = country,
                            Phone = phone,
                            Facebook = facebook,
                            About = about,
                            Role = UserRoles.User,
                            DeviceId = deviceId,

                        };
                        var returnStatus = rep.InsertUser(user);
                        if (returnStatus != 0)
                        {
                            ctx.StatusCode = HttpStatusCode.Created;
                            _returnJson = user.UserId.ToString();
                        }
                        else
                        {
                            ctx.StatusCode = HttpStatusCode.InternalServerError;
                            _returnJson = "Code:Error";
                        }
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyExists";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message RegisterWithFacebook(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["facebookId"] != null && o["firstName"] != null && o["lastName"] != null && o["userName"] != null && o["country"] != null && o["deviceId"] != null)
                {
                    var facebookId = (string)o["facebookId"];
                    var firstName = (string)o["firstName"];
                    var lasName = (string)o["lastName"];
                    var userName = (string)o["userName"];
                    var country = (string)o["country"];
                    var deviceId = (string)o["deviceId"];
                    if (Utilities.IsSingleUserFacebook(facebookId))
                    {
                        var rep = new UsersRepository();
                        var user = new User
                        {
                            FacebookId = facebookId,
                            Firstname = firstName,
                            Lastname = lasName,
                            Username = userName,
                            Password = "",
                            Latitude = "",
                            Longitude = "",
                            Address = "",
                            City = "",
                            State = "",
                            Country = country,
                            Phone = "",
                            Facebook = "",
                            About = "",
                            Role = UserRoles.User,
                            DeviceId = deviceId
                        };
                        var returnStatus = rep.InsertUser(user);
                        if (returnStatus != 0)
                        {
                            var content = rep.GetUserByFacebookId(facebookId);
                            if (content != null)
                            {
                                var returnJson = JsonConvert.SerializeObject(content);
                                return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                            }
                            else
                            {
                                return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                            }
                        }
                        else
                        {
                            ctx.StatusCode = HttpStatusCode.InternalServerError;
                            _returnJson = "Code:Error";
                        }
                    }
                    else
                    {

                        var rep = new UsersRepository();
                        var content = rep.GetUserByFacebookId(facebookId);
                        if (content != null)
                        {
                            var returnJson = JsonConvert.SerializeObject(content);
                            return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                        }
                        else
                        {
                            return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                        }
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message UpdateProfile(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["firstName"] != null && o["lastName"] != null && o["password"] != null && o["address"] != null && o["country"] != null && o["phone"] != null && o["facebook"] != null && o["about"] != null)
                {
                    var userId = (int)o["userId"];
                    var firstName = (string)o["firstName"];
                    var lasName = (string)o["lastName"];
                    var password = (string)o["password"];
                    var address = (string)o["address"];
                    var country = (string)o["country"];
                    var phone = (string)o["phone"];
                    var facebook = (string)o["facebook"];
                    var about = (string)o["about"];
                    var rep = new UsersRepository();
                    var user = rep.GetUserById(userId);
                    if (user != null)
                    {
                        user.Firstname = firstName;
                        user.Lastname = lasName;
                        user.Password = password;
                        user.Address = address;
                        user.Country = country;
                        user.Phone = phone;
                        user.Facebook = facebook;
                        user.About = about;
                        user.Role = UserRoles.User;
                        user.ModifiedDate = DateTime.Now.Date;
                        user.RecordStatus = RecordStatus.Active;
                        var returnStatus = rep.UpdateUserForApi(user);
                        if (returnStatus != 0)
                        {
                            ctx.StatusCode = HttpStatusCode.Created;
                            _returnJson = user.UserId.ToString();
                        }
                        else
                        {
                            ctx.StatusCode = HttpStatusCode.InternalServerError;
                            _returnJson = "Code:Error";
                        }
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetUserBookedSalons(int userId)
        {
            try
            {
                var rep = new UserBookedAndInterestedSaloonsRepository();
                var content = rep.GetAllBookedSaloons_ByUserId(userId);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetUserInterestedSalons(int userId)
        {
            try
            {
                var rep = new UserBookedAndInterestedSaloonsRepository();
                var content = rep.GetAllInterestedSaloons_ByUserId(userId);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message MakeDealFavourite(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);

                if (o["userId"] != null && o["dealId"] != null)
                {
                    var userId = (int)o["userId"];
                    var dealId = (int)o["dealId"];
                    var rep = new UserFavouriteAndBookedDealsRepository();
                    var isFavourite = rep.GetUserFavouriteDealById(userId, dealId);
                    if (isFavourite == null)
                    {
                        var favouriteDeal = new UserFavouriteAndBookedDeal
                        {
                            DealId = dealId,
                            IsFavourite = true,
                            UserId = userId
                        };
                        rep.InsertFavouriteOrBookedDeal(favouriteDeal);
                        Utilities.Helper.InsertUserPoints(userId, Common.DealFavourite, dealId, Utilities.Helper.GetPoints(Common.DealFavourite));
                        var content = Utilities.Helper.GetPoints(Common.DealFavourite);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyFavourite";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message MakeSalonBooking(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["saloonId"] != null && o["bookingDate"] != null && o["bookingTime"] != null)
                {
                    var userId = (int)o["userId"];
                    var saloonId = (int)o["saloonId"];
                    var bookingDate = (string)o["bookingDate"];
                    var bookingTime = (string)o["bookingTime"];
                    var rep = new UserBookedAndInterestedSaloonsRepository();
                    var isBooked = rep.GetUserBookedSaloonById(userId, saloonId);
                    if (isBooked == null)
                    {
                        var entity = new UserBookedInterestedSaloon()
                        {
                            UserId = userId,
                            SaloonId = saloonId,
                            BookingDate = Convert.ToDateTime(bookingDate),
                            BookingTime = bookingTime,
                            IsBooked = true,
                            IsInterested = false,
                            AddedDate = DateTime.Now.Date,
                        };
                        rep.InsertBookedSaloon(entity);
                        Utilities.Helper.InsertUserPoints(userId, Common.SaloonBooked, saloonId, Utilities.Helper.GetPoints(Common.SaloonBooked));
                        var content = Utilities.Helper.GetPoints(Common.SaloonBooked);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyFavourite";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message MakeSalonInterested(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["saloonId"] != null)
                {
                    var userId = (int)o["userId"];
                    var saloonId = (int)o["saloonId"];
                    var rep = new UserBookedAndInterestedSaloonsRepository();
                    var isInterested = rep.GetUserInterestedSaloonById(userId, saloonId);
                    if (isInterested == null)
                    {
                        var entity = new UserBookedInterestedSaloon()
                        {
                            UserId = userId,
                            SaloonId = saloonId,
                            IsInterested = true,
                            IsBooked = false,
                            AddedDate = DateTime.Now.Date,
                        };
                        rep.InsertInterestedSaloon(entity);
                        Utilities.Helper.InsertUserPoints(userId, Common.SaloonInterested, saloonId, Utilities.Helper.GetPoints(Common.SaloonInterested));
                        var content = Utilities.Helper.GetPoints(Common.SaloonInterested);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        ctx.StatusCode = HttpStatusCode.BadRequest;
                        _returnJson = "Code:AlreadyInterested";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetAroundMeSalons(string latitude, string longitude)
        {
            try
            {
                var rep = new SaloonsRepository();
                List<ListGetAroundMeSalons> content = rep.GetAroundMe(latitude, longitude);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetUserOrderList(int userId)
        {
            try
            {
                var rep = new UsersRepository();
                var content = rep.GetUserOrderList(userId);
                if (content != null && content.Count > 0)
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message MakeDealBooking(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["dealId"] != null)
                {
                    var userId = (int)o["userId"];
                    var dealId = (int)o["dealId"];
                    var rep = new UserFavouriteAndBookedDealsRepository();
                    var isBooked = rep.GetUserBookedDealById(userId, dealId);
                    if (isBooked == null)
                    {
                        var entity = new UserFavouriteAndBookedDeal()
                        {
                            UserId = userId,
                            DealId = dealId,
                            IsBooked = true,
                            AddedDate = DateTime.Now.Date,
                            IsFavourite = false
                        };
                        rep.InsertFavouriteOrBookedDeal(entity);
                        Utilities.Helper.InsertUserPoints(userId, Common.DealBooked, dealId, Utilities.Helper.GetPoints(Common.DealBooked));
                        var content = Utilities.Helper.GetPoints(Common.DealBooked);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyFavourite";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        //April 8 2014
        public Message DeleteUserOrderItem(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["entityId"] != null && o["type"] != null)
                {
                    var userId = (int)o["userId"];
                    var entityId = (int)o["entityId"];
                    var type = (string)o["type"];
                    if (type == "Salon")
                    {
                        var rep = new UserBookedAndInterestedSaloonsRepository();
                        var isBooked = rep.GetUserBookedSaloonById(userId, entityId);
                        if (isBooked != null)
                        {
                            rep.DeleteUserBookedSalon(userId, entityId);
                            Utilities.Helper.DeleteUserPoints(userId, Common.SaloonBooked, entityId, Utilities.Helper.GetPoints(Common.SaloonBooked));
                            var content = Utilities.Helper.GetPoints(Common.SaloonBooked);
                            _returnJson = JsonConvert.SerializeObject(content);
                        }
                        else
                        {
                            _returnJson = "Code:AlreadyDeleted";
                        }
                    }
                    else if (type == "Deal")
                    {
                        var rep = new UserFavouriteAndBookedDealsRepository();
                        var isBooked = rep.GetUserBookedDealById(userId, entityId);
                        if (isBooked != null)
                        {
                            rep.DeleteUserBookedDeal(userId, entityId);
                            Utilities.Helper.DeleteUserPoints(userId, Common.DealBooked, entityId, Utilities.Helper.GetPoints(Common.DealBooked));
                            var content = Utilities.Helper.GetPoints(Common.DealBooked);
                            _returnJson = JsonConvert.SerializeObject(content);
                        }
                        else
                        {
                            _returnJson = "Code:AlreadyDeleted";
                        }
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message DeleteUserFavouriteDeal(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["dealId"] != null)
                {
                    var userId = (int)o["userId"];
                    var dealId = (int)o["dealId"];
                    var rep = new UserFavouriteAndBookedDealsRepository();
                    var isBooked = rep.GetUserFavouriteDealById(userId, dealId);
                    if (isBooked != null)
                    {
                        rep.DeleteUserFavouriteDeal(userId, dealId);
                        Utilities.Helper.DeleteUserPoints(userId, Common.DealFavourite, dealId, Utilities.Helper.GetPoints(Common.DealFavourite));
                        var content = Utilities.Helper.GetPoints(Common.DealFavourite);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyDeleted";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message DeleteUserInterestedSalon(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["salonId"] != null)
                {
                    var userId = (int)o["userId"];
                    var salonId = (int)o["salonId"];
                    var rep = new UserBookedAndInterestedSaloonsRepository();
                    var isBooked = rep.GetUserInterestedSaloonById(userId, salonId);
                    if (isBooked != null)
                    {
                        rep.DeleteUserInterestedSaloon(userId, salonId);
                        Utilities.Helper.DeleteUserPoints(userId, Common.SaloonInterested, salonId, Utilities.Helper.GetPoints(Common.SaloonInterested));
                        var content = Utilities.Helper.GetPoints(Common.SaloonInterested);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyDeleted";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetUserTotalPoints(int userId)
        {
            try
            {
                var content = Utilities.Helper.GetUserPoints(userId);
                if (!string.IsNullOrEmpty(content.ToString()))
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        //September 8 2014
        public Message DeleteUserBookedDeal(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["dealId"] != null)
                {
                    var userId = (int)o["userId"];
                    var dealId = (int)o["dealId"];
                    var rep = new UserFavouriteAndBookedDealsRepository();
                    var isBooked = rep.GetUserBookedDealById(userId, dealId);
                    if (isBooked != null)
                    {
                        rep.DeleteUserBookedDeal(userId, dealId);
                        Utilities.Helper.DeleteUserPoints(userId, Common.DealBooked, dealId, Utilities.Helper.GetPoints(Common.DealBooked));
                        var content = Utilities.Helper.GetPoints(Common.DealBooked);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyDeleted";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message DeleteUserBookedSalon(Stream json)
        {
            try
            {
                var reader = new StreamReader(json);
                var postData = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                var o = JObject.Parse(postData);
                if (o["userId"] != null && o["salonId"] != null)
                {
                    var userId = (int)o["userId"];
                    var salonId = (int)o["salonId"];
                    var rep = new UserBookedAndInterestedSaloonsRepository();
                    var isBooked = rep.GetUserBookedSaloonById(userId, salonId);
                    if (isBooked != null)
                    {
                        rep.DeleteUserBookedSalon(userId, salonId);
                        Utilities.Helper.DeleteUserPoints(userId, Common.SaloonBooked, salonId, Utilities.Helper.GetPoints(Common.SaloonBooked));
                        var content = Utilities.Helper.GetPoints(Common.SaloonBooked);
                        _returnJson = JsonConvert.SerializeObject(content);
                    }
                    else
                    {
                        _returnJson = "Code:AlreadyDeleted";
                    }
                }
                else
                {
                    ctx.StatusCode = HttpStatusCode.BadRequest;
                    _returnJson = "Code:NoResult";
                }
                return WebOperationContext.Current.CreateTextResponse(_returnJson, "application/json; charset=utf-8", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                ctx.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return WebOperationContext.Current.CreateTextResponse("Failure", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }

        public Message GetUserById(int userId)
        {
            try
            {
                var rep = new UsersRepository();
                var content = rep.GetUserById(userId);
                if (!string.IsNullOrEmpty(content.ToString()))
                {
                    var returnJson = JsonConvert.SerializeObject(content);
                    return WebOperationContext.Current.CreateTextResponse(returnJson, "application/json; charset=utf-8", Encoding.UTF8);
                }
                else
                {
                    return WebOperationContext.Current.CreateTextResponse("Code:NoResult", "application/json; charset=utf-8", Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                return WebOperationContext.Current.CreateTextResponse("Code:Error", "application/json; charset=utf-8", Encoding.UTF8);
            }
        }
    }
}
