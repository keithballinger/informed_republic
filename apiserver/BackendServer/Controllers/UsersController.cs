using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendServer.Controllers
{
    // Describes an issue
    public class IssueState
    {
        // Name of the issue
        public string Name { get; set; }

        // How "hot" is the issue, from 1..100. 
        public int Hotness { get; set; }
    }

    // Alerts are like items in an RSS feed
    public class Alert
    {
        public string UrlImage { get; set; } 
        public string Link { get; set; } // link for more information
        public string Text { get; set; } // text to display over link
    }

    public class TimelineData
    {
        public DateTime Date { get; set; } // when the event occured
        public string Link { get; set; } // Link to more info
        public string Text { get; set; } // text to display over link
    }

    public class Player
    {
        public string Name { get; set; } 
        public string UrlImage { get; set; }
        public string Text { get; set; } // ??? What's this?
        public string Link { get; set; }
    }
 

    public class UsersController : ApiController
    {
        DataModel _model = new DataModel();

        // Returns all issues
        [HttpGet]
        public string[] GetIssues()
        {
            return new string[] { 
                "Gun rights", "Abortion", "Immigration", "Privacy"
            };
        }

        // Add issue to the list of issues this user cares about
        [HttpPost]
        public void AddIssue(string user, string issue)
        {

        }

        [HttpGet]
        public string[] GetUserIssues(string user)
        {
            return new string[] { "Privacy", "Immigration", "Healthcare" };
        }

        [HttpGet]
        public IssueState GetStatus(string issue)
        {
            // Immigration - 75 
            // Privacy - 50 
            // Healthcare - 10
            return new IssueState            
            {
                Name = issue,
                Hotness = _model.GetRating(issue)
            };
        }
                        
        [HttpGet]
        public IssueState[] GetIssuesForUser(string user)
        {
            var issues = GetUserIssues(user);
            var states = Array.ConvertAll(issues, issue => GetStatus(issue));
            return states;
        }

        [HttpGet]
        public Alert[] GetAlerts(string user)
        {
            var issues = GetUserIssues(user);
            var x = _model.GetAlerts(issues);
            return x.ToArray();
        }
        
        [HttpGet]
        public Alert[] GetAction(string user)
        {
            var issues = GetUserIssues(user);
            var x = _model.GetActions(issues);
            return x.ToArray();
        }
        
        [HttpGet]
        public TimelineData[] GetTimeline(string user, DateTime start, DateTime end)
        {
            var issues = GetUserIssues(user);
            var x = _model.GetEvents(issues);
            return x.ToArray();
        }

        [HttpGet]
        public Player[] GetPlayers(string user)
        {
            return new Player[] 
            { 
                new Player
                {
                    Name= "Mark Zuckerberg",
                    Link="http://en.wikipedia.org/wiki/Mark_Zuckerberg",
                    Text="Assessment: His FWD.us group has been on the airwaves but the impact they are having is still nebulous. Will the group up their ad buys to help push wavering Senators into supporting the comprehensive bill? Still unclear...",
                    UrlImage="http://ts2.mm.bing.net/th?id=H.4620204779047973&pid=1.7&w=168&h=173&c=7&rs=1"
                },

                new Player
                {
                    Name="Ted Cruz (R-TX)",
                    Link="http://en.wikipedia.org/wiki/Ted_Cruz",
                    Text="Assessment: In his six months in the Senate, he has shown a willingness to take on all 99 Senators. Will he use his power as a single Senator to place roadblocks on the progress of comprehensive reform?",
                    UrlImage="http://ts4.mm.bing.net/th?id=H.4893819929299603&pid=1.7&w=222&h=176&c=7&rs=1"
                },

                new Player
                {
                    Name="John McCain (R-AZ)",
                    Link="http://en.wikipedia.org/wiki/John_McCain",
                    Text="Assessment: McCain maintains enormous power on the issue given his Arizona constituency and respect he has earned from both parties. His membership in the Gang of 8 and star power can help tilt this outcome over the coming week.",
                    UrlImage="http://ts4.mm.bing.net/th?id=H.4524259476047939&pid=1.7&w=176&h=180&c=7&rs=1"
                }
                /*
                new Player
                {
                    Name = "Eric Snowden",
                    UrlImage = @"http://ts1.mm.bing.net/th?id=HB.210774609816&pid=1.7&w=242&h=164&c=7&rs=1",
                    Link = @"http://en.wikipedia.org/wiki/Edward_Snowden",
                    Text = "something about snowden"
                }*/
            };
        }
    }
}