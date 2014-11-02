using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace Saloon4K
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISaloon4KService" in both code and config file together.
    [ServiceContract]
    public interface ISaloon4KService
    {
        //GetAllDeals?countryName=Kuwait
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllDeals?countryName={countryName}")]
        Message GetAllDeals(string countryName);

        //GetAllDealsOfTheDay?countryName=Kuwait
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllDealsOfTheDay?countryName={countryName}")]
        Message GetAllDealsOfTheDay(string countryName);

        //GetAllFeaturedDeals?countryName=Kuwait
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllFeaturedDeals?countryName={countryName}")]
        Message GetAllFeaturedDeals(string countryName);

        //GetDealById?dealId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetDealById?dealId={dealId}")]
        Message GetDealById(int dealId);

        //GetAllDirectories
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllDirectories")]
        Message GetAllDirectories();

        //GetAllSalonsInDirectory?directoryId=1&countryName=Kuwait
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllSalonsInDirectory?directoryId={directoryId}&countryName={countryName}")]
        Message GetAllSalonsInDirectory(int directoryId, string countryName);

        //GetSaloonById?saloonId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetSalonById?saloonId={saloonId}")]
        Message GetSalonById(int saloonId);

        //GetUserFavouriteDeals?userId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserFavouriteDeals?userId={userId}")]
        Message GetUserFavouriteDeals(int userId);

        //GetUserBookedDeals?userId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserBookedDeals?userId={userId}")]
        Message GetUserBookedDeals(int userId);

        //Login?userName=wakeel@bravado.ae&password=123456
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Login?userName={userName}&password={password}")]
        Message Login(string userName, string password);

        //{"firstName":"Vipin","lastName":"Kumar","userName":"vipin@bravado.ae","password":"123456","latitude":"29.3684066","longitude":"47.974328900000046","address":"Dubai","city":"Dubai","state":"NULL","country":"Kuwait","phone":"0559193366","facebook":"www.facebook.com/test.user","about":"this is about me text","deviceId":"50c635c406a6f9305c6fb46a5f078806bfe4ba39076afdc9367b11a9fc66771e"}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Register")]
        Message Register(Stream json);

        //{"facebookId":"890164654333623","firstName":"Vipin","lastName":"Kumar","userName":"vipin@bravado.ae","country":"Kuwait","deviceId":"50c635c406a6f9305c6fb46a5f078806bfe4ba39076afdc9367b11a9fc66771e"}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterWithFacebook")]
        Message RegisterWithFacebook(Stream json);

        //{"userId":2,"firstName":"Vipin","lastName":"Kumar","password":"123456","address":"Dubai","country":"Kuwait","phone":"0559193366","facebook":"www.facebook.com/test.user","about":"this is about me text"}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateProfile")]
        Message UpdateProfile(Stream json);

        //GetUserBookedSalons?userId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserBookedSalons?userId={userId}")]
        Message GetUserBookedSalons(int userId);

        //GetUserInterestedSalons?userId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserInterestedSalons?userId={userId}")]
        Message GetUserInterestedSalons(int userId);

        //{"userId":1,"dealId":1}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MakeDealFavourite")]
        Message MakeDealFavourite(Stream json);

        //{"userId":1,"saloonId":1,"bookingDate":"3-30-2014","bookingTime":"12:30 PM","points":"100"}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MakeSalonBooking")]
        Message MakeSalonBooking(Stream json);

        //{"userId":1,"saloonId":1}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MakeSalonInterested")]
        Message MakeSalonInterested(Stream json);

        //GetAroundMeSalons?latitude=25.0952928&Longitude=55.19554449999998
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAroundMeSalons?latitude={latitude}&longitude={longitude}")]
        Message GetAroundMeSalons(string latitude, string longitude);

        //GetUserOrderList?userId=3
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserOrderList?userId={userId}")]
        Message GetUserOrderList(int userId);

        //{"userId":1,"dealId":1,"salonId":1,"points":"100"}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MakeDealBooking")]
        Message MakeDealBooking(Stream json);

        //April 8 2014

        //{"userId":1,"entityId":1,"type":"Salon"}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteUserOrderItem")]
        Message DeleteUserOrderItem(Stream json);

        //{"userId":3,"dealId":1}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteUserFavouriteDeal")]
        Message DeleteUserFavouriteDeal(Stream json);

        //{"userId":3,"salonId":1}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteUserInterestedSalon")]
        Message DeleteUserInterestedSalon(Stream json);

        //{"userId":3,"dealId":1}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteUserBookedDeal")]
        Message DeleteUserBookedDeal(Stream json);

        //{"userId":3,"salonId":1}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteUserBookedSalon")]
        Message DeleteUserBookedSalon(Stream json);

        //GetUserTotalPoints?userId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserTotalPoints?userId={userId}")]
        Message GetUserTotalPoints(int userId);

        //GetUserById?userId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserById?userId={userId}")]
        Message GetUserById(int userId);

        //22-10-2014
        //GetUserVouchersByUserId?userId=1
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUserVouchersByUserId?userId={userId}")]
        Message GetUserVouchersByUserId(int userId);

        //{"userVoucherId":3}
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteUserVoucher")]
        Message DeleteUserVoucher(Stream json);

        //Get Mobile Adds
        //GetMobileAdds?Country=Kuwait&AddFor=Deal&IsPublic=True
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetMobileAdds?Country={Country}&AddFor={AddFor}&IsPublic={IsPublic}")]
        Message GetMobileAdds(string country, string addFor, bool isPublic);
    }
}

