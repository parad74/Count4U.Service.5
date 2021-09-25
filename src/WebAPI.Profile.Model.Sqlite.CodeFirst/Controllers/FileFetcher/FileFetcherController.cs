using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Monitor.Service.Model;
using Monitor.Service.Urls;

namespace WebAPI.Monitor.Sqlite.CodeFirst.Controllers
{
    public class FileFetcherController : ControllerBase
    {
        //[HttpGet]
        //[Route(WebApiFileFetcher.GetDefaultProfileXDocument)]
        //public XDocument GetDefaultProfileXDocument()
        //{
        //    XDocument xdoc = new XDocument();
        //    try
        //    {
        //        if (System.IO.File.Exists(@"xml\profile.xml") == true)
        //            xdoc = XDocument.Load(@"xml\profile.xml");
        //    }
        //    catch { }
        //    return xdoc;
        //}

        //[HttpGet]
        //[Route(WebApiFileFetcher.GetDefaultProfileString)]
        //public string GetDefaultProfileString()
        //{
        //    XDocument xdoc = new XDocument();
        //    try
        //    {
        //        if (System.IO.File.Exists(@"xml\profile.xml") == true)
        //            xdoc = XDocument.Load(@"xml\profile.xml");
        //    }
        //    catch { }
        //    return xdoc.ToString();
        //}

        [HttpGet]
        [Route(WebApiFileFetcher.GetDefaultProfileFile)]
        public ActionResult<ProfileFile> GetDefaultProfileFile()
        {
			XDocument xdoc = new XDocument();
			try
			{
				if (System.IO.File.Exists(@"xml\profile.xml") == true)
					xdoc = XDocument.Load(@"xml\profile.xml");
			}
			catch { }
			return new ProfileFile
            {
				ProfileXml = xdoc.ToString(),
			};
		}

    }
}



