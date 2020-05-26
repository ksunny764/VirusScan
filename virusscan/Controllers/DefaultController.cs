using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using virusscan.Models;

namespace virusscan.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        string Baseurl = "https://virusscan.jotti.org/api";
        public async Task<ActionResult> Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Baseurl);
            request.Method = "Get";
            request.KeepAlive = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.UseDefaultCredentials = true;
            request.Credentials = new NetworkCredential("vgupta", "Pass@word1", "https://virusscan.jotti.org/login?origin=%2Fapi");
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
           return View();

        }
        
        [HttpPost]
        public JsonResult Index(Employee obj)
        {
            HttpPostedFileBase file;
            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    file = files[i];
                    string fname;
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                        obj.FileName = file.FileName;
                    }
                    //fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                    //file.SaveAs(fname);
                }
            }
            //string value = dbAccess.getData(obj);
            return Json(0);
        }
    }
}