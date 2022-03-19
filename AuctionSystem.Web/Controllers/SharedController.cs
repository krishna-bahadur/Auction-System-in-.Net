using AuctionSystem.Entities;
using AuctionSystem.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionSystem.Web.Controllers
{
    public class SharedController : Controller
    {
        SharedService service = new SharedService();
         [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult result = new JsonResult();
            List<object> pictureJson = new List<object>();
            var pictures = Request.Files;
            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];
                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                var path = Server.MapPath("~/Content/images/") + fileName;
                picture.SaveAs(path);
                var dbPicture = new Picture();
                dbPicture.URL = fileName;
               int pictureId = service.SavePicture(dbPicture);
                pictureJson.Add(new { Id = pictureId, pictureUrl = fileName });
            }
            result.Data = pictureJson;
            return result;
        }
    }
}