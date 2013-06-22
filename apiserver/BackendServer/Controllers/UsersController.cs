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
            return new string[] { "Privacy" };
        }

        [HttpGet]
        public IssueState GetStatus(string issue)
        {
            return new IssueState
            {
                Hotness = 75
            };
        }

        [HttpGet]
        public Alert[] GetAlerts(string user)
        {
            return new Alert[]
            {
                new Alert
                {
                     Link = @"http://news.cnet.com/8301-1009_3-57588253-83/what-is-the-nsas-prism-program-faq/",
                     Text = "Learn about PRISM",
                     UrlImage = @"http://ts1.mm.bing.net/th?id=H.4872010103062804&pid=1.7&w=221&h=164&c=7&rs=1"
                },
                new Alert
                {
                    Link= @"http://www.bbc.co.uk/news/magazine-22853432",
                    Text = "BBC on Prism",
                    UrlImage = @"http://ts1.mm.bing.net/th?id=H.4679732980810272&pid=1.7&w=229&h=164&c=7&rs=1"
                }
            };
        }
        
        [HttpGet]
        public Alert[] GetAction(string user)
        {
            return new Alert[]
            {
                new Alert
                {
                    Text = "Sign petition to save Snowden",
                    UrlImage = @"http://ts1.mm.bing.net/th?id=HB.210774609816&pid=1.7&w=242&h=164&c=7&rs=1"
                }
            };
        }


        [HttpGet]
        public TimelineData[] GetTimeline(string user, DateTime start, DateTime end)
        {
            return new TimelineData[]
            {
                new TimelineData
                {
                     Date = new DateTime(2013, 6,1),
                     Text  = "Snowden charged!",
                     Link = @"http://news.msn.com/crime-justice/us-charges-snowden-with-espionage?ocid=ansnews11"
                }
            };
        }

        [HttpGet]
        public Player[] GetPlayers(string user)
        {
            return new Player[] 
            { 
                new Player
                {
                    Name = "Eric Snowden",
                    UrlImage = @"http://ts1.mm.bing.net/th?id=HB.210774609816&pid=1.7&w=242&h=164&c=7&rs=1",
                    Link = @"http://en.wikipedia.org/wiki/Edward_Snowden",
                    Text = "something about snowden"
                }
            };
        }
    }
}