using AuctionSystem.Entities;
using AuctionSystem.Services;
using AuctionSystem.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionSystem.Web.Controllers
{
    public class AuctionController : Controller
    {
        CategoryService categoriesService = new CategoryService();
        AuctionServices auctionService = new AuctionServices();
        AuctionsListViewModel model = new AuctionsListViewModel();

        public ActionResult Index()
        {
               
            model.Auctions = auctionService.GetAuction();
            model.PageTitle = "Auctions Lists";
            model.PageDescription = "These are the list of Auctions";
            if(Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();
            model.Categories = categoriesService.GetAllCategories();
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }

        }

        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel model)
        {
            Auction auction = new Auction();
            auction.Title = model.Title;
            auction.ActualAmount = model.ActualAmount;
            auction.Description = model.Description;
            auction.CategoryId = model.CategoryId;
            auction.Title = model.Title;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;

            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {
                var pictureIds = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();

                auction.AuctionPictures = new List<AuctionPicture>();

                auction.AuctionPictures.AddRange(pictureIds.Select(x => new AuctionPicture() { PictureId = x }).ToList());
            }

            auctionService.AddAuction(auction);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();
            var auction = auctionService.GetAuctionId(Id);
            model.Id = auction.Id;
            model.Title = auction.Title;
            model.CategoryId = auction.CategoryId;
            model.ActualAmount = auction.ActualAmount;
            model.Description = auction.Description;
            model.StartingTime = auction.StartingTime;
            model.EndingTime = auction.EndingTime;
            model.Categories = categoriesService.GetAllCategories();

            model.AuctionPicturesList = auction.AuctionPictures;

             return PartialView(model);
            
        }

       [HttpPost]
        public ActionResult Edit(CreateAuctionViewModel model)
        {
            Auction auction = new Auction();
            auction.Id = model.Id;
            auction.Title = model.Title;
            auction.ActualAmount = model.ActualAmount;
            auction.Description = model.Description;
            auction.CategoryId = model.CategoryId;
            auction.Title = model.Title;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;

            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {
                var pictureIds = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();

                auction.AuctionPictures = new List<AuctionPicture>();

                auction.AuctionPictures.AddRange(pictureIds.Select(x => new AuctionPicture() { PictureId = x }).ToList());
            }
            auctionService.UpdateAuction(auction);
          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var auction = auctionService.GetAuctionId(Id);
            return PartialView(auction);
        }

        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            auctionService.DeleteAuction(auction);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Details(int Id)
        {
            AuctionDetailViewModel model = new AuctionDetailViewModel();

            model.Auction = auctionService.GetAuctionId(Id);
            model.PageTitle = "Auction Details";
            model.PageDescription = "This is auction Detail page";
            return View(model);
        }
       
    }
}