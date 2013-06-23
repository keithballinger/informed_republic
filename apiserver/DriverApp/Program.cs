using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackendServer.Controllers;

namespace DriverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DataModel();
            foreach (var x in d.GetEvents("privacy"))
            {
            }
        }
    }
}
