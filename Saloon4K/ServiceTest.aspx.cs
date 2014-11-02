using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PushSharp;
using PushSharp.Apple;

namespace Saloon4K
{
    public partial class ServiceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SendNotification(txtDeviceId.Text.Trim());
            }
            catch (Exception ex)
            {
                divMessage.Visible = true;
                divMessage.InnerHtml = ex.Message;
            }
        }
        public void SendNotification(string deviceId)
        {

            var push = new PushBroker();
            var p12File = ConfigurationManager.AppSettings["PushNotification"];
            var appleCert = File.ReadAllBytes(p12File);
            const bool apnsProduction = true;
            push.RegisterAppleService(new ApplePushChannelSettings(apnsProduction, appleCert, ConfigurationManager.AppSettings["PushPassword"]));
            push.QueueNotification(new AppleNotification().ForDeviceToken(deviceId).WithAlert("New featured deal has been added :)").WithBadge(1).WithSound("default"));
        }
    }
}