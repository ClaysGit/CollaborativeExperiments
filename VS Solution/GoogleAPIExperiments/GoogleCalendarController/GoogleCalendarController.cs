using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

//Reference our hand-crafted OAuthManager to get tokens for us.
using OAuthManager;

namespace GoogleCalendarController
{
    public class googleCalendarController
    {
        string token;
        CalendarService service;

        // our main object for manipulating the calendar
        public googleCalendarController()
        {
            //Use the OAuthManager form to get an OAuth token...
            using (var tokenForm = new OAuthTokenManagerForm())
            {
                Application.EnableVisualStyles();
                Application.Run(tokenForm);
                token = tokenForm.OAuthToken;
            }

            //Create the Google Service object for Google Calendars
            service = new CalendarService(new BaseClientService.Initializer()
            {
                ApplicationName = "MenuMaster"
            });
        }

        public void addCalendar(string summary, string timeZone)
        {
            //create the new calendar entry we are about to add
            CalendarListEntry calBody = new CalendarListEntry();
            calBody.SummaryOverride = summary;
            calBody.Id = "test";

            // now we create our new insert request, add our authorization token to the insertRequest object, and execute the sucker!
            var  calInsertRequest = service.CalendarList.Insert(calBody);
            calInsertRequest.OauthToken = token;
            var calInsert = calInsertRequest.Execute();
        }
            
    }
}
