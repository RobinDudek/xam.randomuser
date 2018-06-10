using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using rdk.randomuser.Api;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace rdk.randomuser.Api
{
    public static class Helper
    {
        internal static string FORMAT = "json";
        internal static string URL = "https://randomuser.me/api/?results=50";
        public static string result;
        

        public static async Task<string> GetUsers()
        {
            try
            {
                var datatask = Utilities.GetRequest(URL);
                return await datatask;
            }
            catch(Exception exception)
            {
                Crashes.TrackError(exception);

                return null;
            }
        }

    }
}
