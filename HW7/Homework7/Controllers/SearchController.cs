using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using Homework7.DAL;
using Homework7.Models;


namespace Homework7.Controllers
{
    public class SearchController : Controller
    {
        // Create an access point to the database
        private SearchLogContext searchLog = new SearchLogContext();

        /// <summary>
        /// Take search words that are in the dictionary and search Giphy stickers
        /// </summary>
        /// <param name="search">search terms for Giphy</param>
        /// <returns>Stickers!</returns>
        public JsonResult SearchGiphy(string search)
        {
            // Log the search results into the database
            LogSearch(search);

            // Grab the key, and then search Giphy
            string getKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            string qurl = "http://api.giphy.com/vq/stickers/translate?api_key=" + getKey + "&s=" + search;

            // Open a data stream to grab the data/stickers
            WebRequest searchRequest = WebRequest.Create(qurl);
            HttpWebResponse searchResponse = (HttpWebResponse)searchRequest.GetResponse();
            Stream dataStream = searchRequest.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            // read the data
            string convertData = new StreamReader(dataStream).ReadToEnd();

            // Close the streams
            reader.Close();
            searchResponse.Close();
            dataStream.Close();

            // Finish converting the data
            var dataSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var results = dataSerializer.DeserializeObject(convertData);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Simple method to log the search queries
        /// </summary>
        /// <param name="search">Log the search text</param>
        private void LogSearch(string search)
        {
            SearchLog temp = new SearchLog
            {
                Search = search,
                SearchIP = Request.UserHostAddress,
                SearchB = Request.UserAgent,
                TimeStamp = DateTime.Now
            };
            searchLog.SearchLogs.Add(temp);
            searchLog.SaveChanges();
        }
    }
}