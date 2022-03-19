using AuctionSystem.Services;
using AuctionSystem.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionServices service = new AuctionServices();
        public ActionResult Index()
        {
            AuctionsViewModel model = new AuctionsViewModel();
            model.AllAuctions = service.GetAuction();
            model.PromotedAuction= service.GetPromotedAuction();
            model.PageTitle = "Home page";
            model.PageDescription = "This website is online auction system for bidding products";
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}