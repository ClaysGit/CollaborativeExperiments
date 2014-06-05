using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

//Reference our hand-crafted OAuthManager to get tokens for us.
using OAuthManager;

namespace Launcher
{
    class Program
    {
        //This Attribute describes the context in which it should be executed.
        // It's unimportant for Console applications, but necessary for any application
        // that wants to use a Windows Form, which we do to get the OAuth2.0 Token.
        [STAThread]
        static void Main(string[] args)
        {
            //Use the OAuthManager form to get an OAuth token...
            var token = "";
            using(var tokenForm = new OAuthTokenManagerForm())
            {
                Application.EnableVisualStyles();
                Application.Run(tokenForm);
                token = tokenForm.OAuthToken;
            }
            
            //Create the Google Service object for Google Calendars
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                ApplicationName = "MenuMaster"
            });

            //Get an object that describes our request:
            // - From the Calendar service, request a list of available calendars
            var calsReq = service.CalendarList.List();
            // - Set our token
            calsReq.OauthToken = token;
            // - Execute the request, get the result
            var cals = calsReq.Execute();

            //Write the ID of each calendar
            foreach (var cal in cals.Items)
            {
                Console.WriteLine(cal.Id);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to quit...");

            Console.ReadLine();
        }
    }
}
