using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace Test
{
    /// <summary>
    /// Summary description for FetchDetails
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FetchDetails : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetData(string fname, string lname)
        {
            Form item = new Form();
            item.FirstName = fname;
            item.LastName = lname;

            string JsonResult = JsonConvert.SerializeObject(item);
            string path = ConfigurationManager.AppSettings["filepath"].ToString();

            //Checking if File exists, if exists it wll delete it and create a new file and update the details.
            if (File.Exists(path))
            {
                File.Delete(path);  
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JsonResult.ToString());
                    tw.Close();
                }

            }
            //If file don't exists, it will create the file.
            else if(!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JsonResult.ToString());
                    tw.Close();
                }
            }
        }
    }
}
