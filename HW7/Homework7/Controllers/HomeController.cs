using System.Web.Mvc;
using Homework7.DAL;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Homework7.Models;
using System;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {
        // To save information to the database 
        private SearchLogContext sc = new SearchLogContext();

        // Find the key needed to grab stickers from Giphy
        private string APIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sends out the search request to Giphy and then queries the Giphy API and load the image data
        /// </summary>
        /// <param name="searchString">what was searched</param>
        /// <returns>The requested images as a JSON object</returns>
        public JsonResult GetData(string searchString)
        {
            // Log the search
            LogSearch(searchString);

            // Send off the search to Giphy with attached APIKey
            string getSticker = "http://api.giphy./com/v1/stickers/translate" + searchString + "&api_key" + APIKey;

            // Open a stream to gather the images
            WebRequest request = WebRequest.Create(getSticker);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string stickerData = reader.ReadToEnd();

            // close the stream
            reader.Close();
            response.Close();
            dataStream.Close();

            // convert to JSON and then return the images
            string sticker = JsonConvert.SerializeObject(stickerData);
            return Json(sticker, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Loads the searches into the database
        /// </summary>
        /// <param name="searchString">what was searched</param>
        private void LogSearch(string searchString)
        {
            // Model to which we need to save 
            SearchLog logSearch = new SearchLog
            {
                Search = searchString,
                SearchIP = Request.UserHostAddress,
                TimeStamp = DateTime.Now
            };

            // Save to the database
            sc.SearchLogs.Add(logSearch);
            sc.SaveChanges();
        }
    }
}