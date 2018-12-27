using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Parking_WS.Myclass
{
    public class DBconnect
    {
        public static string ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
            }


        }
    }
}